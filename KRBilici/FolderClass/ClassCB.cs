using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KRBilici.FolderClass
{
    class ClassCB
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public void LoadStatus(ComboBox CbStatusProduct)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdStatus, " +
                    "StatusProduct FROM dbo.StatusProduct Order by IdStatus ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "StatusProduct");
                CbStatusProduct.ItemsSource = dataSet.Tables["StatusProduct"].DefaultView;
                CbStatusProduct.DisplayMemberPath = dataSet.Tables["StatusProduct"].Columns["StatusProduct"].ToString();
                CbStatusProduct.SelectedValuePath = dataSet.Tables["StatusProduct"].Columns["IdStatus"].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

               
    }

    
}
