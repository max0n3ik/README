using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KRBilici.FolderClass
{
    class ClassAuthorization
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public void Authorization (TextBox TbLogin, PasswordBox PasswordBoxX)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                FolderClass.ClassMB.MBError("Введите логин");
                TbLogin.Focus();
            }

            else if (string.IsNullOrEmpty(PasswordBoxX.Password))
            {
                FolderClass.ClassMB.MBError("Введите пароль");
                PasswordBoxX.Focus();
            }

            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("SELECT Password, NameRole FROM dbo.ViewUser " +
                        $"WHERE [Login]='{TbLogin.Text}'", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[0].ToString() != PasswordBoxX.Password)
                    {
                        FolderClass.ClassMB.MBError("Неверный пароль");
                        PasswordBoxX.Focus();
                    }
                    else
                    {
                        FolderClass.ClassUser.Login = TbLogin.Text;
                        FolderClass.ClassUser.Password = PasswordBoxX.Password;
                        FolderClass.ClassRole.NameRole = dataReader[1].ToString();

                        switch (FolderClass.ClassRole.NameRole)
                        {
                            case "Директор":
                                WinFolder.Director windir =
                                    new WinFolder.Director();
                                windir.ShowDialog();
                                break;
                            case "Менеджер":
                                WinFolder.Manager manager =
                                    new WinFolder.Manager();
                                manager.ShowDialog();
                                break;
                            case "Кладовщик":
                                WinFolder.Storekeeper storekeeper =
                                    new WinFolder.Storekeeper();
                                storekeeper.ShowDialog();
                                break;
                            case "Курьер":
                                WinFolder.Delivery delivery =
                                    new WinFolder.Delivery();
                                delivery.ShowDialog();
                                break;

                        }

                    }
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
}
 