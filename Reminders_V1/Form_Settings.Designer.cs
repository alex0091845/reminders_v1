namespace Reminders
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.lblTimeDisplay = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnUpdTime = new System.Windows.Forms.Button();
            this.tBCSettings = new System.Windows.Forms.TabControl();
            this.tPDateDisp = new System.Windows.Forms.TabPage();
            this.tPStartup = new System.Windows.Forms.TabPage();
            this.gBStartupRBs = new System.Windows.Forms.GroupBox();
            this.rBEveryTime = new System.Windows.Forms.RadioButton();
            this.cBKeepAppOpen = new System.Windows.Forms.CheckBox();
            this.rBFirstTime = new System.Windows.Forms.RadioButton();
            this.cBStartup = new System.Windows.Forms.CheckBox();
            this.tPFonts = new System.Windows.Forms.TabPage();
            this.lblFSExample = new System.Windows.Forms.Label();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.lblFSRemList = new System.Windows.Forms.Label();
            this.lblFontWarning = new System.Windows.Forms.Label();
            this.tBCSettings.SuspendLayout();
            this.tPDateDisp.SuspendLayout();
            this.tPStartup.SuspendLayout();
            this.gBStartupRBs.SuspendLayout();
            this.tPFonts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimeDisplay
            // 
            this.lblTimeDisplay.AutoSize = true;
            this.lblTimeDisplay.Font = new System.Drawing.Font("Roboto", 24F);
            this.lblTimeDisplay.Location = new System.Drawing.Point(1, 131);
            this.lblTimeDisplay.Name = "lblTimeDisplay";
            this.lblTimeDisplay.Size = new System.Drawing.Size(35, 39);
            this.lblTimeDisplay.TabIndex = 0;
            this.lblTimeDisplay.Text = "h";
            this.lblTimeDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(6, 25);
            this.txtInput.MaxLength = 32672;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(260, 27);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "yyyy/M/d";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(110, 173);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(217, 243);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblInput.Location = new System.Drawing.Point(6, 5);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(169, 17);
            this.lblInput.TabIndex = 4;
            this.lblInput.Text = "Input custom format here:";
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDisplay.Location = new System.Drawing.Point(6, 114);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(251, 17);
            this.lblDisplay.TabIndex = 4;
            this.lblDisplay.Text = "How dates will be displayed in the grid:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(6, 55);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(64, 13);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "\"y\" is YEAR";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(6, 73);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(79, 13);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "\"M\" is MONTH";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(6, 91);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(58, 13);
            this.lblDay.TabIndex = 5;
            this.lblDay.Text = "\"d\" is DAY";
            // 
            // btnUpdTime
            // 
            this.btnUpdTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdTime.Location = new System.Drawing.Point(6, 173);
            this.btnUpdTime.Name = "btnUpdTime";
            this.btnUpdTime.Size = new System.Drawing.Size(98, 23);
            this.btnUpdTime.TabIndex = 6;
            this.btnUpdTime.Text = "Update Time";
            this.btnUpdTime.UseVisualStyleBackColor = true;
            this.btnUpdTime.Click += new System.EventHandler(this.BtnUpdTime_Click);
            // 
            // tBCSettings
            // 
            this.tBCSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBCSettings.Controls.Add(this.tPDateDisp);
            this.tBCSettings.Controls.Add(this.tPStartup);
            this.tBCSettings.Controls.Add(this.tPFonts);
            this.tBCSettings.Location = new System.Drawing.Point(13, 9);
            this.tBCSettings.Name = "tBCSettings";
            this.tBCSettings.SelectedIndex = 0;
            this.tBCSettings.Size = new System.Drawing.Size(283, 228);
            this.tBCSettings.TabIndex = 7;
            // 
            // tPDateDisp
            // 
            this.tPDateDisp.Controls.Add(this.lblDisplay);
            this.tPDateDisp.Controls.Add(this.btnPreview);
            this.tPDateDisp.Controls.Add(this.btnUpdTime);
            this.tPDateDisp.Controls.Add(this.lblTimeDisplay);
            this.tPDateDisp.Controls.Add(this.lblDay);
            this.tPDateDisp.Controls.Add(this.txtInput);
            this.tPDateDisp.Controls.Add(this.lblMonth);
            this.tPDateDisp.Controls.Add(this.lblInput);
            this.tPDateDisp.Controls.Add(this.lblYear);
            this.tPDateDisp.Location = new System.Drawing.Point(4, 22);
            this.tPDateDisp.Name = "tPDateDisp";
            this.tPDateDisp.Padding = new System.Windows.Forms.Padding(3);
            this.tPDateDisp.Size = new System.Drawing.Size(275, 202);
            this.tPDateDisp.TabIndex = 0;
            this.tPDateDisp.Text = "Date Display";
            this.tPDateDisp.UseVisualStyleBackColor = true;
            // 
            // tPStartup
            // 
            this.tPStartup.Controls.Add(this.gBStartupRBs);
            this.tPStartup.Controls.Add(this.cBStartup);
            this.tPStartup.Location = new System.Drawing.Point(4, 22);
            this.tPStartup.Name = "tPStartup";
            this.tPStartup.Padding = new System.Windows.Forms.Padding(3);
            this.tPStartup.Size = new System.Drawing.Size(275, 202);
            this.tPStartup.TabIndex = 1;
            this.tPStartup.Text = "Startup";
            this.tPStartup.UseVisualStyleBackColor = true;
            // 
            // gBStartupRBs
            // 
            this.gBStartupRBs.Controls.Add(this.rBEveryTime);
            this.gBStartupRBs.Controls.Add(this.cBKeepAppOpen);
            this.gBStartupRBs.Controls.Add(this.rBFirstTime);
            this.gBStartupRBs.Location = new System.Drawing.Point(23, 23);
            this.gBStartupRBs.Name = "gBStartupRBs";
            this.gBStartupRBs.Size = new System.Drawing.Size(246, 94);
            this.gBStartupRBs.TabIndex = 4;
            this.gBStartupRBs.TabStop = false;
            // 
            // rBEveryTime
            // 
            this.rBEveryTime.AutoSize = true;
            this.rBEveryTime.Location = new System.Drawing.Point(6, 42);
            this.rBEveryTime.Name = "rBEveryTime";
            this.rBEveryTime.Size = new System.Drawing.Size(74, 17);
            this.rBEveryTime.TabIndex = 3;
            this.rBEveryTime.TabStop = true;
            this.rBEveryTime.Text = "Every time";
            this.rBEveryTime.UseVisualStyleBackColor = true;
            // 
            // cBKeepAppOpen
            // 
            this.cBKeepAppOpen.AutoSize = true;
            this.cBKeepAppOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBKeepAppOpen.Location = new System.Drawing.Point(6, 65);
            this.cBKeepAppOpen.Name = "cBKeepAppOpen";
            this.cBKeepAppOpen.Size = new System.Drawing.Size(240, 21);
            this.cBKeepAppOpen.TabIndex = 1;
            this.cBKeepAppOpen.Text = "Keep application open after alerts";
            this.cBKeepAppOpen.UseVisualStyleBackColor = true;
            // 
            // rBFirstTime
            // 
            this.rBFirstTime.AutoSize = true;
            this.rBFirstTime.Location = new System.Drawing.Point(6, 19);
            this.rBFirstTime.Name = "rBFirstTime";
            this.rBFirstTime.Size = new System.Drawing.Size(116, 17);
            this.rBFirstTime.TabIndex = 3;
            this.rBFirstTime.TabStop = true;
            this.rBFirstTime.Text = "First time of the day";
            this.rBFirstTime.UseVisualStyleBackColor = true;
            // 
            // cBStartup
            // 
            this.cBStartup.AutoSize = true;
            this.cBStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBStartup.Location = new System.Drawing.Point(6, 6);
            this.cBStartup.Name = "cBStartup";
            this.cBStartup.Size = new System.Drawing.Size(152, 21);
            this.cBStartup.TabIndex = 1;
            this.cBStartup.Text = "Alert user at startup";
            this.cBStartup.UseVisualStyleBackColor = true;
            this.cBStartup.CheckedChanged += new System.EventHandler(this.CBStartup_CheckedChanged);
            // 
            // tPFonts
            // 
            this.tPFonts.Controls.Add(this.lblFontWarning);
            this.tPFonts.Controls.Add(this.lblFSExample);
            this.tPFonts.Controls.Add(this.txtFontSize);
            this.tPFonts.Controls.Add(this.lblFSRemList);
            this.tPFonts.Location = new System.Drawing.Point(4, 22);
            this.tPFonts.Name = "tPFonts";
            this.tPFonts.Padding = new System.Windows.Forms.Padding(3);
            this.tPFonts.Size = new System.Drawing.Size(275, 202);
            this.tPFonts.TabIndex = 2;
            this.tPFonts.Text = "Fonts";
            this.tPFonts.UseVisualStyleBackColor = true;
            // 
            // lblFSExample
            // 
            this.lblFSExample.AutoSize = true;
            this.lblFSExample.Location = new System.Drawing.Point(7, 60);
            this.lblFSExample.Name = "lblFSExample";
            this.lblFSExample.Size = new System.Drawing.Size(71, 13);
            this.lblFSExample.TabIndex = 2;
            this.lblFSExample.Text = "Example Text";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(10, 27);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(33, 20);
            this.txtFontSize.TabIndex = 1;
            this.txtFontSize.TextChanged += new System.EventHandler(this.TxtFontSize_TextChanged);
            // 
            // lblFSRemList
            // 
            this.lblFSRemList.AutoSize = true;
            this.lblFSRemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFSRemList.Location = new System.Drawing.Point(7, 7);
            this.lblFSRemList.Name = "lblFSRemList";
            this.lblFSRemList.Size = new System.Drawing.Size(197, 17);
            this.lblFSRemList.TabIndex = 0;
            this.lblFSRemList.Text = "Font size of the reminders list:";
            // 
            // lblFontWarning
            // 
            this.lblFontWarning.AutoSize = true;
            this.lblFontWarning.ForeColor = System.Drawing.Color.Red;
            this.lblFontWarning.Location = new System.Drawing.Point(49, 30);
            this.lblFontWarning.Name = "lblFontWarning";
            this.lblFontWarning.Size = new System.Drawing.Size(141, 13);
            this.lblFontWarning.TabIndex = 3;
            this.lblFontWarning.Text = "Please enter a valid number!";
            this.lblFontWarning.Visible = false;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 277);
            this.Controls.Add(this.tBCSettings);
            this.Controls.Add(this.btnSaveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(324, 316);
            this.Name = "Form_Settings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.tBCSettings.ResumeLayout(false);
            this.tPDateDisp.ResumeLayout(false);
            this.tPDateDisp.PerformLayout();
            this.tPStartup.ResumeLayout(false);
            this.tPStartup.PerformLayout();
            this.gBStartupRBs.ResumeLayout(false);
            this.gBStartupRBs.PerformLayout();
            this.tPFonts.ResumeLayout(false);
            this.tPFonts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTimeDisplay;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Button btnUpdTime;
        private System.Windows.Forms.TabControl tBCSettings;
        private System.Windows.Forms.TabPage tPDateDisp;
        private System.Windows.Forms.TabPage tPStartup;
        private System.Windows.Forms.GroupBox gBStartupRBs;
        private System.Windows.Forms.RadioButton rBEveryTime;
        private System.Windows.Forms.RadioButton rBFirstTime;
        private System.Windows.Forms.CheckBox cBKeepAppOpen;
        private System.Windows.Forms.CheckBox cBStartup;
        private System.Windows.Forms.TabPage tPFonts;
        private System.Windows.Forms.Label lblFSExample;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.Label lblFSRemList;
        private System.Windows.Forms.Label lblFontWarning;
    }
}