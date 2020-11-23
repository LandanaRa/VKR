using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika

{
    class Configuration_Class
    {
        public event Action<DataTable> server_Collection;
        public event Action<DataTable> Data_Base_Collection;
        public event Action<bool> connection_checked;

        public string DS = "Empty", IC = "Empty";
        public string ds = "";


        public static SqlConnection connection = new SqlConnection();

        public void SQL_Server_Configuration_get()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            try
            {
                DS = key.GetValue("DS").ToString();
                IC = key.GetValue("IC").ToString();
            }
            catch
            {
                DS = "Empty";
                IC = "Empty";
            }
            finally
            {
                connection.ConnectionString = "Data Source = " + DS + "; Initial Catalog = " + IC + "; Integrated Security = true;";

            }
        }

        public void SQL_Server_Configuration_Set(string ds, string ic)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            key.SetValue("DS", ds);//Запись значения в переменную реестра
            key.SetValue("IC", ic);
            SQL_Server_Configuration_get();
        }

        public void SQL_Server_Enumurator()
        {
            SqlDataSourceEnumerator sourceEnumerator = SqlDataSourceEnumerator.Instance;
            server_Collection(sourceEnumerator.GetDataSources());
        }

        public void SQL_Data_Base_Checking()
        {
            connection.ConnectionString = "Data source = " + ds + "; " + "Initial Catalog = master; Integrated Security = true";
            try
            {
                connection.Open();
                connection_checked(true);
            }
            catch

            {
                connection_checked(false);
            }
            finally
            {
                connection.Close();
            }

        }

        public void SQL_Data_Base_Collection()
        {
            SqlCommand command = new SqlCommand("select name from sys.databases " + "where name not in ('master','tempdb','model','msdb')", connection);
            try
            {
                connection.Open();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                Data_Base_Collection(table);
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
        }
    }
}