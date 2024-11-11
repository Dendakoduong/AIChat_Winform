using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gemini
{
    public class GroqApiClient
    {
        private const string GroqApiUrl = "https://api.groq.com/openai/v1/chat/completions";
        private const string GroqApiKey = "GROQ_API_KEY"; // Replace with your API Key
        private readonly HttpClient _httpClient;

        public GroqApiClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public async Task<string> GetAiResponseAsync(string userInput, string model)
        {
            // Maintain a list to track conversation history
            var conversationHistory = new List<string>();

            // Add the user input to the conversation history
            conversationHistory.Add($"User: {userInput}");

            // Prepare the request data for Groq API
            var requestData = new
            {
                messages = GetMessagesForApiRequest(conversationHistory),
                model = model // Use the passed model
            };

            try
            {
                // Serialize the request data using System.Text.Json
                string jsonRequest = JsonSerializer.Serialize(requestData);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Set up the authorization header with the API key
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GroqApiKey);

                // Send the request to the Groq API
                var response = await _httpClient.PostAsync(GroqApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response using System.Text.Json
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<JsonElement>(responseContent);

                    // Extract the response from the deserialized JSON
                    var responseMessage = responseJson.GetProperty("choices")[0]
                        .GetProperty("message").GetProperty("content").GetString();

                    return responseMessage ?? "No response from API.";
                }
                else
                {
                    throw new Exception("Failed to get response from Groq API.");
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private IEnumerable<object> GetMessagesForApiRequest(List<string> conversationHistory)
        {
            var messages = new List<object>();

            // Add a system message introducing the assistant (Emma)
            messages.Add(new
            {
                role = "system",
                content = "You are Doraemon, an assistant. Your respond in Vietnamese."
            });

            // Add user and assistant messages
            foreach (var message in conversationHistory)
            {
                var role = message.StartsWith("User:") ? "user" : "assistant";
                var content = message.Substring(message.IndexOf(':') + 2); // Get content after "User:" or "Assistant:"

                messages.Add(new
                {
                    role = role,
                    content = content
                });
            }

            return messages;
        }
    }
}
