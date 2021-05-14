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

namespace KRBilici.WinFolder
{
    /// <summary>
    /// Логика взаимодействия для AddProvider.xaml
    /// </summary>
    public partial class AddProvider : Window
    {
        FolderClass.ClassAdd classAddProvider;
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        public AddProvider()
        {
            InitializeComponent();
            classAddProvider = new FolderClass.ClassAdd();
           
        }

        private void BtAddProvider_Click(object sender, RoutedEventArgs e)
        {
            classAddProvider.AddProvider(TbNameProvider, TbNumberPhoneProvider, TbTypeProvider);
        }
    }
}
