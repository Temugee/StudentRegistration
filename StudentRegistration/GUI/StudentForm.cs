using DevExpress.XtraEditors;
using StudentRegistration.Bussiness_Logic;
using StudentRegistration.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class StudentForm : DevExpress.XtraEditors.XtraForm
    {
        public StudentForm()
        {
            InitializeComponent();
        }
        StudentDAL studentDAL = new StudentDAL();
        StudentBLL studentBLL = new StudentBLL();
        private void StudentForm_Load(object sender, EventArgs e)
        {
            dgvStudentt.DataSource = studentDAL.SelectData();
        }
        void Clear()
        {
            textId.Text = "";
            textName.Text = "";
            textPhone.Text = "";
            comboBlood.Text = "";
            comboGender.Text = "";
            textEmail.Text = "";
            textDescription.Text = "";
            comboDob.Text = "";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void gridStudent_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" && textEmail.Text != "" && textPhone.Text != ""
                && cmbBirth.Text != "" && cmbBlood.Text != "" && cmbGender.Text != "" && textDescription.Text != "")
            {
                studentBLL.Name = textName.Text;
                studentBLL.Phone = textPhone.Text;
                studentBLL.Blood = comboBlood.Text;
                studentBLL.Gender = comboGender.Text;
                studentBLL.Email = textEmail.Text;
                studentBLL.Description = textDescription.Text;
                studentBLL.Dob = comboDob.Text;

                if (studentDAL.InsertData(studentBLL))
                {
                    MessageBox.Show("Data inserted successfully");
                    dgvStudentt.DataSource = studentDAL.SelectData();
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the values");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textId.Text != "")
            {
                if (textName.Text != "" && textEmail.Text != "" && textPhone.Text != ""
                && comboDob.Text != "" && comboBlood.Text != "" && comboGender.Text != "" && textDescription.Text != "")
                {
                    studentBLL.Id = int.Parse(textId.Text);
                    studentBLL.Name = textName.Text;
                    studentBLL.Phone = textPhone.Text;
                    studentBLL.Blood = comboBlood.Text;
                    studentBLL.Gender = comboGender.Text;
                    studentBLL.Email = textEmail.Text;
                    studentBLL.Description = textDescription.Text;
                    studentBLL.Dob = comboDob.Text;

                    if (studentDAL.UpdateData(studentBLL))
                    {
                        MessageBox.Show("Data updated successfully");
                        dgvStudentt.DataSource = studentDAL.SelectData();
                        Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all the values");
            }
        }

        private void gridStudentt_DoubleClick(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(DbConnection.DbConn);
            DataRow row = gridStudentt.GetDataRow(gridStudentt.GetSelectedRows()[0]);

            // Check if a row is selected and has a valid Id
            if (row == null || string.IsNullOrEmpty(row["Id"].ToString()))
                return;
            tabControl.SelectedTabPage = addStudent;
            string TestId = row["Id"].ToString();

            try
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string sql = "SELECT * FROM students WHERE Id = @TestId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TestId", TestId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable(); // Create a new DataTable to hold the result

                adapter.Fill(dataTable); // Fill the DataTable with data from the database

                // Display data from the DataTable in UI controls
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0]; // Get the first row from the DataTable
                    textId.Text = dataRow["Id"].ToString();
                    textName.Text = dataRow["Name"].ToString();
                    textPhone.Text = dataRow["Phone"].ToString();
                    comboBlood.Text = dataRow["Blood"].ToString();
                    comboGender.Text = dataRow["Gender"].ToString();
                    textEmail.Text = dataRow["Email"].ToString();
                    comboDob.Text = dataRow["Dob"].ToString();
                    textDescription.Text = dataRow["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvStudentt.ShowPrintPreview();
        }
    }
}
