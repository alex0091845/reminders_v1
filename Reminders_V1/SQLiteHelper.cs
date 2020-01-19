using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders
{
    public class SQLiteHelper
    {
        public static void AddDataRow(SQLiteConnection conn, DateTime dtValue, string txtDesc, string txtDays)
        {
            string cmdStr = "INSERT INTO Reminders (Date, Description, DaysBeforeToRemind) VALUES (@dt, @desc, @days)";
            conn.Open();
            SQLiteCommand addCmd = new SQLiteCommand(cmdStr, conn);
            addCmd.Parameters.AddWithValue("@dt", String.Format("{0:yyyy-MM-dd}", dtValue));
            addCmd.Parameters.AddWithValue("@desc", txtDesc);
            addCmd.Parameters.AddWithValue("@days", txtDays);
            addCmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
