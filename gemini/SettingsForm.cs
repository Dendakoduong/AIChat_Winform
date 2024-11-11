using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace gemini
{
    public partial class SettingsForm : Form
    {
        private Color _userTextColor;
        private Color _aiTextColor;
        private Font _font;
        private string _userName;

        private string settingsFilePath = "chatSettings.json"; // Path to store settings

        public SettingsForm()
        {
            InitializeComponent();
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnSelectAiColor.Click += new System.EventHandler(this.btnSelectAiColor_Click);
            this.btnSelectUserColor.Click += new System.EventHandler(this.btnSelectUserColor_Click);
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            this.Load += new System.EventHandler(this.SettingsForm_Load);

            // Set form properties to prevent resizing and maximizing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; // Disable maximize button
            this.SizeGripStyle = SizeGripStyle.Hide; // Hide the size grip (bottom-right corner)

            // Set the MaxLength for txtUserName to 20 characters
            txtUserName.MaxLength = 20;

            // Add a TextChanged event handler to validate the username input
            txtUserName.TextChanged += txtUserName_TextChanged;
        }
        // Validate the username input (tu xoa ki tu du thua)
        /*private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            // Get the current username text
            string input = txtUserName.Text;

            // Remove any special characters by filtering the string
            string validInput = RemoveInvalidCharacters(input);

            // If the input is different, update the textbox with the valid input
            if (input != validInput)
            {
                txtUserName.Text = validInput;
                // Move the cursor to the end of the textbox (after text change)
                txtUserName.SelectionStart = txtUserName.Text.Length;
            }
        }*/
        //co thong baos khi nhap qua 20 ki tu
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            // Get the current username text
            string input = txtUserName.Text;

            // Check if the input length exceeds 20 characters
            if (input.Length > 20)
            {
                // Show a message or highlight the textbox
                MessageBox.Show("Username cannot be more than 20 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // You can also highlight the textbox to indicate an error
                txtUserName.BackColor = Color.Pink; // Change the background color to pink (error indication)
            }
            else
            {
                // Reset the textbox background color if it's valid
                txtUserName.BackColor = SystemColors.Window;
            }

            // Remove any special characters by filtering the string
            string validInput = RemoveInvalidCharacters(input);

            // If the input is different, update the textbox with the valid input
            if (input != validInput)
            {
                txtUserName.Text = validInput;
                // Show a message indicating the invalid characters have been removed (co the bo di neu muon tu xoa ki tu dac biet)
                MessageBox.Show("Invalid characters have been removed from the username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Move the cursor to the end of the textbox (after text change)
                txtUserName.SelectionStart = txtUserName.Text.Length;
            }
        }
        private string RemoveInvalidCharacters(string input)
        {
            // Define a regular expression to remove unwanted special characters
            // Allow only letters, numbers, and spaces
            string pattern = @"[^a-zA-Z0-9 ]";

            // Replace any character not matching the pattern with an empty string
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, string.Empty);
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load settings from file if available
            ChatSettings settings = LoadSettingsFromFile();

            if (settings != null)
            {
                // Apply loaded settings to controls
                _userTextColor = ChatSettings.HexToColor(settings.UserTextColor);
                _aiTextColor = ChatSettings.HexToColor(settings.AiTextColor);
                _font = ChatSettings.StringToFont($"{settings.FontName},{settings.FontSize}");
                _userName = settings.UserName;

                // Set initial values in the form controls
                txtUserName.Text = _userName;
                lblFontSample.Font = _font;
                btnSelectUserColor.BackColor = _userTextColor;
                btnSelectAiColor.BackColor = _aiTextColor;
            }
            else
            {
                // Default values if no settings file exists
                _userTextColor = Color.Blue;
                _aiTextColor = Color.Red;
                _font = new Font("Arial", 12);
                _userName = "Me";

                // Set default values in controls
                txtUserName.Text = _userName;
                lblFontSample.Font = _font;
                btnSelectUserColor.BackColor = _userTextColor;
                btnSelectAiColor.BackColor = _aiTextColor;
            }
        }

        private void btnSelectUserColor_Click(object sender, EventArgs e)
        {
            if (colorDialogUser.ShowDialog() == DialogResult.OK)
            {
                _userTextColor = colorDialogUser.Color;
                btnSelectUserColor.BackColor = _userTextColor;  // Update button color
            }
        }

        private void btnSelectAiColor_Click(object sender, EventArgs e)
        {
            if (colorDialogAI.ShowDialog() == DialogResult.OK)
            {
                _aiTextColor = colorDialogAI.Color;
                btnSelectAiColor.BackColor = _aiTextColor;  // Update button color
            }
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            /*if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                _font = fontDialog.Font;
                lblFontSample.Font = _font;  // Update font sample label
            }*/
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected font from the font dialog
                Font selectedFont = fontDialog.Font;

                // Set the font style to regular (removes any bold, italic, etc.)
                Font adjustedFont = new Font(selectedFont.FontFamily, selectedFont.Size, FontStyle.Regular);

                // Update the label to show the selected font without styles
                lblFontSample.Font = adjustedFont;

                // Update the font for the RichTextBox (rtbOutput)
                _font = adjustedFont;
            }
        }

        /*private void btnApply_Click(object sender, EventArgs e)
        {
            // Save the settings and pass them back to the main form (Form1)
            _userName = txtUserName.Text;

            var settings = new ChatSettings
            {
                UserTextColor = ChatSettings.ColorToHex(_userTextColor),
                AiTextColor = ChatSettings.ColorToHex(_aiTextColor),
                FontName = _font.Name,   // Store font name
                FontSize = _font.Size,   // Store font size
                UserName = _userName
            };

            // Save settings to a JSON file
            SaveSettingsToFile(settings);

            // Return the settings via DialogResult
            DialogResult = DialogResult.OK;
            Tag = settings;  // Store the settings in the Tag property for easy access
            Close();
        }*/
        // Define an event to notify the main form about updated settings
        public event Action<ChatSettings> SettingsUpdated;

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save the settings
            _userName = txtUserName.Text;

            var settings = new ChatSettings
            {
                UserTextColor = ChatSettings.ColorToHex(_userTextColor),
                AiTextColor = ChatSettings.ColorToHex(_aiTextColor),
                FontName = _font.Name,
                FontSize = _font.Size,
                UserName = _userName
            };

            // Save settings to a JSON file
            SaveSettingsToFile(settings);

            // Raise the event to notify the main form
            SettingsUpdated?.Invoke(settings);

            // Close the settings form
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Simply close the settings form without applying changes
            Close();
        }

        // Save settings to a JSON file
        private void SaveSettingsToFile(ChatSettings settings)
        {
            try
            {
                // Serialize the settings to JSON
                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });

                // Save to a file
                File.WriteAllText(settingsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }

        // Load settings from a JSON file
        private ChatSettings LoadSettingsFromFile()
        {
            try
            {
                if (File.Exists(settingsFilePath))
                {
                    string json = File.ReadAllText(settingsFilePath);
                    return JsonSerializer.Deserialize<ChatSettings>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}");
            }
            return null; // Return null if the file does not exist or an error occurred
        }
        // Default and automatically save + load
        /*private void btnDefault_Click(object sender, EventArgs e)
        {
            // Set default values for the settings
            _userName = "Me"; // Default username
            _userTextColor = Color.Blue; // Default user text color
            _aiTextColor = Color.Red; // Default AI text color
            _font = new Font("Arial", 12); // Default font (Arial, 12)

            // Update controls to reflect the default values
            txtUserName.Text = _userName;
            lblFontSample.Font = _font;
            btnSelectUserColor.BackColor = _userTextColor;
            btnSelectAiColor.BackColor = _aiTextColor;

            // Create a new ChatSettings object with default values
            var defaultSettings = new ChatSettings
            {
                UserTextColor = ChatSettings.ColorToHex(_userTextColor),
                AiTextColor = ChatSettings.ColorToHex(_aiTextColor),
                FontName = _font.Name,
                FontSize = _font.Size,
                UserName = _userName
            };

            // Save the default settings to the JSON file
            SaveSettingsToFile(defaultSettings);

            // Optionally raise the event to notify the main form (if needed)
            SettingsUpdated?.Invoke(defaultSettings);

            // Optional: Show a confirmation message
            MessageBox.Show("Settings have been reset to default values.");
        }*/
        //default but need to apply
        private void btnDefault_Click(object sender, EventArgs e)
        {
            // Set default values for the settings
            _userName = "Me"; // Default username
            _userTextColor = Color.Blue; // Default user text color
            _aiTextColor = Color.Red; // Default AI text color
            _font = new Font("Arial", 12); // Default font (Arial, 12)

            // Update controls to reflect the default values
            txtUserName.Text = _userName;
            lblFontSample.Font = _font;
            btnSelectUserColor.BackColor = _userTextColor;
            btnSelectAiColor.BackColor = _aiTextColor;

            // No need to save these settings right away.
            // The user will need to click Apply to save the changes.

            // Optional: Show a confirmation message
            MessageBox.Show("Settings have been reset to default values. Click Apply to save.");
        }

    }
}
public class ChatSettings
{
    public string UserTextColor { get; set; }  // User text color in Hex format (e.g., "#0000FF")
    public string AiTextColor { get; set; }    // AI text color in Hex format (e.g., "#FF0000")
    public string FontName { get; set; }       // Font name (e.g., "Arial")
    public float FontSize { get; set; }        // Font size (e.g., 12.0)
    public string UserName { get; set; }        // Store username

    // Convert Color to Hex String
    public static string ColorToHex(Color color)
    {
        return ColorTranslator.ToHtml(color);
    }

    // Convert Hex String to Color
    public static Color HexToColor(string hex)
    {
        return ColorTranslator.FromHtml(hex);
    }

    // Convert Font to string (Font name and size)
    public static string FontToString(Font font)
    {
        return $"{font.Name},{font.Size}";
    }

    // Convert string to Font
    public static Font StringToFont(string fontString)
    {
        var parts = fontString.Split(',');
        string fontName = parts[0];
        float fontSize = float.Parse(parts[1]);
        return new Font(fontName, fontSize);
    }
}
