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
    /// Логика взаимодействия для WinProviderList.xaml
    /// </summary>
    public partial class WinProviderList : Window
    {
        FolderClass.ClassDG classDG;
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        public WinProviderList()
        {
            InitializeComponent();
            classDG = new FolderClass.ClassDG(dgProviderList);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.Provider");
        }

        private void BtAddProvider_Click(object sender, RoutedEventArgs e)
        {
            WinFolder.AddProvider addProvider = new WinFolder.AddProvider();
            addProvider.ShowDialog();
        }

        private void BtRedProvider_Click(object sender, RoutedEventArgs e)
        {
            if (dgProviderList.SelectedItem == null)
            {
                FolderClass.ClassMB.MBError("Выберете строку");
            }
            else
            {
                FolderClass.ClassProvider.IdProductProvider = classDG.SelectId();
                try
                {
                    WinFolder.EditProvider editProvider =
                        new EditProvider();
                    editProvider.ShowDialog();
                    classDG.LoadDB("Select * from dbo.Provider");
                }
                catch (Exception ex)
                {
                    FolderClass.ClassMB.MBError(ex);
                }
            }
        }

        private void TbSearchNameProvider_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.Provider " +
                $"Where NameOfProvider like '%{TbSearchNameProvider.Text}%'");
        }
    }
}
