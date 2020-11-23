using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Kind_criteria.xaml
    /// </summary>
    public partial class Kind_criteria : Window
    {
        private string QR = "";
        DBProcedures procedures = new DBProcedures();
        public Kind_criteria()
        {
            InitializeComponent();
        }
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
                DBConnection.qrKind_criteria = qr;
                connection.Kind_criteriaFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dg_Kind_criteria.ItemsSource = connection.dtKind_criteria.DefaultView;
                dg_Kind_criteria.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }
        private void dg_Kind_criteria_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_of_kind_criteria"):
                    e.Column.Header = "Название критерии";
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

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Name_of_kind_criteria] like '%" + tb_Search.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dg_Kind_criteria.ItemsSource)
                    {
                        if (
                            dataRow.Row.ItemArray[1].ToString() == tb_Search.Text)
                        {
                            dg_Kind_criteria.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrKind_criteria;
            dgFill(QR);
        }

        private void tb_Kriteria_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".IndexOf(e.Text) < 0;
        }

        private void bt_Insert_Click(object sender, RoutedEventArgs e)
        {

            if (tb_Kriteria.Text == "")
            {
                MessageBox.Show("Поля пусты!" +
                "\n Повторите попытку ввода!", "Суши",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                procedures.Kind_criteria_Insert(tb_Kriteria.Text.ToString());
                dgFill(QR);
                tb_Kriteria.Text = "";
            }
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Kriteria.Text == "")
            {
                MessageBox.Show("Поля не выбранны!" +
                "\n Повторите попытку ввода!", "Суши",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dg_Kind_criteria.SelectedItems[0];
                procedures.Kind_criteria_Updated(Convert.ToInt32(ID["ID_Kind_criteria"]), tb_Kriteria.Text);

            }
        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Kriteria.Text == "")
            {
                MessageBox.Show("Поля не выбранны!" +
                "\n Повторите попытку ввода!", "Суши",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dg_Kind_criteria.SelectedItems[0];
                procedures.Kind_criteria_Delete(Convert.ToInt32(ID["ID_Kind_criteria"]));
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
