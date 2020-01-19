using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Reminders
{
    public partial class RemindersMain : Form
    {
        public RemindersMain()
        {
            InitializeComponent();
        }

        string dateFString = Properties.Settings.Default.formatString;
        static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string connStr = String.Format(@"Data Source={0}\RemindersData\RemindersData.db;Version=3",
            appDataPath);
        string origDesc = null;
        string origDays = null;
        DateTime origDate = new DateTime(0);
        bool editMode = false;
        bool shown = false;

        //////////////////////////////////
        // TABLE COLUMN INDEX REFERENCE://
        // 0 = ReminderId               //
        // 1 = Date                     //
        // 2 = Description              //
        // 3 = RemindDate               //
        // 4 = DaysBeforeToRemind       //
        //////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            string dataPath = appDataPath + "\\RemindersData\\RemindersData.db";
            InitializeSaveData(dataPath);
            dGVMain.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", Properties.Settings.Default.fontSizeRemList);
            dGVMain.RowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", Properties.Settings.Default.fontSizeRemList);

            SQLiteConnection conn = new SQLiteConnection(connStr);
            string arg = "";
            try
            {
                arg = Environment.GetCommandLineArgs()[1];
            }
            catch (Exception) { }
            try
            {
                conn.Open();
                FillGridData();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message + "Database connection error! Please try installing again, " +
                    "or report the error to us by sending us a screenshot of the error.", "SQL Error");
            }            
            if (arg == "Startup")
            {
                if (Properties.Settings.Default.startup == true)
                {
                    GetEventsAndRemindUser();
                    if (Properties.Settings.Default.keepAppOpen == false)
                        Application.Exit();
                }                    
            }            
        }

        private void InitializeSaveData(string dataPath)
        {
            // create if it's not there already
            if(!File.Exists(dataPath))
            {
                SQLiteConnection.CreateFile(dataPath);
                SQLiteConnection conn = new SQLiteConnection(connStr);
                conn.Open();
                string createCmdStr = "CREATE TABLE Reminders (ReminderId INTEGER, Date TEXT, Description TEXT, " +
                    "RemindDate TEXT, DaysBeforeToRemind INTEGER)";
                SQLiteCommand createCmd = new SQLiteCommand(createCmdStr, conn);
                createCmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void FillGridData()
        {            
            dateFString = Properties.Settings.Default.formatString;
            SQLiteConnection conn = new SQLiteConnection(connStr);
            SQLiteCommand selectCmd = new SQLiteCommand("SELECT * FROM Reminders ORDER BY Date ASC", conn);            
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectCmd);
            da.Fill(dt);
            dGVMain.DataSource = dt;
            FormatAndResize();
        }

        private void GetEventsAndRemindUser()
        {
            DateTime today = DateTime.Now.Date;
            DateTime pickedDate = new DateTime();
            TimeSpan diffDaysTS;
            SQLiteConnection conn = new SQLiteConnection(connStr);
            Boolean isTodayOrNull;

            for (int i = 0; i < dGVMain.Rows.Count; i++)
            {
                if (dGVMain[1, i].Value != null)
                {
                    // checks to see if can convert to date first (if not, it's null)
                    try
                    {
                        string dGVdate = DateTime.Parse(dGVMain[3, i].Value.ToString()).ToShortDateString();
                        if (dGVdate == today.ToShortDateString())
                        {
                            // the user has already been reminded today
                            isTodayOrNull = false;
                        }
                        else
                        {
                            // the user had been reminded some time in the past, but not today
                            isTodayOrNull = true;
                        }
                    }
                    // else, it's not, and it's null
                    catch (Exception)
                    {
                        isTodayOrNull = true;
                    }
                    // User setting alert every time is true, then:
                    if (Properties.Settings.Default.alertFrequency == "Every time")
                        isTodayOrNull = true;
                    // if it's not today or it's null, then execute
                    if (isTodayOrNull == true)
                    {
                        pickedDate = DateTime.Parse(dGVMain.Rows[i].Cells[1].Value.ToString());
                        diffDaysTS = pickedDate - today;
                        int targetRemDays = Int32.Parse(dGVMain.Rows[i].Cells[4].Value.ToString());
                        int diffDays = diffDaysTS.Days;
                        if (diffDays <= targetRemDays && diffDays > 1)
                        {
                            string alertMsg = String.Format("In {0} days on {1}: {2}", diffDays.ToString(), pickedDate.ToShortDateString(), dGVMain.Rows[i].Cells[2].Value.ToString()); //To SHORT DATE
                            MessageBox.Show(alertMsg, "Agenda alert", MessageBoxButtons.OK);
                        }
                        else if (diffDays == 1)
                        {
                            string alertMsg = String.Format("Tomorrow, on {0}: {1}", pickedDate.ToShortDateString(), dGVMain.Rows[i].Cells[2].Value.ToString());
                            MessageBox.Show(alertMsg, "Agenda alert", MessageBoxButtons.OK);
                        }
                        else if (diffDays == 0)
                        {
                            string alertMsg = String.Format("Today: {0}", dGVMain.Rows[i].Cells[2].Value.ToString());
                            MessageBox.Show(alertMsg, "Agenda alert", MessageBoxButtons.OK);
                        }
                        if (diffDays <= targetRemDays && diffDays >= 0)
                        {
                            SQLiteCommand insEvtRmdDtCmd = new SQLiteCommand("UPDATE Reminders SET RemindDate = @rmdDate WHERE ReminderId = @evtId", conn);
                            insEvtRmdDtCmd.Parameters.AddWithValue("@rmdDate", today);
                            insEvtRmdDtCmd.Parameters.AddWithValue("@evtId", Int32.Parse(dGVMain[0, i].Value.ToString()));
                            conn.Open();
                            insEvtRmdDtCmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CheckTxtPresence() == true)
            {
                SQLiteConnection conn = new SQLiteConnection(connStr);
                try
                {
                    SQLiteHelper.AddDataRow(conn, dateTimePicker.Value, txtDesc.Text, txtDays.Text);
                    FillGridData();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "SQLite failed!");
                }
            }
            else
                MessageBox.Show("Please enter a valid description AND number of days before to remind" +
                    " you of this event for this reminder memo!");
        }

        private void AddDataRow(SQLiteConnection conn, DateTime dtValue)
        {
            string cmdStr = "INSERT INTO Reminders (Date, Description, DaysBeforeToRemind) VALUES (@dt, @desc, @days)";
            conn.Open();
            SQLiteCommand addCmd = new SQLiteCommand(cmdStr, conn);
            addCmd.Parameters.AddWithValue("@dt", String.Format("{0:yyyy-MM-dd}", dtValue));
            addCmd.Parameters.AddWithValue("@desc", txtDesc.Text);
            addCmd.Parameters.AddWithValue("@days", txtDays.Text);
            addCmd.ExecuteNonQuery();
            conn.Close();
        }
        
        private bool CheckTxtPresence()
        {
            bool isTxtDaysValid = false;
            try
            {
                int tempDays = Int32.Parse(txtDays.Text.ToString());
                if (tempDays >= 0)
                    isTxtDaysValid = true;
            }
            catch { }
            if (string.IsNullOrWhiteSpace(txtDesc.Text) || isTxtDaysValid == false)
            {
                return false;
            }
            else
                return true;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            List<String> list = new List<String>();
            SQLiteConnection conn = new SQLiteConnection(connStr);
            string cmdStr = "DELETE FROM Reminders WHERE ReminderId = @j";
            for (int i = 0; i < dGVMain.SelectedRows.Count; i++)
            {
                string itemId = dGVMain.SelectedRows[i].Cells[0].Value.ToString();
                list.Add(itemId);
            }
            conn.Open();
            foreach (string i in list)
            {
                SQLiteCommand rmvCmd = new SQLiteCommand(cmdStr, conn);
                rmvCmd.Parameters.AddWithValue("@j", Int32.Parse(i));
                rmvCmd.ExecuteNonQuery();
            }
            FillGridData();
            conn.Close();
        }

        private void DGVMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVMain.SelectedRows.Count > 0 && dGVMain.SelectedRows.Count < 2)
            {
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
            }
            else if (dGVMain.SelectedRows.Count > 1)
            {
                btnDel.Enabled = true;
                btnEdit.Enabled = false;
            }
        }

        private void TxtDesc_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDesc.Text) || String.IsNullOrWhiteSpace(txtDesc.Text))
            {
                btnAdd.Enabled = false;
                btnCfrmEdits.Enabled = false;
                lblWarnDesc.Visible = true;
            }
            else
            {
                btnEdit.Enabled = true; // ?
                lblWarnDesc.Visible = false;
                if (editMode == true)
                {
                    btnAdd.Enabled = false;
                    btnCnclEdits.Enabled = true;
                    btnCfrmEdits.Enabled = true;

                    // check if the new value is the same as the original
                    btnCfrmEdits.Enabled = checkChanged(true, true, true);
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtDays.Text))
                    {
                        btnAdd.Enabled = true;
                        btnCnclEdits.Enabled = false;
                        btnCfrmEdits.Enabled = false;
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // format the dates first
            String extractedDateFormat = dateFString.Trim(new char[]{'{', '0', ':', '}' });
            dateTimePicker.Value = DateTime.ParseExact(dGVMain.SelectedRows[0].Cells[1].Value.ToString(), extractedDateFormat, null);
            txtDesc.Text = dGVMain.SelectedRows[0].Cells[2].Value.ToString();
            txtDays.Text = dGVMain.SelectedRows[0].Cells[4].Value.ToString();

            // Set the original data we want to compare to so we can enable/disable
            // the confirm edits button accordingly.
            origDate = dateTimePicker.Value;
            origDesc = txtDesc.Text;
            origDays = txtDays.Text;

            // Days = Days Before Reminding
            btnAdd.Enabled = false;
            btnCnclEdits.Enabled = true;
            btnCfrmEdits.Enabled = false;
            editMode = true;
        }

        private void BtnCfrmEdits_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDays.Text))
            {
                if (!String.IsNullOrEmpty(txtDesc.Text) || !String.IsNullOrWhiteSpace(txtDesc.Text))
                    btnAdd.Enabled = true;
                int id = Int32.Parse(dGVMain.SelectedRows[0].Cells[0].Value.ToString());
                string desc = txtDesc.Text;
                string days = txtDays.Text;
                DateTime date = dateTimePicker.Value;
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteCommand editCmd = new SQLiteCommand("UPDATE Reminders SET Description = @desc, Date = @date, DaysBeforeToRemind = @days WHERE ReminderId = @editId", conn);
                editCmd.Parameters.AddWithValue("@desc", desc);
                editCmd.Parameters.AddWithValue("@date", String.Format("{0:yyyy-MM-dd}", date));
                editCmd.Parameters.AddWithValue("@days", days);
                editCmd.Parameters.AddWithValue("@editId", id);
                conn.Open();
                editCmd.ExecuteNonQuery();
                conn.Close();
                FillGridData();
                btnCfrmEdits.Enabled = false;
                btnCnclEdits.Enabled = false;
                editMode = false;
            }
            else
            {
                MessageBox.Show("Make sure you have a valid number of days before the event " +
                    "to remind you of it!");
            }
        }

        private void BtnCnclEdits_Click(object sender, EventArgs e)
        {
            editMode = false;
            if (!String.IsNullOrEmpty(txtDesc.Text) || !String.IsNullOrWhiteSpace(txtDesc.Text))
                btnAdd.Enabled = true;
            DateTime itemDate = DateTime.Parse(dGVMain.SelectedRows[0].Cells[1].Value.ToString());
            string itemDesc = dGVMain.SelectedRows[0].Cells[2].Value.ToString();
            string itemDays = dGVMain.SelectedRows[0].Cells[4].Value.ToString();
            txtDesc.Text = itemDesc;
            dateTimePicker.Value = itemDate;
            txtDays.Text = itemDays;
            btnCnclEdits.Enabled = false;
            btnCfrmEdits.Enabled = false;
        }

        private void SettingsStripMenuItem_Click(object sender, EventArgs e){
            Form fS = new Form_Settings();
            fS.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e){
            FillGridData();
        }

        private void FormatAndResize(){
            float dGVFontSize = Properties.Settings.Default.fontSizeRemList;
            int dateWidth = Properties.Settings.Default.dateWidth;
            int descWidth = Properties.Settings.Default.descWidth;
            int daysWidth = Properties.Settings.Default.daysWidth;
            foreach (DataGridViewRow row in dGVMain.Rows)
            {
                DateTime date = Convert.ToDateTime(row.Cells[1].Value.ToString());
                String newDate = String.Format(dateFString, date);
                row.Cells[1].Value = newDate;
                row.DefaultCellStyle.Font = new Font(lblDate.Font.Name, dGVFontSize, GraphicsUnit.Point);
            }
            dGVMain.Columns[0].Visible = false; //ReminderId needs to be invisible
            dGVMain.Columns[3].Visible = false; //RemindDate
            if(shown)
            {
                dGVMain.Columns[1].Width = dateWidth; //Date
                dGVMain.Columns[2].Width = descWidth; //Extend the width of the description column
                dGVMain.Columns[4].Width = daysWidth;
            }
        }

        private void dGVMain_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int dateWidth = Properties.Settings.Default.dateWidth;
            int descWidth = Properties.Settings.Default.descWidth;
            int daysWidth = Properties.Settings.Default.daysWidth;
            switch (e.Column.Name)
            {
                case "Date":
                    Properties.Settings.Default.dateWidth = e.Column.Width;
                    break;
                case "Description":
                    Properties.Settings.Default.descWidth = e.Column.Width;
                    break;
                case "DaysBeforeToRemind":
                    Properties.Settings.Default.daysWidth = e.Column.Width;
                    break;
            }
            if (shown)
                Properties.Settings.Default.Save();
        }

        private void RemindersMain_Shown(object sender, EventArgs e)
        {
            shown = true;
            FormatAndResize();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDays.Text) && !String.IsNullOrEmpty(txtDesc.Text))
            {
                btnAdd.Enabled = true;
                if(editMode == true)
                {
                    // check if the new value is the same as the original
                    btnCfrmEdits.Enabled = checkChanged(true, true, true);
                }
            }
            else btnAdd.Enabled = false;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(editMode == true)
            {
                // check if the new value is the same as the original
                btnCfrmEdits.Enabled = checkChanged(true, true, true);
            }
        }

        /** 
         * Checking for whether any of the properties has changed
         * */
        private bool checkChanged(bool checkDate, bool checkDesc, bool checkDays)
        {
            bool dateChanged, descChanged, daysChanged;
            dateChanged = descChanged = daysChanged = false;

            if (checkDate && !dateTimePicker.Value.Equals(origDate)) dateChanged = true;
            if (checkDesc && !txtDesc.Text.Equals(origDesc)) descChanged = true;
            if (checkDays && !txtDays.Text.Equals(origDays)) daysChanged = true;

            return dateChanged || descChanged || daysChanged;
        }
    }
}