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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для Criteria.xaml
    /// </summary>
    public partial class Criteria : Window
    {
        public Criteria()
        {
            InitializeComponent();
        }

        private string QR = "";
        private int g_id = 0;
        DBProcedures procedures = new DBProcedures();


        //Технология Real Time
        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR, g_id);
        }

        //Метод заполнения таблицы
        private void dgFill(string qr, int id)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrCriteria = qr;
                connection.CriteriaFill(id);
                connection.Dependency.OnChange += Dependency_OnChange;
                dg_Criteria.ItemsSource = connection.dtCriteria.DefaultView;
                dg_Criteria.Columns[0].Visibility = Visibility.Collapsed;
                dg_Criteria.Columns[2].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        //Заполнение выпадающего списка
        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.Kind_criteriaFill();
            cb_kind_criteria_ID.ItemsSource = connection.dtKind_criteria.DefaultView;
            cb_kind_criteria_ID.SelectedValuePath = "ID_Kind_criteria";
            cb_kind_criteria_ID.DisplayMemberPath = "Name_of_kind_criteria";
        }


        private void dg_Criteria_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_criteria"):
                    e.Column.Header = "Название критерия";
                    break;
                case ("ranging"):
                    e.Column.Header = "Ранжировка";
                    break;
                case ("Name_of_kind_criteria"):
                    e.Column.Header = "Название главного критерия";
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrCriteria;
            dgFill(QR, g_id);
            cbFill();
        }

        private void tb_Name_criteria_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void tb_ranging_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + " where [Name_criteria] like '%" + tb_Search.Text + $"%' or [ranging] like '%{tb_Search.Text}%'";
                    dgFill(newQR, g_id);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dg_Criteria.ItemsSource) 
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text)
                        {
                            dg_Criteria.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
        }

        private void bt_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_criteria.Text == "" | cb_kind_criteria_ID.SelectedIndex == -1 | tb_ranging.Text == "")
            {
                MessageBox.Show("Поля пусты!" +
                "\n Повторите попытку ввода!", "qwe",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                procedures.Criteria_Insert(
                    tb_Name_criteria.Text.ToString(),
                    g_id,
                    Convert.ToInt32(tb_ranging.Text.ToString()));
                dgFill(QR, g_id);
                tb_Name_criteria.Text = "";
                tb_ranging.Value = 0;
            }
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_criteria.Text == "" | cb_kind_criteria_ID.SelectedIndex == -1 | tb_ranging.Text == "")
            {
                MessageBox.Show("Поля не выбранны!" +
                "\n Повторите попытку ввода!", "qwe",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dg_Criteria.SelectedItems[0];
                procedures.Criteria_Update(Convert.ToInt32(
                    ID["ID_criteria"]),
                    tb_Name_criteria.Text.ToString(),
                    g_id,
                    Convert.ToInt32(tb_ranging.Text.ToString()));
                dgFill(QR, g_id);
                tb_ranging.Value = 0;
                tb_Name_criteria.Text = "";
            }
        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_criteria.Text == "" | cb_kind_criteria_ID.Text == "" | tb_ranging.Text == "")
            {
                MessageBox.Show("Поля не выбранны!" +
                "\n Повторите попытку ввода!", "qwe",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dg_Criteria.SelectedItems[0];
                procedures.Criteria_Delete(Convert.ToInt32(ID["ID_criteria"]));
                dgFill(QR, g_id);
            }
        }

        private void bt_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
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
                    dgFill(QR, g_id);
                    break;
            }
        }

        private void cb_kind_criteria_ID_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
            dgFill(QR, g_id = Convert.ToInt32(cb_kind_criteria_ID.SelectedValue));

        private void chbFilter_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
