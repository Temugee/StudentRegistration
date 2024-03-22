using DevExpress.XtraBars;
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
    public partial class DashboardForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThemeForm themeForm = new ThemeForm();
            themeForm.MdiParent = this;
            themeForm.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.MdiParent = this;
            aboutForm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.MdiParent = this;
            studentForm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.MdiParent = this;
            adminForm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserDashboardForm userDashboardForm = new UserDashboardForm();
            userDashboardForm.MdiParent = this;
            userDashboardForm.Show();
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}