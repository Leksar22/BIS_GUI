using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;

using WpfApp2;
using System.IO;
using System.Data.SqlClient;
namespace WpfApp2
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = WorkingMySQLDBHelper.MainViewModel;
            _password.Focus();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (WorkingMySQLDBHelper.MainViewModel.TryConnect() == true)
            {
                WorkingMySQLDBHelper.MainViewModel.TryConnect();
                MessageBox.Show("Туц-Туц!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }


        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void PressEnter1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _password.Focus();
            }
        }
    }
}
