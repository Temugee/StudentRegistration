using DevExpress.Skins;
using DevExpress.XtraEditors;
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
    public partial class ThemeForm : DevExpress.XtraEditors.XtraForm
    {
        public ThemeForm()
        {
            InitializeComponent();
        }

        private void ThemeForm_Load(object sender, EventArgs e)
        {
            foreach (SkinContainer cn in SkinManager.Default.Skins)
            {
                cmbSkin.Properties.Items.Add(cn.SkinName);
            }
        }

        private void cmbSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(cmbSkin.Text);
        }
    }
}