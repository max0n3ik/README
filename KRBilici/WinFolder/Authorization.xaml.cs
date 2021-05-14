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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KRBilici
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection SqlConnection = new SqlConnection(App.ConnectionString());
        FolderClass.ClassAuthorization classAuthorization;
        public MainWindow()
        {

            InitializeComponent();
            classAuthorization = new FolderClass.ClassAuthorization();
        }

        private void BtRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinFolder.Registration registration = new WinFolder.Registration();
            registration.ShowDialog();
        }

        private void BtJoin_Click(object sender, RoutedEventArgs e)
        {
            classAuthorization.Authorization(TbLogin, PasswordBoxX);
        }

        private void BtRegistration(object sender, RoutedEventArgs e)
        {
            WinFolder.Registration registration = new WinFolder.Registration();
            registration.ShowDialog();
        }
    }
}
