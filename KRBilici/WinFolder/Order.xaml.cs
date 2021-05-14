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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        FolderClass.ClassDG classDG;
        SqlConnection sqlConnection = 
            new SqlConnection(App.ConnectionString());
        public Order()
        {
            InitializeComponent();
            classDG = new FolderClass.ClassDG(dgListOrder);
        }

        private void dgListOrder_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewOrder"); 
        }

        private void TbSearchNameOrder_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewOrder " +
                $"Where OrderCode Like '%{TbSearchNameOrder.Text}%'");
        }
    }
}
