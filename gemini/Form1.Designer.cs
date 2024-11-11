namespace gemini
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vistaMenu1 = new wyDay.Controls.VistaMenu(this.components);
            this.mniLoad = new System.Windows.Forms.MenuItem();
            this.mniSave = new System.Windows.Forms.MenuItem();
            this.mniSettings = new System.Windows.Forms.MenuItem();
            this.mniAbout = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.lblHoliday = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vistaMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.Location = new System.Drawing.Point(12, 33);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(959, 525);
            this.rtbOutput.TabIndex = 3;
            this.rtbOutput.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(900, 637);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(71, 72);
            this.btnSend.TabIndex = 2;
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInput.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 595);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(881, 114);
            this.txtInput.TabIndex = 0;
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(89, 3);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(121, 24);
            this.cmbModel.TabIndex = 5;
            // 
            // lblWarning
            // 
            this.lblWarning.Image = ((System.Drawing.Image)(resources.GetObject("lblWarning.Image")));
            this.lblWarning.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblWarning.Location = new System.Drawing.Point(308, 561);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(363, 29);
            this.lblWarning.TabIndex = 27;
            this.lblWarning.Text = "Tìm kiếm";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(900, 595);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 36);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // cmbOption
            // 
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Location = new System.Drawing.Point(216, 3);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(242, 24);
            this.cmbOption.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(9, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 27);
            this.label1.TabIndex = 32;
            this.label1.Text = "Model";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vistaMenu1
            // 
            this.vistaMenu1.ContainerControl = this;
            // 
            // mniLoad
            // 
            this.vistaMenu1.SetImage(this.mniLoad, ((System.Drawing.Image)(resources.GetObject("mniLoad.Image"))));
            this.mniLoad.Index = 0;
            this.mniLoad.Text = "Load";
            // 
            // mniSave
            // 
            this.vistaMenu1.SetImage(this.mniSave, ((System.Drawing.Image)(resources.GetObject("mniSave.Image"))));
            this.mniSave.Index = 1;
            this.mniSave.Text = "Save";
            // 
            // mniSettings
            // 
            this.vistaMenu1.SetImage(this.mniSettings, ((System.Drawing.Image)(resources.GetObject("mniSettings.Image"))));
            this.mniSettings.Index = 0;
            this.mniSettings.Text = "Settings";
            this.mniSettings.Click += new System.EventHandler(this.mniSettings_Click);
            // 
            // mniAbout
            // 
            this.vistaMenu1.SetImage(this.mniAbout, ((System.Drawing.Image)(resources.GetObject("mniAbout.Image"))));
            this.mniAbout.Index = 1;
            this.mniAbout.Text = "About";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniLoad,
            this.mniSave});
            this.menuItem1.Text = "File";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniSettings,
            this.mniAbout});
            this.menuItem4.Text = "Others";
            // 
            // lblHoliday
            // 
            this.lblHoliday.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblHoliday.Location = new System.Drawing.Point(464, 1);
            this.lblHoliday.Name = "lblHoliday";
            this.lblHoliday.Size = new System.Drawing.Size(507, 27);
            this.lblHoliday.TabIndex = 33;
            this.lblHoliday.Text = "Date";
            this.lblHoliday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 721);
            this.Controls.Add(this.lblHoliday);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOption);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Chatbot";
            ((System.ComponentModel.ISupportInitialize)(this.vistaMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label label1;
        private wyDay.Controls.VistaMenu vistaMenu1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mniLoad;
        private System.Windows.Forms.MenuItem mniSave;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem mniSettings;
        private System.Windows.Forms.MenuItem mniAbout;
        private System.Windows.Forms.Label lblHoliday;
    }
}

