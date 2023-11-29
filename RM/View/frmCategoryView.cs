using RM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RM.View
{
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From category where catName like N'%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();

        }

        public override void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            /*frmCategoryAdd frm = new frmCategoryAdd();
            frm.ShowDialog();*/
            MainClass.blurBackground(new frmCategoryAdd());
            GetData();
        }

        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                MainClass.blurBackground(frm);
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                // confirm yes no before delete
                noticeFormView.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                noticeFormView.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                noticeFormView.Parent = this.ParentForm;
                messSuccess.Parent = this.ParentForm;
                

                if (noticeFormView.Show("Bạn chắn chắn xóa danh mục này?") == DialogResult.Yes)
                {
                    int id = Convert.ToUInt16(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string qry = "Delete from category where catID= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    messSuccess.Show("Xóa thành công!");

                    GetData();
                }    


                

            }
        }
    }
}

