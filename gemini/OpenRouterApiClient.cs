using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gemini
{
    public class OpenRouterApiClient
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly List<string> _conversationHistory;

        // Constructor to accept the API key and initialize the conversation history
        public OpenRouterApiClient(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _httpClient = new HttpClient();
            _conversationHistory = new List<string>();
        }

        // Asynchronous method to get AI response from OpenRouter API
        public async Task<string> GetAiResponseAsync(
            string userInput,
            string selectedModel,
            float temperature = 1.0f,
            float top_p = 1.0f,
            int top_k = 0,
            float frequency_penalty = 0.0f,
            float presence_penalty = 0.0f,
            float repetition_penalty = 1.0f,
            string stop = null
        )
        {
            if (string.IsNullOrEmpty(userInput))
            {
                throw new ArgumentException("User input cannot be null or empty", nameof(userInput));
            }

            if (string.IsNullOrEmpty(selectedModel))
            {
                throw new ArgumentException("Model selection cannot be null or empty", nameof(selectedModel));
            }

            // Add user input to conversation history
            _conversationHistory.Add($"User: {userInput}");

            try
            {
                // Define the API endpoint
                string apiUrl = "https://openrouter.ai/api/v1/chat/completions";

                // Prepare the request body as JSON
                var requestBody = new
                {
                    model = selectedModel,
                    temperature = temperature,
                    top_p = top_p,
                    top_k = top_k,
                    frequency_penalty = frequency_penalty,
                    presence_penalty = presence_penalty,
                    repetition_penalty = repetition_penalty,
                    stop = stop != null ? new[] { stop } : null,
                    messages = GetMessagesForApiRequest()
                };

                // Serialize the request body to JSON
                string jsonRequestBody = JsonSerializer.Serialize(requestBody);

                // Create a new HTTP request with necessary headers
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json")
                };

                // Add the Authorization header with the API key
                request.Headers.Add("Authorization", $"Bearer {_apiKey}");

                // Send the request and get the response
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<JsonElement>(responseContent);
                    string aiText = responseJson.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                    // Add AI response to conversation history
                    _conversationHistory.Add($"Assistant: {aiText}");

                    return aiText?.Trim();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error from OpenRouter API: {response.StatusCode} - {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Method to generate message list for API request from conversation history
        private IEnumerable<object> GetMessagesForApiRequest()
        {
            var messages = new List<object>
            {
                new
                {
                    role = "system",
                    //content = "You are Nguyen, an assistant. You should answer in Vietnamese."
                    content = "You are Kuromi, an assistant. You should answer in Vietnamese."
                }
            };

            foreach (var message in _conversationHistory)
            {
                var role = message.StartsWith("User:") ? "user" : "assistant";
                var content = message.Substring(message.IndexOf(':') + 2).Trim();

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

