using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reminders
{
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            InitializeComponent();
        }

        DateTime currTime = DateTime.Now;        

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            // Load settings string
            // Date Display Tab
            txtInput.Text = ReturnFString(); // Raw yyyy/M/d
            string formatString = "{0:" + txtInput.Text + "}";
            lblTimeDisplay.Text = String.Format(formatString, currTime);

            // Startup Tab
            cBStartup.Checked = Properties.Settings.Default.startup;
            if (Properties.Settings.Default.alertFrequency == "First time of the day")
            {
                rBFirstTime.Checked = true;
            }
            else if (Properties.Settings.Default.alertFrequency == "Every time")
            {
                rBEveryTime.Checked = true;
            }
            cBKeepAppOpen.Checked = Properties.Settings.Default.keepAppOpen;

            // Load Font Size
            try
            {
                txtFontSize.Text = Properties.Settings.Default.fontSizeRemList.ToString();
                lblFSExample.Font = new System.Drawing.Font(lblFSExample.Font.Name, Properties.Settings.Default.fontSizeRemList);
            }
            catch(Exception ex)
            {
                txtFontSize.Text = "8.25";
                lblFSExample.Font = new System.Drawing.Font(lblFSExample.Font.Name, 8.25F);
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            string formatString = "{0:" + txtInput.Text + "}";
            try
            {
                lblTimeDisplay.Text = String.Format(formatString, currTime);
            }
            catch
            {
                MessageBox.Show("Your input format is invalid!");
            }
        }        

        private void BtnUpdTime_Click(object sender, EventArgs e)
        {
            try
            {
                string formatString = "{0:" + txtInput.Text + "}";
                lblTimeDisplay.Text = String.Format(formatString, DateTime.Now);
            }
            catch
            {
                MessageBox.Show("Your input format is invalid!");
            }
            
        }

        private string ReturnFString()
        {
            string setString = Properties.Settings.Default.formatString;
            setString = setString.Split(':')[1];
            setString = setString.Split('}')[0];
            return setString;
        }

        private void CBStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (cBStartup.Checked == true)
            {
                gBStartupRBs.Enabled = true;
            }
            else
            {
                gBStartupRBs.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Date Display
            string formatString = "{0:" + txtInput.Text + "}";
            try
            {
                lblTimeDisplay.Text = String.Format(formatString, DateTime.Now);
                Properties.Settings.Default.formatString = "{0:" + txtInput.Text + "}";
            }
            catch (Exception ex)
            {
                tBCSettings.SelectedIndex = 0;
                MessageBox.Show(ex.ToString(), "Error");
            }

            // Startup
            Properties.Settings.Default.startup = cBStartup.Checked;
            if (rBFirstTime.Checked)
            {
                Properties.Settings.Default.alertFrequency = rBFirstTime.Text;
            }
            else
            {
                Properties.Settings.Default.alertFrequency = rBEveryTime.Text;
            }
            Properties.Settings.Default.keepAppOpen = cBKeepAppOpen.Checked;            

            // Fonts
            try
            {
                float userFontSize = float.Parse(txtFontSize.Text);
                lblFSExample.Font = new System.Drawing.Font(lblFSExample.Font.Name, userFontSize);
                Properties.Settings.Default.fontSizeRemList = userFontSize;
                Properties.Settings.Default.Save();
                MessageBox.Show("Settings successfully saved!", "Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void TxtFontSize_TextChanged(object sender, EventArgs e)
        {
            float userFontSize = 8.25F;
            if (!String.IsNullOrEmpty(txtFontSize.Text))
            {                
                try
                {
                    userFontSize = float.Parse(txtFontSize.Text);
                    lblFSExample.Font = new System.Drawing.Font(lblFSExample.Font.Name, userFontSize);
                    lblFontWarning.Visible = false;
                }
                catch
                {
                    lblFSExample.Font = new System.Drawing.Font(lblFSExample.Font.Name, userFontSize);
                    lblFontWarning.Visible = true;
                }
            }
            else
            {
                lblFSExample.Font = new System.Drawing.Font(lblFSExample.Font.Name, userFontSize);
                lblFontWarning.Visible = true;
            }
        }
    }
}
