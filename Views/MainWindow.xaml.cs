using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new vmMainViewModel();
            //DataContext = WorkingMySQLDBHelper.MainViewModel;

            //List<double> PP = Enumerable.Repeat(0.0, 60).ToList();


        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    //ШТУЧКА ДЛЯ ИНИЦИАЛИЗАЦИИ КОМБОБОКСА
        //    //status_std.ItemsSource = WorkingMySQLDBHelper.MainViewModel.std_status.DefaultView;
        //    //status_ver.ItemsSource = WorkingMySQLDBHelper.MainViewModel.vrf_status.DefaultView;
        //    //verefication_est.ItemsSource = WorkingMySQLDBHelper.MainViewModel.Verification.DefaultView;


        //}


        private void keyboardEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                StartButton_Click(sender, e);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = WorkingMySQLDBHelper.MainViewModel.DoSqlQuery(SQLQuery.Text);
            if (dt != null)
            {
                grid_1.ItemsSource = dt.DefaultView;
            }
        }



        private void SaveStd_Click(object sender, RoutedEventArgs e)
        {
            if (WorkingMySQLDBHelper.MainViewModel.IsConnected == true)
            {
                WorkingMySQLDBHelper.MainViewModel.UpdateResults();

                //try
                //{
                //    WorkingMySQLDBHelper.MainViewModel.UpdateResults();

                //}
                //catch(Exception w)
                //{
                //    MessageBox.Show(w.ToString());
                //}
            }
        }

        private void RefreshStd_Click(object sender, RoutedEventArgs e)
        {
            if (WorkingMySQLDBHelper.MainViewModel.IsConnected == true)
            {
                WorkingMySQLDBHelper.MainViewModel.RefreshResults();
            }
        }
    }

}


