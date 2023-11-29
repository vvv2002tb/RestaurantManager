using RM.View;
using RM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM
{
    public partial class fMainManager : Form
    {
        public fMainManager()
        {
            InitializeComponent();
        }

        static fMainManager _obj;

        public static fMainManager Instance
        {
            get { if (_obj == null) { _obj = new fMainManager(); } return _obj; }
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            messClose.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            messClose.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            
            


            if (messClose.Show("Bạn có muốn thoát chương trình?") == DialogResult.Yes)
            {

                Application.Exit();


            }
            
        }
        public void addControls(Form f)
        {
            ControlsPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlsPanel.Controls.Add(f);
            f.Show();

        }


        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void fMainManager_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = "Xin chào, " + MainClass.USER;
            _obj = this;

            addControls(new frmHome());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            addControls(new frmHome());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            /*addControls(new fCategoryView());*/
            addControls(new frmCategoryView());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            fLogin frm = new fLogin();
            frm.ShowDialog();
            

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            addControls(new frmTableView());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            addControls(new frmStaffView());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            addControls(new frmProductView());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            addControls(new frmPOS());
        }
    }
}
