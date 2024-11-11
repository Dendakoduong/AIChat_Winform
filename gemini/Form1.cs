using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gemini
{
    public partial class Form1 : Form
    {
        private readonly GeminiApiClient _geminiClient;
        private readonly GroqApiClient _groqClient;
        private readonly OpenRouterApiClient _openRouterClient;
        private readonly StringBuilder _conversationHistory = new StringBuilder();
        private readonly ConfigManager _configManager; // Add ConfigManager
        private HolidayService holidayService;
        // Default values if settings file is missing or malformed
        private string defaultUserName = "Me";
        private Color defaultUserTextColor = Color.Blue;
        private Color defaultAiTextColor = Color.Red;
        private string defaultFontName = "Arial";
        private float defaultFontSize = 12f;
        public Form1()
        {
            InitializeComponent();
            LoadChatSettings();
            InitializeHolidayService();

            _configManager = new ConfigManager(); // Initialize ConfigManager
            _geminiClient = new GeminiApiClient(new GenerationConfig { Temperature = 0.8, MaxOutputTokens = 2048 });
            _groqClient = new GroqApiClient();
            _openRouterClient = new OpenRouterApiClient("OPEN_ROUTER_API_KEY");

            // Set form properties to prevent resizing and maximizing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; // Disable maximize button
            this.SizeGripStyle = SizeGripStyle.Hide; // Hide the size grip (bottom-right corner)

            // Initially hide cmbOption
            cmbOption.Visible = false;

            // Attach event handlers
            btnSend.Click += async (sender, e) => await SendRequest();
            btnClear.Click += (sender, e) => ClearChatHistory();
            mniSave.Click += (sender, e) => SaveChatHistory();
            mniLoad.Click += (sender, e) => LoadChatHistory();
            mniAbout.Click += (sender, e) => mniAbout_Click(sender, e);
            txtInput.KeyDown += (sender, e) => HandleEnterKey(sender, e);

            cmbModel.Items.Add("Gemini");
            cmbModel.Items.Add("Groq");
            cmbModel.Items.Add("OpenRouter");

            // Load previously selected model from the config file
            LoadSelectedModelFromConfig(); // Use ConfigManager to load

            // Subscribe to the ComboBox selection change event to update the warning label and save the selected model
            cmbModel.SelectedIndexChanged += (sender, e) =>
            {
                // Save only the selected model when the selection changes
                SaveSelectedModelToConfig(cmbModel.SelectedItem.ToString());
                UpdateWarningLabel(cmbModel.SelectedItem.ToString());
                HandleModelSelectionChange();
            };

            // Subscribe to the ComboBox option change event for OpenRouter/Groq to save selected option
            cmbOption.SelectedIndexChanged += (sender, e) =>
            {
                // Save the selected option when cmbOption selection changes
                SaveSelectedOptionToConfig(cmbOption.SelectedItem?.ToString());
            };

            // Initial warning label update
            UpdateWarningLabel(cmbModel.SelectedItem.ToString());

            // Update the button states based on the initial chat content
            UpdateButtonStates();

            // Handle initial model selection to update cmbOption visibility
            HandleModelSelectionChange();
        }
        private async void HandleEnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the "ding" sound when pressing Enter
                await SendRequest(); // Call SendRequest method to send the message
            }
        }
        private void HandleModelSelectionChange()
        {
            string previousModel = cmbOption.Tag?.ToString(); // Store previous model
            string currentModel = cmbModel.SelectedItem?.ToString(); // Current model

            // Store the selected option only if we're staying on the same model
            string currentOption = (previousModel == currentModel) ? cmbOption.SelectedItem?.ToString() : null;

            // Create an instance of the ModelOptionsProvider (DAL)
            var modelOptionsProvider = new ModelOptionsProvider();

            // Get the available options based on the selected model
            List<string> options = modelOptionsProvider.GetOptionsForModel(currentModel);

            // Update the ComboBox visibility and items based on the model
            if (currentModel == "Gemini")
            {
                cmbOption.Visible = false;
                cmbOption.SelectedItem = null;
            }
            else if (currentModel == "Groq" || currentModel == "OpenRouter")
            {
                cmbOption.Visible = true;
                cmbOption.Items.Clear();
                cmbOption.Items.AddRange(options.ToArray());  // Add options to the ComboBox

                if (previousModel == currentModel && !string.IsNullOrEmpty(currentOption) && cmbOption.Items.Contains(currentOption))
                {
                    cmbOption.SelectedItem = currentOption; // Restore the previous selected option if available
                }
                else
                {
                    // Set default selection if no previous selection
                    cmbOption.SelectedItem = options.Count > 0 ? options[0] : null;
                }
            }

            // Store current model for next comparison
            cmbOption.Tag = currentModel;

            // Update the warning label based on the selected model
            UpdateWarningLabel(currentModel);
        }
        private void LoadSelectedModelFromConfig()
        {
            // Use ConfigManager to load the config
            var config = _configManager.LoadConfig();

            // Set the model and options based on the config
            if (!string.IsNullOrEmpty(config.SelectedModel) && cmbModel.Items.Contains(config.SelectedModel))
            {
                cmbModel.SelectedItem = config.SelectedModel;
                cmbOption.Tag = config.SelectedModel; // Set initial model for comparison
            }
            else
            {
                cmbModel.SelectedItem = "Gemini";
                cmbOption.Tag = "Gemini";
            }

            if (!string.IsNullOrEmpty(config.SelectedOption))
            {
                HandleModelSelectionChange();
                if (cmbOption.Items.Contains(config.SelectedOption))
                {
                    cmbOption.SelectedItem = config.SelectedOption;
                }
            }
            else
            {
                HandleModelSelectionChange();
            }
        }
        private void SaveSelectedModelToConfig(string selectedModel)
        {
            // Save the selected model and option to config using ConfigManager
            string selectedOption = cmbOption.SelectedItem?.ToString();
            _configManager.SaveConfig(selectedModel, selectedOption);
        }
        private void SaveSelectedOptionToConfig(string selectedOption)
        {
            var config = new Config
            {
                SelectedModel = cmbModel.SelectedItem.ToString(),
                SelectedOption = selectedOption // Save the selected option
            };

            try
            {
                // Use ConfigManager to save the config
                _configManager.SaveConfig(config.SelectedModel, config.SelectedOption);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving config: {ex.Message}");
            }
        }
        private async Task SendRequest()
        {
            string userInput = txtInput.Text.Trim();
            userInput = System.Text.RegularExpressions.Regex.Replace(userInput, @"\s+", " ");

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Please enter some text in the input box.");
                return;
            }

            // Use the loaded settings for the custom name
            string selectedModel = cmbModel.SelectedItem.ToString();

            string customName = defaultUserName; // Default to the loaded user name
            // Construct the message to include the custom name 
            string userMessage = $"{customName}: {userInput}";

            UpdateUiSendingState();
            AppendTextToChat($"{customName}: {userInput}\n", defaultUserTextColor, HorizontalAlignment.Left);
            txtInput.Clear();

            string aiResponse = string.Empty;

            // Call API based on selected model (Gemini, Groq, or OpenRouter)
            if (cmbModel.SelectedItem.ToString() == "Gemini")
            {
                selectedModel = "Elsa"; // Use the custom name for Gemini
                //aiResponse = await _geminiClient.GetAiResponseAsync(userInput);
                aiResponse = await _geminiClient.GetAiResponseAsync(userMessage);
            }
            else if (cmbModel.SelectedItem.ToString() == "Groq")
            {
                selectedModel = "Doraemon"; // Use the custom name for Groq
                string selectedGroqModel = cmbOption.SelectedItem.ToString();
                aiResponse = await _groqClient.GetAiResponseAsync(userMessage, selectedGroqModel);
            }
            else if (cmbModel.SelectedItem.ToString() == "OpenRouter")
            {
                selectedModel = "Kuromi"; // Use the custom name for OpenRouter
                string selectedOpenRouterModel = cmbOption.SelectedItem?.ToString();
                aiResponse = await _openRouterClient.GetAiResponseAsync(userMessage, selectedOpenRouterModel);
            }

            // Use the AI text color loaded from settings
            if (!string.IsNullOrEmpty(aiResponse))
            {
                // Use the AI color from settings
                AppendTextToChat($"{selectedModel}: {aiResponse}\n", defaultAiTextColor, HorizontalAlignment.Left);
            }
            else
            {
                // Use the default AI color when there's no response
                AppendTextToChat("No response from AI.\n", defaultAiTextColor, HorizontalAlignment.Left);
            }

            ResetUiSendingState();
            UpdateButtonStates();
            txtInput.Focus();
        }
        private void AppendTextToChat(string text, Color color, HorizontalAlignment alignment)
        {
            rtbOutput.SelectionStart = rtbOutput.TextLength;
            rtbOutput.SelectionLength = 0;
            rtbOutput.SelectionColor = color;
            rtbOutput.SelectionAlignment = alignment;
            rtbOutput.AppendText(text);
            rtbOutput.SelectionColor = rtbOutput.ForeColor;
            rtbOutput.ScrollToCaret();
        }
        private void UpdateUiSendingState()
        {
            btnSend.Enabled = false;
            btnSend.Text = "Waiting...";
            btnSend.Image = null;
        }
        private void ResetUiSendingState()
        {
            btnSend.Enabled = true;
            btnSend.Text = ""; 

            string iconPath = Path.Combine(Application.StartupPath, "Icons", "SendIcon.png");

            if (File.Exists(iconPath))
            {
                btnSend.Image = Image.FromFile(iconPath);  
            }
            else
            {
                btnSend.Text = "Send"; 
                btnSend.Image = null;
            }
        }
        // Update the warning label and icon based on the selected model
        private void UpdateWarningLabel(string selectedModel)
        {
            string iconsFolderPath = Path.Combine(Application.StartupPath, "Icons");

            if (!Directory.Exists(iconsFolderPath))
            {
                lblWarning.Text = "Icons folder not found!";
                return;
            }

            string iconPath = string.Empty;

            if (selectedModel == "Gemini")
            {
                iconPath = Path.Combine(iconsFolderPath, "geminiIcon.png");
                lblWarning.Text = "Gemini có thể mắc lỗi. Hãy kiểm tra kỹ thông tin.";
            }
            else if (selectedModel == "Groq")
            {
                iconPath = Path.Combine(iconsFolderPath, "groqIcon.png");
                lblWarning.Text = "AI có thể mắc lỗi. Hãy kiểm tra thông tin quan trọng.";
            }
            else if (selectedModel == "OpenRouter")
            {
                iconPath = Path.Combine(iconsFolderPath, "openrouterIcon.png");
                lblWarning.Text = "AI có thể mắc lỗi. Hãy kiểm tra thông tin quan trọng.";
            }

            if (File.Exists(iconPath))
            {
                lblWarning.Image = Image.FromFile(iconPath);
            }
            else
            {
                lblWarning.Text += " (Icon file not found!)";
            }
        }
        private void ClearChatHistory()
        {
            var confirmationResult = MessageBox.Show(
                "Are you sure you want to clear the chat history?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmationResult == DialogResult.Yes)
            {
                rtbOutput.Clear();
                _conversationHistory.Clear();
                UpdateButtonStates();
                txtInput.Focus();
            }
        }
        private void SaveChatHistory()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string autoGeneratedFileName = $"ChatHistory_{timestamp}.txt";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = autoGeneratedFileName,
                Filter = "Text Files|*.txt|All Files|*.*",
                Title = "Save Chat History"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, rtbOutput.Text);
                    MessageBox.Show("Chat history saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving chat history: {ex.Message}");
                }
            }
        }
        private void LoadChatHistory()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt|All Files|*.*",
                Title = "Load Chat History"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string chatHistory = File.ReadAllText(openFileDialog.FileName);
                    rtbOutput.Text = chatHistory;
                    MessageBox.Show("Chat history loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading chat history: {ex.Message}");
                }
            }

            UpdateButtonStates();
        }
        private void UpdateButtonStates()
        {
            bool isChatEmpty = string.IsNullOrEmpty(rtbOutput.Text.Trim());

            btnClear.Enabled = !isChatEmpty;
            mniSave.Enabled = !isChatEmpty;
        }
        private void mniAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }
        private void InitializeHolidayService()
        {
            var solarHolidays = LE.solar; // Assume LE.solar provides the solar holidays list
            var lunarHolidays = LunarHolidays.GetHolidays(); // Assume LunarHolidays provides the lunar holidays list
            holidayService = new HolidayService(solarHolidays, lunarHolidays);
            UpdateHolidayInfo();
        }

        private void UpdateHolidayInfo()
        {
            var today = DateTime.Now;
            lblHoliday.Text = holidayService.GetTodayHolidayInfo(today);
        }
        //Settings
        private void LoadChatSettings()
        {
            string settingsFilePath = "chatSettings.json"; // Path to load settings from

            if (File.Exists(settingsFilePath))
            {
                try
                {
                    // Deserialize the JSON file to ChatSettings object
                    var chatSettingsJson = File.ReadAllText(settingsFilePath);
                    var chatSettings = JsonSerializer.Deserialize<ChatSettings>(chatSettingsJson);

                    // Apply the loaded settings to the UI
                    if (chatSettings != null)
                    {
                        // Set the font (same for user and AI)
                        Font appliedFont = new Font(chatSettings.FontName, chatSettings.FontSize);
                        rtbOutput.Font = appliedFont;
                        txtInput.Font = appliedFont;

                        // Convert the string color values to Color objects
                        defaultUserTextColor = GetColorFromString(chatSettings.UserTextColor);  // Convert string to Color
                        defaultAiTextColor = GetColorFromString(chatSettings.AiTextColor);      // Convert string to Color

                        // Set the default user name
                        defaultUserName = chatSettings.UserName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading chat settings: {ex.Message}");
                }
            }
            else
            {
                //MessageBox.Show("Chat settings file not found.");
            }
        }
        private Color GetColorFromString(string colorString)
        {
            // Try parsing the string as a hex color code (e.g., #FF8000)
            if (colorString.StartsWith("#"))
            {
                try
                {
                    return ColorTranslator.FromHtml(colorString);
                }
                catch
                {
                    MessageBox.Show($"Invalid hex color: {colorString}. Using default color.");
                    return Color.Black; // Fallback to black if invalid
                }
            }

            // Otherwise, try parsing as a named color (e.g., "Blue")
            try
            {
                return Color.FromName(colorString);
            }
            catch
            {
                MessageBox.Show($"Invalid color name: {colorString}. Using default color.");
                return Color.Black; // Fallback to black if invalid
            }
        }
        private void mniSettings_Click(object sender, EventArgs e)
        {
            // Create the settings form
            SettingsForm settingsForm = new SettingsForm();

            // Subscribe to the SettingsUpdated event
            settingsForm.SettingsUpdated += ApplySettings;

            // Show the settings form
            settingsForm.ShowDialog();
        }

        private void ApplySettings(ChatSettings newSettings)
        {
            // Apply the new settings to Form1
            defaultUserName = newSettings.UserName;
            defaultFontName = newSettings.FontName;
            defaultFontSize = newSettings.FontSize;

            // Update the font for both input and output text boxes
            Font appliedFont = new Font(defaultFontName, defaultFontSize);
            rtbOutput.Font = appliedFont;
            txtInput.Font = appliedFont;

            // Update the text color settings
            defaultUserTextColor = ChatSettings.HexToColor(newSettings.UserTextColor);
            defaultAiTextColor = ChatSettings.HexToColor(newSettings.AiTextColor);

            // Optionally, refresh the UI or update buttons if necessary
            UpdateButtonStates();
        }

    }
}
