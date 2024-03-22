using StudentRegistration.Bussiness_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration.Data_Access_Layer
{
    class StudentDAL
    {
        SqlConnection connection = new SqlConnection(DbConnection.DbConn);

        #region SelectData
        public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT students.Id, students.Name, students.Phone, admin.Name as CreatedBy FROM students INNER JOIN admin ON students.CreatedBy = admin.Id";
                SqlCommand command = new SqlCommand(sql, connection);
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

        #region InsertData
        public bool InsertData(StudentBLL student)
        {
            try
            {
                string sql = "INSERT INTO students(Name,Phone,Blood,Gender,Email,Dob,Description,CreatedBy) VALUES(@name,@phone,@blood,@gender,@email,@dob,@description,@createdBy)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@phone", student.Phone);
                command.Parameters.AddWithValue("@blood", student.Blood);
                command.Parameters.AddWithValue("@gender", student.Gender);
                command.Parameters.AddWithValue("@email", student.Email);
                command.Parameters.AddWithValue("@dob", student.Dob);
                command.Parameters.AddWithValue("@description", student.Description);
                command.Parameters.AddWithValue("@createdBy", loginForm.userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close() ;
            }
            return true;
        }
        #endregion

        #region UpdateData
        public bool UpdateData(StudentBLL student)
        {
            try
            {
                string sql = "UPDATE students SET Name=@name, Phone=@phone, Blood=@blood, Gender=@gender, Email=@email, Dob=@dob, Description=@description, UpdatedBy=@updatedBy WHERE Id=@id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@phone", student.Phone);
                command.Parameters.AddWithValue("@blood", student.Blood);
                command.Parameters.AddWithValue("@gender", student.Gender);
                command.Parameters.AddWithValue("@email", student.Email);
                command.Parameters.AddWithValue("@dob", student.Dob);
                command.Parameters.AddWithValue("@description", student.Description);
                command.Parameters.AddWithValue("@updatedBy", loginForm.userId);

                command.Parameters.AddWithValue("@id", student.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close() ;
            }
            return true;
        }
        #endregion
    }
}