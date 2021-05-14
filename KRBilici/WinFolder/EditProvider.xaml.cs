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
    /// Логика взаимодействия для EditProvider.xaml
    /// </summary>
    public partial class EditProvider : Window
    {
        FolderClass.ClassEdit classEdit;
        SqlConnection sqlConnectoin = new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        public EditProvider()
        {
            InitializeComponent();
            classEdit = new FolderClass.ClassEdit();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnectoin.Open();
                sqlCommand = new SqlCommand("Select * from dbo.Provider " +
                    $"Where IdProductProvider='{FolderClass.ClassProvider.IdProductProvider}'",
                    sqlConnectoin);

                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                TbNameProvider.Text = sqlDataReader[1].ToString();
                TbPhoneProvider.Text = sqlDataReader[2].ToString();
                TbTypeProvider.Text = sqlDataReader[3].ToString();
                



            }
            catch (Exception ex)
            {
                FolderClass.ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnectoin.Close();
            }
        }

        private void BtEditProvider_Click(object sender, RoutedEventArgs e)
        {
            classEdit.EditProvider(TbNameProvider, TbPhoneProvider, TbTypeProvider);
        }
    }
}
