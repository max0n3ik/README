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
    /// Логика взаимодействия для Delivery.xaml
    /// </summary>
    public partial class Delivery : Window
    {
        FolderClass.ClassDG classDG;
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        public Delivery()
        {
            InitializeComponent();
            classDG = new FolderClass.ClassDG(dgListDelivery);
        }

        private void dgListDelivery_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewDelivery");
        }

        private void TbSearchName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewDelivery " +
               $"Where Name Like '%{TbSearchName.Text}%'");
        }
    }
}
