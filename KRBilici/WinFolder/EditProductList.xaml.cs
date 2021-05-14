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
    /// Логика взаимодействия для EditProductList.xaml
    /// </summary>
    public partial class EditProductList : Window
    {
        FolderClass.ClassCB classCB;
        FolderClass.ClassEdit classEdit;
        SqlConnection sqlConnection = 
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        public EditProductList()
        {
            InitializeComponent();
            classEdit = new FolderClass.ClassEdit();
            classCB = new FolderClass.ClassCB();
        }

        private void BtEditProduct_Click(object sender, RoutedEventArgs e)
        {
            classEdit.EditProduct(TbTypeProduct, TbNameProduct, 
                TbNumberProduct, 
                TbPriceProduct,
                CbStatusProduct);

            classCB.LoadStatus(CbStatusProduct);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadStatus(CbStatusProduct);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * from dbo.ProductList " +
                    $"Where IdProduct='{FolderClass.ClassProduct.IdProduct}'",
                    sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                TbTypeProduct.Text = sqlDataReader[1].ToString();
                TbNameProduct.Text = sqlDataReader[2].ToString();
                TbNumberProduct.Text = sqlDataReader[3].ToString();
                TbPriceProduct.Text = sqlDataReader[4].ToString();
                CbStatusProduct.Text = sqlDataReader[5].ToString();




            }
            catch (Exception ex)
            {
                FolderClass.ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
