using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Praktika
{
    class DBProcedures
    {
        private SqlCommand command = new SqlCommand("", DBConnection.connection);
        // private SqlCommand command2 = new SqlCommand("", Configuration_Class.connection);
        //  private SqlCommand command3 = new SqlCommand("", Configuration_Class.connection);

        private void commandConfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

       
        public void Quality_control_Insert(string Date_Of_Hosting, Int32 criteria_ID, Int32 MTOK_ID, Int32 ocenka)
        {
            commandConfig("Quality_control_Insert");
            command.Parameters.AddWithValue("@Date_Of_Hosting", Date_Of_Hosting);
            command.Parameters.AddWithValue("@criteria_ID", criteria_ID);
            command.Parameters.AddWithValue("@MTOK_ID", MTOK_ID);
            command.Parameters.AddWithValue("@ocenka", ocenka);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Quality_control_Update(Int32 ID_quality_control, string Date_Of_Hosting, Int32 criteria_ID, Int32 MTOK_ID, Int32 ocenka)
        {
            commandConfig("Quality_control_updated");
            command.Parameters.AddWithValue("@ID_quality_control", ID_quality_control);
            command.Parameters.AddWithValue("@Date_Of_Hosting", Date_Of_Hosting);
            command.Parameters.AddWithValue("@criteria_ID", criteria_ID);
            command.Parameters.AddWithValue("@MTOK_ID", MTOK_ID);
            command.Parameters.AddWithValue("@ocenka", ocenka);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Quality_control_Delete(Int32 ID_quality_control)
        {
            commandConfig("Quality_control_delete");
            command.Parameters.AddWithValue("@ID_quality_control", ID_quality_control);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Kind_criteria_Insert(string Name_of_kind_criteria)
        {
            //using (SqlConnection Connection = new SqlConnection(connectionString));
            commandConfig("Kind_criteria_Insert");
            command.Parameters.AddWithValue("@Name_of_kind_criteria", Name_of_kind_criteria);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Kind_criteria_Updated(Int32 ID_Kind_criteria, string Name_of_kind_criteria)
        {
            commandConfig("Kind_criteria_Updated");
            command.Parameters.AddWithValue("@ID_Kind_criteria", ID_Kind_criteria);
            command.Parameters.AddWithValue("@Name_of_kind_criteria", Name_of_kind_criteria);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Kind_criteria_Delete(Int32 ID_Kind_criteria)
        {
            commandConfig("Kind_criteria_Delete");
            command.Parameters.AddWithValue("@ID_Kind_criteria", ID_Kind_criteria);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Criteria_Insert(string Name_criteria,  Int32 kind_criteria_ID, Int32 ranging)
        {
            commandConfig("criteria_insert");
            command.Parameters.AddWithValue("@Name_criteria", Name_criteria);
            command.Parameters.AddWithValue("@kind_criteria_ID", kind_criteria_ID);
            command.Parameters.AddWithValue("@ranging", ranging);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Criteria_Update(Int32 ID_criteria, string Name_criteria, Int32 kind_criteria_ID, Int32 ranging)
        {
            commandConfig("criteria_updated");
            command.Parameters.AddWithValue("@ID_criteria", ID_criteria);
            command.Parameters.AddWithValue("@Name_criteria", Name_criteria);
            command.Parameters.AddWithValue("@kind_criteria_ID", kind_criteria_ID);
            command.Parameters.AddWithValue("@ranging", ranging);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Criteria_Delete(Int32 ID_criteria)
        {

            commandConfig("criteria_delete");
            command.Parameters.AddWithValue("@ID_criteria", ID_criteria);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }



        public void Export_Word()
        {
            String result = (string)Clipboard.GetData(DataFormats.Text);
            string Q;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (*.doc|*.doc)";
            saveFileDialog.ShowDialog();
            File.WriteAllText(saveFileDialog.FileName, result);
        }

    }
}