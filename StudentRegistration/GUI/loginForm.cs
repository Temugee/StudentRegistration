using StudentRegistration.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        public loginForm()
        {
            InitializeComponent();
        }
        AdminDAL adminDAL = new AdminDAL();
        public static string userId = "0";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                DataTable adminData = adminDAL.LoginData(txtUsername.Text, txtPassword.Text);
                if (adminData.Rows.Count>0)
                {
                    userId = adminData.Rows[0][0].ToString();
                    this.Hide();
                    DashboardForm dashboardForm = new DashboardForm();
                    dashboardForm.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Password OR Username");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Password and Username");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
