using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для Quality_control.xaml
    /// </summary>
    public partial class Quality_control : Window
    {
        public Quality_control()
        {
            InitializeComponent();
        }
        private string QR = "";
        DBProcedures procedures = new DBProcedures();


        //Технология Real Time
        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        //Метод заполнения таблицы
        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrCriteria = qr;
                connection.CriteriaFill(0);
                connection.Dependency.OnChange += Dependency_OnChange;
                dg_Quality_control.ItemsSource = connection.dtCriteria.DefaultView;
                dg_Quality_control.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        //Заполнение выпадающего списка
        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.cb_for_CriteriaFill();
            cb_criteria.ItemsSource = connection.dtcb_for_Criteria.DefaultView;
            cb_criteria.SelectedValuePath = "kind_criteria_ID";
            cb_criteria.DisplayMemberPath = "Criteria_Info";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrQuality_control;
            dgFill(QR);
            cbFill();
        }

        private void dg_Quality_control_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Filtr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_Krit.Text == "" | cb_criteria.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Поля пусты!" +
                "\n Повторите попытку ввода!", "qwe",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //procedures.Quality_control_Insert(tb_Date_Of_Hosting.Text.ToString(), Convert.ToInt32(cb_criteria.Text.ToString()), Convert.ToInt32(tb_MTOK.Text.ToString()));
                //dgFill(QR);
                //tb_Date_Of_Hosting.Text = "";
                //cb_criteria.Text = "";
                
            }
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_Krit.Text == "" | cb_criteria.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Поля не выбранны!" +
                "\n Повторите попытку ввода!", "qwe",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //DataRowView ID = (DataRowView)dg_Quality_control.SelectedItems[0];
                //procedures.Quality_control_Update(Convert.ToInt32(ID["ID_quality_control"]), tb_Date_Of_Hosting.Text.ToString(), Convert.ToInt32(cb_criteria.Text.ToString()), Convert.ToInt32(tb_MTOK.Text.ToString()));

            }
        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_Krit.Text == "" | cb_criteria.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Поля не выбранны!" +
                "\n Повторите попытку ввода!", "qwe",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dg_Quality_control.SelectedItems[0];
                procedures.Criteria_Delete(Convert.ToInt32(ID["ID_quality_contro"]));
                dgFill(QR);
            }
        }

        private void bt_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
