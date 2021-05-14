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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        FolderClass.ClassCB classCB;
        FolderClass.ClassAdd classAdd;
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());       
        public AddProduct()
        {
            InitializeComponent();
            classAdd = new FolderClass.ClassAdd();
            classCB = new FolderClass.ClassCB();
        }

        private void BtAddProduct_Click(object sender, RoutedEventArgs e)
        {
            classAdd.Add(TbTypeProduct, TbNameProduct, TbNumberProduct, TbPriceProduct, CbStatusProduct);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadStatus(CbStatusProduct);
        }
    }
}
