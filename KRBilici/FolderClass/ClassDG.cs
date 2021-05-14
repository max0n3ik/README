using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KRBilici.FolderClass
{
    class ClassDG
    {
        DataGrid dataGrid;
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public ClassDG(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        public void LoadDB(string sqlCommand)
        {
            try
            {
                //Открываем подключение
                sqlConnection.Open();
                //работа с БД на основе sql-команды и подключения
                sqlDataAdapter = new SqlDataAdapter(sqlCommand, sqlConnection);
                //объявляется новая виртуальная таблица
                dataTable = new DataTable();
                //заполняется виртуальная таблица на основе sql-команды и подключения
                sqlDataAdapter.Fill(dataTable);
                //и звиртуальной таблицы загружаются данные в DataGrid
                dataGrid.ItemsSource = dataTable.DefaultView;
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

        public string SelectId()
        {
            object[] mass = null;
            string id = "";
            try
            {
                if (dataGrid != null)
                {
                    DataRowView dataRowView = dataGrid.SelectedItem
                        as DataRowView;
                    if (dataRowView != null)
                    {
                        DataRow dataRow = (DataRow)dataRowView.Row;
                        mass = dataRow.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch
            {
                ClassMB.MBError("Вы не выбрали строку");
            }
            return id;
        }

    }
}
