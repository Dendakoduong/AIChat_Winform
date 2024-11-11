using System;
using System.IO;
using System.Text.Json;
using DTO;
using System.Collections.Generic;

namespace gemini
{
    public class ConfigManager
    {
        // Define the config file path here
        private const string ConfigFilePath = "gethelp_config.json";

        public Config LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                try
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    var config = JsonSerializer.Deserialize<Config>(json);

                    if (config != null)
                    {
                        return config;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception and return default config
                    Console.WriteLine($"Error loading config: {ex.Message}");
                }
            }

            // Return a default config if not found or failed to load
            return new Config { SelectedModel = "Gemini", SelectedOption = null };
        }

        public void SaveConfig(string selectedModel, string selectedOption)
        {
            var config = new Config
            {
                SelectedModel = selectedModel,
                SelectedOption = selectedOption
            };

            try
            {
                string json = JsonSerializer.Serialize(config);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                // Handle exception during saving
                Console.WriteLine($"Error saving config: {ex.Message}");
            }
        }
    }
}
