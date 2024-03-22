using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration.Data_Access_Layer
{
    class AdminDAL
    {
        SqlConnection connection = new SqlConnection(DbConnection.DbConn);

        #region LoginData
        public DataTable LoginData(string username, string pass)
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT * FROM admin WHERE Username=@username AND Password=@password";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", pass);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
        #endregion
    }
}
