using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(
           "Server = 89.179.240.226,63388; " +
           "Initial Catalog = Educational_institution; Persist Security Info = true; multipleactiveresultsets=True;" +
           "User ID = ArslanovKR; Password = \"K%5e#q\"");


        //b test 2232323
        //b github


        public SqlDependency Dependency = new SqlDependency();

        public DataTable dtQuality_control = new DataTable("Quality_control");
        public DataTable dtCriteria = new DataTable("Criteria");
        public DataTable dtKind_criteria = new DataTable("Kind_criteria");
        public DataTable dtcb_for_Criteria = new DataTable("cb_for_Criteria");
        public DataTable dtSopostavlenie = new DataTable("Sopostavlenie");
        public DataTable dtcbTraning_Area = new DataTable("Traning_Area");
        public DataTable dtcbTerritory_Аudiences = new DataTable("Territory_Аudiences");
        public DataTable dtcbMaterial_Provision = new DataTable("Material_Provision");
        public DataTable dtTabel = new DataTable("MTOK");


        public static string
            qrQuality_control =
                "SELECT [ID_quality_control], [Date_Of_Hosting] from [dbo].[Quality_control] inner join [dbo].[Criteria] on [dbo].[Quality_control].[criteria_ID] = [dbo].[Criteria].[ID_criteria] inner join" +
                "[dbo].[MTOK] on [dbo].[Quality_control].[MTOK_ID] = [dbo].[MTOK].[ID_MTOK]",
            qrMTOK =
                "SELECT [ID_MTOK], [Position_X], [Position_Y], [Width], [Height], [Inventory_Number] from [dbo].[MTOK] inner join [dbo].[Territory_Аudiences] on [dbo].[MTOK].[Territory_Аudiences_ID]" +
                "= [dbo].[Territory_Аudiences].[ID_Territory_Аudiences] inner join [dbo].[Characteristic_MO] on [dbo].[MTOK].[Characteristic_MO_ID] = [dbo].[Characteristic_MO].[ID_Characteristic_MO]" +
                "inner join [dbo].[MTOK] on [dbo].[MROK].[MTOK_ID] = [dbo].[MTOK].[ID_MTOK]",
            qrCriteria = "SELECT [ID_Criteria],[Name_criteria], [kind_criteria_ID], [ranging], " +
                         "[Name_of_kind_criteria] as \"Название вида критерия\" from [dbo].[Criteria] " +
                         "inner join [dbo].[Kind_criteria] on [dbo].[Kind_criteria].[ID_Kind_criteria] = [dbo].[Criteria].[kind_criteria_ID]",
            cb_for_Criteria =
                "SELECT [ID_Kind_criteria], [Name_of_kind_criteria] as Criteria_Info from [dbo].[Kind_criteria]",
            qrKind_criteria = "SELECT [ID_Kind_criteria], [Name_of_kind_criteria] from [dbo].[Kind_criteria]",
            qrTerritory_Аudiences =
                "SELECT [ID_Territory_Аudiences], [Number_Cabinet], [Position_X], [Position_Y], [Width], [Height] from [dbo].[Territory_Аudiences]" +
                "inner join [dbo].[Color] on [dbo].[Territory_Аudiences].[Color_ID] = [dbo].[Color].[ID_Color] inner join [dbo].[Training_Area] on [dbo].[Territory_Аudiences].[Training_Area_ID] = [dbo].[Training_Area].[ID_Training_Area_ID]",
            qr_cb_Traning_Area =
                "SELECT Traning_Area.ID_Training_Area, Traning_Area.Full_Name FROM dbo.Traning_Area",
            qr_cb_Territory_Аudiences =
                "SELECT Territory_Аudiences.ID_Territory_Аudiences, Territory_Аudiences.Number_Cabinet FROM dbo.Territory_Аudiences INNER JOIN dbo.Traning_Area ON Territory_Аudiences.Traning_Area_ID = Traning_Area.ID_Training_Area ",
            qr_cb_Material_Provision =
                "SELECT\r\n  Material_Provision.ID_Material_Provision, (Material_Provision.Name_Material_Provision + ' ' + MTOK.Inventory_Number) AS 'full' FROM dbo.MTOK\r\nINNER JOIN dbo.Characteristic_MO\r\n  ON MTOK.Characteristic_MO_ID = Characteristic_MO.ID_Characteristic_MO\r\nINNER JOIN dbo.Material_Provision\r\n  ON Characteristic_MO.Material_Provisions_ID = Material_Provision.ID_Material_Provision ",
            qr_Cb_Criteria =
                "SELECT [ID_Criteria],([Name_criteria] + ' ' + [Name_of_kind_criteria] + ' ' + CONVERT(VARCHAR(MAX), Criteria.ranging)) as 'criter', [kind_criteria_ID] " +
                " from [dbo].[Criteria] " +
                "inner join [dbo].[Kind_criteria] on [dbo].[Kind_criteria].[ID_Kind_criteria] = [dbo].[Criteria].[kind_criteria_ID]",
            qr_dg_qual =
                "SELECT\r\n  Quality_control.ID_quality_control, Quality_control.criteria_ID, Criteria.Name_criteria\r\n  ,Kind_criteria.Name_of_kind_criteria\r\n ,Criteria.ranging\r\n ,Quality_control.ocenka\r\nFROM dbo.Quality_control\r\nINNER JOIN dbo.Criteria\r\n  ON Quality_control.criteria_ID = Criteria.ID_criteria\r\nINNER JOIN dbo.MTOK\r\n  ON Quality_control.MTOK_ID = MTOK.ID_MTOK\r\nINNER JOIN dbo.Kind_criteria\r\n  ON Criteria.kind_criteria_ID = Kind_criteria.ID_Kind_criteria ",
            qr_Tabel =
                $"SELECT\r\n  Traning_Area.Full_Name\r\n ,Territory_Аudiences.Number_Cabinet\r\n ,Material_Provision.Name_Material_Provision\r\n ,MTOK.Inventory_Number\r\n  , STUFF(\r\n  (\r\n  SELECT CHAR(10) + c.Name_criteria + ' | ' +kc.Name_of_kind_criteria + ' | ' + CONVERT(VARCHAR(MAX), c.ranging) + ' | ' + CONVERT(VARCHAR(MAX), qc.ocenka)    FROM Quality_control qc \r\n  JOIN Criteria c ON qc.criteria_ID = c.ID_criteria\r\n  JOIN Kind_criteria kc ON c.kind_criteria_ID = kc.ID_Kind_criteria\r\n  WHERE\r\n    ID_MTOK = qc.MTOK_ID AND qc.Date_Of_Hosting = '{DateTime.Now.ToShortDateString()}'\r\n  FOR XML PATH('')\r\n  )\r\n  ,1, 1, ''\r\n  ) xz\r\nFROM dbo.MTOK\r\nINNER JOIN dbo.Characteristic_MO\r\n  ON MTOK.Characteristic_MO_ID = Characteristic_MO.ID_Characteristic_MO\r\nINNER JOIN dbo.Material_Provision\r\n  ON Characteristic_MO.Material_Provisions_ID = Material_Provision.ID_Material_Provision\r\nINNER JOIN dbo.Territory_Аudiences\r\n  ON MTOK.Territory_Аudiences_ID = Territory_Аudiences.ID_Territory_Аudiences\r\nINNER JOIN dbo.Traning_Area\r\n  ON Territory_Аudiences.Traning_Area_ID = Traning_Area.ID_Training_Area";


        private static SqlCommand command = new SqlCommand("", connection);


        public static Int32 IDRecord, IDUser;
        //создание зависимости
        //public SqlDependency dependency = new SqlDependency();
        //заполнние через зависимость
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            command.Notification = null;
            Dependency.AddCommandDependency(command);
            SqlDependency.Start(connection.ConnectionString);
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public void Tabel_Fill() => dtFill(dtTabel, qr_Tabel);

        public void Quality_controlFill()
        {
            dtFill(dtQuality_control, qrQuality_control);
        }

        public void DG_Quality_controlFill(int id)
        {
            dtFill(dtQuality_control, qr_dg_qual + $" WHERE [dbo].[MTOK].[Territory_Аudiences_ID] = {id} and Quality_control.Date_Of_Hosting = '{DateTime.Now.ToShortDateString()}'");
        }

        public void CriteriaFill(int id_kind_criter)
        {
            if (id_kind_criter > 0)
                dtFill(dtCriteria, qrCriteria + $" WHERE [dbo].[Kind_criteria].[ID_Kind_criteria] = {id_kind_criter}");
            else
                dtFill(dtCriteria, qrCriteria);
        }
        
        public void Criteria_CbFill() =>
            dtFill(dtCriteria, qr_Cb_Criteria);

        public void cb_Traning_Area() => dtFill(dtcbTraning_Area, qr_cb_Traning_Area);

        public void cb_Territory_Аudiences(int id) => dtFill(dtcbTerritory_Аudiences, qr_cb_Territory_Аudiences + $" WHERE Traning_Area.ID_Training_Area = {id}");
        
        public void cb_Material_Provision(int id) => dtFill(dtcbMaterial_Provision, qr_cb_Material_Provision + $" WHERE MTOK.Territory_Аudiences_ID = {id}");

        public void Kind_criteriaFill()
        {
            dtFill(dtKind_criteria, qrKind_criteria);
        }
        public void cb_for_CriteriaFill()
        {
            dtFill(dtcb_for_Criteria, cb_for_Criteria);
        }
        public void SopostavlenieFill()
        {
            dtFill(dtSopostavlenie, qrQuality_control);
        }

    }
}