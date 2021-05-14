using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KRBilici.FolderClass
{
    class ClassReg
    {
        SqlConnection sqlConnection = 
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
       

        public void Reg(TextBox TbLoginReg, TextBox TbPassword, TextBox TbRepeatPassword)
        {
            string psw = TbPassword.Text;
            string zagl = "QWERTYUIIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjkklzxcvbnm";
            string num = "1234567890";
            string sym = "!@#$%^&*()_-";

            if (string.IsNullOrEmpty(TbLoginReg.Text))
            {
                FolderClass.ClassMB.MBError("Введите логин");
                TbLoginReg.Focus();
            }
            else if (string.IsNullOrEmpty(TbPassword.Text))
            {
                FolderClass.ClassMB.MBError("Введите пароль");
                TbPassword.Focus();
            }
            else if (psw.Length <= 6)
            {
                FolderClass.ClassMB.MBInformation("Пароль должен содержать минимум 7 символов");
                TbPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else if (zagl.IndexOfAny(psw.ToCharArray()) == -1)
            {
                FolderClass.ClassMB.MBInformation("Пароль должен содержать прописную букву");
                TbPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else if (mal.IndexOfAny(psw.ToCharArray()) == -1)
            {
                FolderClass.ClassMB.MBInformation("Пароль должен содержать строчную букву");
                TbPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else if (num.IndexOfAny(psw.ToCharArray()) == -1)
            {
                FolderClass.ClassMB.MBInformation("Пароль должен содержать цифру");
                TbPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else if (sym.IndexOfAny(psw.ToCharArray()) == -1)
            {
                FolderClass.ClassMB.MBInformation("Пароль должен содержать один из символов:" +
                    " !@#$%^&*()_-");
                TbPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else if (string.IsNullOrEmpty(TbRepeatPassword.Text))
            {
                FolderClass.ClassMB.MBError("Необходимо повторить пароль");
                TbRepeatPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else if (TbRepeatPassword.Text != TbPassword.Text)
            {
                FolderClass.ClassMB.MBError("пароли должны совпадать");
                TbRepeatPassword.Focus();
                TbPassword.Clear();
                TbRepeatPassword.Clear();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.[User] (Login,Password,IdRole) " +
                        "Values (@Login,@Password,@IdRole)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Login", TbLoginReg.Text);
                    sqlCommand.Parameters.AddWithValue("Password", TbPassword.Text);
                    sqlCommand.Parameters.AddWithValue("IdRole", 3);
                    sqlCommand.ExecuteNonQuery();
                    FolderClass.ClassMB.MBInformation("Вы успешно зарегистрировались");
                }
                catch (Exception ex)
                {
                    FolderClass.ClassMB.MBError(ex.Message);

                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }

    


}
