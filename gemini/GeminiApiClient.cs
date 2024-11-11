using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DTO;

namespace gemini
{
    public class GeminiApiClient
    {
        private const string ApiKey = "GEMINI_APIKEY_HERE";
        private static readonly string Endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={ApiKey}";
        private readonly HttpClient _httpClient;
        private readonly GenerationConfig _generationConfig;
        private readonly StringBuilder _conversationHistory = new StringBuilder();

        public GeminiApiClient(GenerationConfig generationConfig, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _generationConfig = generationConfig;
        }

        // Public method to get AI response and manage context
        public async Task<string> GetAiResponseAsync(string userInput)
        {
            // Update conversation history with user input
            _conversationHistory.AppendLine($"Me: {userInput}");

            // Build the context to send to the API
            string context = $"{_conversationHistory}\nYou are Elsa, an AI assistant. Answer in Vietnamese and concisely.";
            //string context = $"{_conversationHistory}\nYou are Elsa, an AI assistant. Answer in Vietnamese.";

            // Prepare the request data
            var requestData = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[] { new { text = $"Context:\n{context}\nUser: {userInput}" } }
                    }
                },
                generationConfig = new
                {
                    temperature = _generationConfig.Temperature,
                    maxOutputTokens = _generationConfig.MaxOutputTokens
                }
            };

            try
            {
                // Send the request to the API
                var jsonRequest = JsonSerializer.Serialize(requestData);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(Endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read and parse the response
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<GeminiApiResponse>(responseJson);
                    return ExtractAiResponse(responseData);
                }
                else
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    return $"Error: {errorJson}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Private method to extract the AI response from the API response
        private string ExtractAiResponse(GeminiApiResponse responseData)
        {
            return responseData?.candidates != null && responseData.candidates.Length > 0 &&
                   responseData.candidates[0].content?.parts != null &&
                   responseData.candidates[0].content.parts.Length > 0
                ? responseData.candidates[0].content.parts[0].text
                : "No response text found.";
        }

        // To access conversation history if needed elsewhere in the future
        public string GetConversationHistory() => _conversationHistory.ToString();
    }
}