using System;
using System.Collections.Generic;

namespace DAL
{
    public class ModelOptionsProvider
    {
        // A dictionary to store the options for each model
        private static readonly Dictionary<string, List<string>> ModelOptions = new Dictionary<string, List<string>>
        {
            { "Gemini", new List<string> { } },  // Gemini has no options
            { "Groq", new List<string>
                {
                    "gemma2-9b-it",
                    "gemma-7b-it",
                    "llama3-groq-70b-8192-tool-use-preview",
                    "llama3-groq-8b-8192-tool-use-preview",
                    "llama-3.1-70b-versatile",
                    "llama-3.1-8b-instant",
                    "llama-3.2-1b-preview",
                    "llama-3.2-3b-preview",
                    "llama-3.2-11b-vision-preview",
                    "llama-3.2-90b-vision-preview",
                    "llama-guard-3-8b",
                    "llama3-70b-8192",
                    "llama3-8b-8192",
                    "mixtral-8x7b-32768"
                }
            },
            { "OpenRouter", new List<string>
                {
                    "google/gemma-2-9b-it:free",
                    "google/gemini-pro-1.5-exp",
                    "google/gemini-flash-1.5-8b",
                    "google/gemini-flash-1.5-exp",
                    "google/gemini-flash-1.5-8b-exp",
                    "meta-llama/llama-3.2-3b-instruct:free",
                    "meta-llama/llama-3.2-1b-instruct:free",
                    "meta-llama/llama-3.2-90b-vision-instruct:free",
                    "meta-llama/llama-3.2-11b-vision-instruct:free",
                    "meta-llama/llama-3.1-70b-instruct:free",
                    "meta-llama/llama-3.1-8b-instruct:free",
                    "meta-llama/llama-3.1-405b-instruct:free",
                    "meta-llama/llama-3-8b-instruct:free",
                    "microsoft/phi-3-mini-128k-instruct:free",
                    "microsoft/phi-3-medium-128k-instruct:free",
                    "mistralai/mistral-7b-instruct:free",
                    "nousresearch/hermes-3-llama-3.1-405b:free",
                    "gryphe/mythomist-7b:free",
                    "gryphe/mythomax-l2-13b:free",
                    "openchat/openchat-7b:free",
                    "undi95/toppy-m-7b:free",
                    "huggingfaceh4/zephyr-7b-beta:free",
                    "liquid/lfm-40b:free",
                    "qwen/qwen-2-7b-instruct:free"
                }
            }
        };

        // This method returns the available options based on the selected model
        public List<string> GetOptionsForModel(string modelName)
        {
            if (ModelOptions.ContainsKey(modelName))
            {
                return ModelOptions[modelName];
            }

            // Return an empty list if the model is not found
            return new List<string>();
        }
    }
}
