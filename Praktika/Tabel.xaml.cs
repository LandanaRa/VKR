using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Tabel.xaml
    /// </summary>
    public partial class Tabel : Window
    {
        private string QR = "";
        DBProcedures procedures = new DBProcedures();

        public Tabel()
        {
            InitializeComponent();
        }

        private void Tabel_OnLoaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qr_Tabel;
            dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qr_Tabel = qr;
                connection.Tabel_Fill();
                connection.Dependency.OnChange += Dependency_OnChange; ;
                dg_Tabel.ItemsSource = connection.dtTabel.DefaultView;
                //dg_Tabel.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void dg_Criteria_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("xz"):
                    e.Column.Header = "Критерии с оценками";
                    break;
                case ("Full_Name"):
                    e.Column.Header = "Территория";
                    break;
                case ("Number_Cabinet"):
                    e.Column.Header = "Номер аудитории";
                    break;
                case ("Name_Material_Provision"):
                    e.Column.Header = "МО";
                    break;
                case ("Inventory_Number"):
                    e.Column.Header = "Инвентарный номер";
                    break;
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
