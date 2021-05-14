using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KRBilici.FolderClass
{
    class ClassEdit
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        

        public void EditProduct(TextBox TbTypeProduct, TextBox TbNameProduct,
           TextBox TbNumberProduct, TextBox TbPriceProduct,
           ComboBox CbStatusClient)
        {
            if (string.IsNullOrEmpty(TbTypeProduct.Text))
            {
                FolderClass.ClassMB.MBError("Введите тип товара");
                TbTypeProduct.Focus();
            }
            else if (string.IsNullOrEmpty(TbNameProduct.Text))
            {
                FolderClass.ClassMB.MBError("Введите название товара");
                TbNameProduct.Focus();
            }
            else if (string.IsNullOrEmpty(TbNumberProduct.Text))
            {
                FolderClass.ClassMB.MBError("Введите количество товара");
                TbNumberProduct.Focus();
            }
            else if (string.IsNullOrEmpty(TbPriceProduct.Text))
            {
                FolderClass.ClassMB.MBError("Введите цену товара");
                TbPriceProduct.Focus();
            }
            else if (CbStatusClient.SelectedValue.ToString() == "")
            {
                FolderClass.ClassMB.MBError("Введите статус товара");
                CbStatusClient.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Update [ProductList] " +
                        $"Set [TypeOfProduct]='{TbTypeProduct.Text}', " +
                        $"[NameOfProduct]='{TbNameProduct.Text}', " +
                        $"[NumberOfProduct]='{TbNumberProduct.Text}', " +
                        $"[PriceOfProduct]='{TbPriceProduct.Text}', " +
                        $"[IdStatus]='{CbStatusClient.SelectedValue.ToString()}' " +
                        $"Where [IdProduct]='" +
                       $"{FolderClass.ClassProduct.IdProduct}'",
                       sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    FolderClass.ClassMB.MBInformation("Данные успешно " +
                        "отредактированы!");
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

        public void EditProvider(TextBox TbNameProvider, 
            TextBox TbPhoneProvider, TextBox TbTypeProvider)
        {
            if (string.IsNullOrEmpty(TbNameProvider.Text))
            {
                FolderClass.ClassMB.MBError("Введите название поставщика");
                TbNameProvider.Focus();
            }
            else if (string.IsNullOrEmpty(TbPhoneProvider.Text))
            {
                FolderClass.ClassMB.MBError("Введите номер телефона поставщика");
                TbPhoneProvider.Focus();
            }
            else if (string.IsNullOrEmpty(TbTypeProvider.Text))
            {
                FolderClass.ClassMB.MBError("Введите тип поставки");
                TbTypeProvider.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Update [Provider]" +
                        $"Set NameOfProvider ='{TbNameProvider.Text}', " +
                        $"NumberPhoneProvider ='{TbPhoneProvider.Text}', " +
                        $"ProviderDescription ='{TbTypeProvider.Text}' " +
                        $"Where IdProductProvider = ' " +
                    $"{FolderClass.ClassProvider.IdProductProvider}' ",
                        sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    FolderClass.ClassMB.MBInformation("Данные успешно отредактированы");

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
