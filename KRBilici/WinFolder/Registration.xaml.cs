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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        SqlConnection SqlConnection = new SqlConnection(App.ConnectionString());
        FolderClass.ClassReg ClassReg;
        public Registration()
        {
            InitializeComponent();
            ClassReg = new FolderClass.ClassReg();
        }

        private void BtRegistartion_Click(object sender, RoutedEventArgs e)
        {
            ClassReg.Reg(TbLoginReg, TbPassword, TbRepeatPassword);
        }
    }
}
