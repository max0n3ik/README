using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KRBilici.FolderClass
{
    class ClassAdd
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        

       public void Add (TextBox TbTypeProduct, TextBox TbNameProduct, 
           TextBox TbNumberProduct, TextBox TbPriceProduct,
           ComboBox CbStatusProduct)
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
            else if (CbStatusProduct.SelectedValue.ToString() == "")
            {
                FolderClass.ClassMB.MBError("Выберите статус товара");
                CbStatusProduct.Focus();
            }
            else
            {
                 try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.[ProductList]" +
                        "(TypeOfProduct, NameOfProduct, NumberOfProduct, PriceOfProduct, IdStatus)" +
                        " Values (@TypeOfProduct, @NameOfProduct, @NumberOfProduct, @PriceOfProduct, @IdStatus)", 
                        sqlConnection);
                    sqlCommand.Parameters.AddWithValue("TypeOfProduct", TbTypeProduct.Text);
                    sqlCommand.Parameters.AddWithValue("NameOfProduct", TbNameProduct.Text);
                    sqlCommand.Parameters.AddWithValue("NumberOfProduct", TbNumberProduct.Text);
                    sqlCommand.Parameters.AddWithValue("PriceOfProduct", TbPriceProduct.Text);
                    sqlCommand.Parameters.AddWithValue("IdStatus", CbStatusProduct.SelectedValue.ToString());
                    sqlCommand.ExecuteNonQuery();

                    CbStatusProduct.SelectedIndex = -1;

                    FolderClass.ClassMB.MBInformation("Товар был успешно добавлен");

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

        public void AddProvider(TextBox TbNameProvider, TextBox TbNumberPhoneProvider, TextBox TbTypeProvider)
        {
            if (string.IsNullOrEmpty(TbNameProvider.Text)) 
            {
                FolderClass.ClassMB.MBInformation("Введите название поставщика");
                TbNameProvider.Focus();
            }

            else if  (string.IsNullOrEmpty(TbNumberPhoneProvider.Text))
            {
                FolderClass.ClassMB.MBInformation("Введите номер телефона поставщика");
                TbNumberPhoneProvider.Focus();
            }

            else if (string.IsNullOrEmpty(TbTypeProvider.Text))
            {
                FolderClass.ClassMB.MBInformation("Введите тип товара доставляемый поставщиком");
                TbTypeProvider.Focus();
            }
            
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.Provider (NameOfProvider, NumberPhoneProvider, ProviderDescription)" +
                        "Values (@NameOfProvider, @NumberPhoneProvider, @ProviderDescription)",
                        sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameOfProvider", TbNameProvider.Text);
                    sqlCommand.Parameters.AddWithValue("NumberPhoneProvider", TbNumberPhoneProvider.Text);
                    sqlCommand.Parameters.AddWithValue("ProviderDescription", TbTypeProvider.Text);
                    sqlCommand.ExecuteNonQuery();

                    FolderClass.ClassMB.MBInformation("Поставщик был успешно добавлен");
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
