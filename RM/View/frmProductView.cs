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
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();


        }

        public void GetData()
        {
            string qry = "Select pId, pName, pPrice, c.catName From products p inner join category c on c.catId = p.CategoryID where pName like N'%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvCat);



            MainClass.LoadData(qry, guna2DataGridView1, lb);

        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            GetData();
        }


        public override void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            /*frmCategoryAdd frm = new frmCategoryAdd();
            frm.ShowDialog();*/
            MainClass.blurBackground(new frmProductAdd());
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
                frmProductAdd frm = new frmProductAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                frm.cID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvcatID"].Value);

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


                if (noticeFormView.Show("Bạn chắn chắn xóa sản phẩm này?") == DialogResult.Yes)
                {
                    int id = Convert.ToUInt16(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string qry = "Delete from products where pId= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    messSuccess.Show("Xóa thành công!");

                    GetData();
                }




            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra cột cần thay đổi (vd: giá sản phẩm)
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvPrice" && e.Value != null)
            {
                // Chuyển đổi giá trị sang kiểu decimal
                decimal price = Convert.ToDecimal(e.Value);

                // Định dạng giá trị với chữ VND và phân tách hàng nghìn
                e.Value = string.Format("{0:N0} VND", price);
                e.FormattingApplied = true; // Đã xử lý định dạng
            }
        }
    }
}
