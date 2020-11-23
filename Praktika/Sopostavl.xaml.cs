using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Praktika
{
    /// <summary>
    /// Interaction logic for Sopostavl.xaml
    /// </summary>
    public partial class Sopostavl : Window
    {
        //Глобальные переменные
        private int g_ID_Kind_criteria = 0, g_ID_Training_Area = 0, g_ID_Territory_Аudiences = 0, mtok_id, g_range, g_ID_Material_Provision = 0;

        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public Sopostavl()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qr_dg_qual;
            cbFill_ID_Training_Area();
        }

        private void cbFill_ID_Training_Area()
        {
            DBConnection connection = new DBConnection();
            connection.cb_Traning_Area();
            cb_ID_Training_Area.ItemsSource = connection.dtcbTraning_Area.DefaultView;
            cb_ID_Training_Area.SelectedValuePath = "ID_Training_Area";
            cb_ID_Training_Area.DisplayMemberPath = "Full_Name";
        }

        private void cbFill_ID_Territory_Аudiences()
        {
            DBConnection connection = new DBConnection();
            connection.cb_Territory_Аudiences(g_ID_Training_Area);
            cb_ID_Territory_Аudiences.ItemsSource = connection.dtcbTerritory_Аudiences.DefaultView;
            cb_ID_Territory_Аudiences.SelectedValuePath = "ID_Territory_Аudiences";
            cb_ID_Territory_Аudiences.DisplayMemberPath = "Number_Cabinet";
        }

        private void cbFill_ID_Material_Provision()
        {
            DBConnection connection = new DBConnection();
            connection.cb_Material_Provision(g_ID_Territory_Аudiences);
            cb_ID_Material_Provision.ItemsSource = connection.dtcbMaterial_Provision.DefaultView;
            cb_ID_Material_Provision.SelectedValuePath = "ID_Material_Provision";
            cb_ID_Material_Provision.DisplayMemberPath = "full";
        }

        //private void cbFill_ID_Kind_criteria()
        //{
        //    DBConnection connection = new DBConnection();
        //    connection.Kind_criteriaFill();
        //    cb_kind_criteria_ID.ItemsSource = connection.dtKind_criteria.DefaultView;
        //    cb_kind_criteria_ID.SelectedValuePath = "ID_Kind_criteria";
        //    cb_kind_criteria_ID.DisplayMemberPath = "Name_of_kind_criteria";
        //}

        private void cbFill_ID_Criteria()
        {
            DBConnection connection = new DBConnection();
            connection.Criteria_CbFill();
            cb_ID_Criteria.ItemsSource = connection.dtCriteria.DefaultView;
            cb_ID_Criteria.SelectedValuePath = "ID_Criteria";
            cb_ID_Criteria.DisplayMemberPath = "criter";
        }

        //private void cb_kind_criteria_ID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    lbl_ID_Criteria.IsEnabled = true;
        //    cb_ID_Criteria.IsEnabled = true;
        //    g_ID_Kind_criteria = Convert.ToInt32(cb_kind_criteria_ID.SelectedValue);
        //    cbFill_ID_Criteria();
        //}

        private void cb_ID_Material_Provision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_ID_Criteria.IsEnabled = true;
            cb_ID_Criteria.IsEnabled = true;
            lbl_ocenka.IsEnabled = true;
            cb_ocenka.IsEnabled = true;

            if (cb_ID_Material_Provision.SelectedValue == null)
            {
                g_ID_Material_Provision = 0;
                lbl_ID_Criteria.IsEnabled = false;
                cb_ID_Criteria.IsEnabled = false;
                lbl_ocenka.IsEnabled = false;
                cb_ocenka.IsEnabled = false;
                cb_ID_Criteria.SelectedValue = -1;
                lbl_ocenka.Content = "Оценка:";
                cb_ocenka.Value = 0;
                return;
            }   
            g_ID_Material_Provision = Convert.ToInt32(cb_ID_Material_Provision.SelectedValue.ToString());
            cbFill_ID_Criteria();
            dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qr_dg_qual = qr;
                connection.DG_Quality_controlFill(g_ID_Territory_Аudiences);
                connection.Dependency.OnChange += Dependency_OnChange;
                dg_Sopostavl.ItemsSource = connection.dtQuality_control.DefaultView;
                dg_Sopostavl.Columns[0].Visibility = Visibility.Collapsed;
                dg_Sopostavl.Columns[1].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void cb_ID_Criteria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_ID_Criteria.SelectedValue == null)
            {
                cb_ID_Criteria.SelectedValue = -1;
                return;
            }

            DBConnection connection = new DBConnection();
           
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = $"SELECT\r\n  Criteria.ranging\r\nFROM dbo.Criteria\r\n  WHERE ID_criteria = {Convert.ToInt32(cb_ID_Criteria.SelectedValue.ToString())}";
            try
            {
                DBConnection.connection.Open();
                int range = Convert.ToInt32(command.ExecuteScalar().ToString());
                DBConnection.connection.Close();
                lbl_ocenka.Content = "Оценка от 0 до " + range.ToString() + " :";
                cb_ocenka.Maximum = range;
                g_range = range;
                if (cb_ocenka.Value > range) cb_ocenka.Value = 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                bt_MainWindow_Click(sender, e);
            }
        }

        private void dg_Sopostavl_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_criteria"):
                    e.Column.Header = "Название критерия";
                    break;
                case ("ranging"):
                    e.Column.Header = "Ранжировка от 0 до";
                    break;
                case ("ocenka"):
                    e.Column.Header = "Оценка";
                    break;
                case ("Name_of_kind_criteria"):
                    e.Column.Header = "Название главного критерия";
                    break;
            }
        }

        private void bt_Sopostav_Click(object sender, RoutedEventArgs e)
        {
            if (cb_ocenka.Value > g_range || cb_ID_Criteria.SelectedValue == null ||
                Convert.ToInt32(cb_ID_Criteria.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("Поля пусты!");
                return;
            }
            Mtok_Id();
            procedures.Quality_control_Insert(DateTime.Now.ToShortDateString(), Convert.ToInt32(cb_ID_Criteria.SelectedValue.ToString()), mtok_id,
                Convert.ToInt32(cb_ocenka.Value.ToString()));
            mtok_id = 0;
            cb_ocenka.Value = 0;
            cb_ID_Criteria.SelectedValue = -1;
        }

        private void Mtok_Id()
        {
            SqlCommand command = new SqlCommand("", DBConnection.connection);

            command.CommandText =
                $"SELECT\r\n  MTOK.ID_MTOK\r\nFROM dbo.MTOK\r\nINNER JOIN dbo.Characteristic_MO\r\n  ON MTOK.Characteristic_MO_ID = Characteristic_MO.ID_Characteristic_MO\r\nWHERE Characteristic_MO.Material_Provisions_ID = {g_ID_Material_Provision}";
            try
            {
                DBConnection.connection.Open();
                mtok_id = Convert.ToInt32(command.ExecuteScalar().ToString());
                DBConnection.connection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {
            if (cb_ocenka.Value > g_range || cb_ID_Criteria.SelectedValue == null ||
                Convert.ToInt32(cb_ID_Criteria.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("Поля пусты!");
                return;
            }
            Mtok_Id();
            DataRowView ID = (DataRowView)dg_Sopostavl.SelectedItems[0];
            procedures.Quality_control_Update(Convert.ToInt32(ID["ID_quality_control"]), DateTime.Now.ToShortDateString(), Convert.ToInt32(cb_ID_Criteria.SelectedValue.ToString()), mtok_id,
                Convert.ToInt32(cb_ocenka.Value.ToString()));
            mtok_id = 0;
            cb_ocenka.Value = 0;
            cb_ID_Criteria.SelectedValue = -1;
        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (cb_ocenka.Value > g_range || cb_ID_Criteria.SelectedValue == null ||
                Convert.ToInt32(cb_ID_Criteria.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("Не выбрана запись!");
                return;
            }
            DataRowView ID = (DataRowView)dg_Sopostavl.SelectedItems[0];
            procedures.Quality_control_Delete(Convert.ToInt32(ID["ID_quality_control"]));
            cb_ocenka.Value = 0;
            cb_ID_Criteria.SelectedValue = -1;
        }

        private void bt_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void cb_ID_Territory_Аudiences_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_ID_Material_Provision.IsEnabled = true;
            cb_ID_Material_Provision.IsEnabled = true;
            if (cb_ID_Territory_Аudiences.SelectedValue == null)
            {
                lbl_ID_Material_Provision.IsEnabled = false;
                cb_ID_Material_Provision.IsEnabled = false;
                cb_ID_Material_Provision.SelectedValue = -1;
                g_ID_Territory_Аudiences = 0;
                return;
            }
            g_ID_Territory_Аudiences = Convert.ToInt32(cb_ID_Territory_Аudiences.SelectedValue.ToString());
            cbFill_ID_Material_Provision();
        }

        private void cb_ID_Training_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_ID_Territory_Аudiences.IsEnabled = true;
            cb_ID_Territory_Аudiences.IsEnabled = true;
            g_ID_Training_Area = Convert.ToInt32(cb_ID_Training_Area.SelectedValue);
            cbFill_ID_Territory_Аudiences();
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + " and [Name_criteria] like '%" + tb_Search.Text + $"%' or [ranging] like '%{tb_Search.Text}%' or [Name_of_kind_criteria] like '%{tb_Search.Text}%' or [ocenka] like '%{tb_Search.Text}%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dg_Sopostavl.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text)
                        {
                            dg_Sopostavl.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
        }

        private void bt_Filtr_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    bt_Search.Content = "Фильтрация";
                    break;
                case (false):
                    bt_Search.Content = "Поиск";
                    dgFill(QR);
                    break;
            }
        }
    }
}
