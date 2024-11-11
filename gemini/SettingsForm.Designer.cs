namespace gemini
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserColor = new System.Windows.Forms.Label();
            this.lblAiColor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnSelectUserColor = new System.Windows.Forms.Button();
            this.colorDialogUser = new System.Windows.Forms.ColorDialog();
            this.btnSelectAiColor = new System.Windows.Forms.Button();
            this.colorDialogAI = new System.Windows.Forms.ColorDialog();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.lblFontSample = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Font and Size";
            // 
            // lblUserColor
            // 
            this.lblUserColor.AutoSize = true;
            this.lblUserColor.Location = new System.Drawing.Point(6, 24);
            this.lblUserColor.Name = "lblUserColor";
            this.lblUserColor.Size = new System.Drawing.Size(79, 16);
            this.lblUserColor.TabIndex = 2;
            this.lblUserColor.Text = "Color (User)";
            // 
            // lblAiColor
            // 
            this.lblAiColor.AutoSize = true;
            this.lblAiColor.Location = new System.Drawing.Point(6, 60);
            this.lblAiColor.Name = "lblAiColor";
            this.lblAiColor.Size = new System.Drawing.Size(62, 16);
            this.lblAiColor.TabIndex = 3;
            this.lblAiColor.Text = "Color (AI)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(131, 49);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 22);
            this.txtUserName.TabIndex = 5;
            // 
            // btnSelectUserColor
            // 
            this.btnSelectUserColor.Location = new System.Drawing.Point(103, 21);
            this.btnSelectUserColor.Name = "btnSelectUserColor";
            this.btnSelectUserColor.Size = new System.Drawing.Size(100, 23);
            this.btnSelectUserColor.TabIndex = 6;
            this.btnSelectUserColor.UseVisualStyleBackColor = true;
            // 
            // btnSelectAiColor
            // 
            this.btnSelectAiColor.Location = new System.Drawing.Point(103, 60);
            this.btnSelectAiColor.Name = "btnSelectAiColor";
            this.btnSelectAiColor.Size = new System.Drawing.Size(100, 23);
            this.btnSelectAiColor.TabIndex = 7;
            this.btnSelectAiColor.UseVisualStyleBackColor = true;
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Location = new System.Drawing.Point(131, 95);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(100, 23);
            this.btnSelectFont.TabIndex = 8;
            this.btnSelectFont.Text = "Select";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            // 
            // lblFontSample
            // 
            this.lblFontSample.AutoSize = true;
            this.lblFontSample.Location = new System.Drawing.Point(3, 11);
            this.lblFontSample.Name = "lblFontSample";
            this.lblFontSample.Size = new System.Drawing.Size(147, 16);
            this.lblFontSample.TabIndex = 9;
            this.lblFontSample.Text = "Message looks like this";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(15, 381);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 27);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(256, 12);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 12;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFontSample);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 97);
            this.panel1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectUserColor);
            this.groupBox1.Controls.Add(this.btnSelectAiColor);
            this.groupBox1.Controls.Add(this.lblUserColor);
            this.groupBox1.Controls.Add(this.lblAiColor);
            this.groupBox1.Location = new System.Drawing.Point(15, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Color";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(96, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(15, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 124);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 420);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserColor;
        private System.Windows.Forms.Label lblAiColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSelectUserColor;
        private System.Windows.Forms.ColorDialog colorDialogUser;
        private System.Windows.Forms.Button btnSelectAiColor;
        private System.Windows.Forms.ColorDialog colorDialogAI;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Label lblFontSample;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}