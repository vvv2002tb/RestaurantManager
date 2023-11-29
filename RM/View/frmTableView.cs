using RM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.View
{
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
        }


        public override void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            MainClass.blurBackground(new frmTableAdd());
            TablePanel.Controls.Clear();
            LoadProducts();
        }

        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            FilterProducts(searchText);
        }

        private void FilterProducts(string searchText)
        {
            // Xóa các bảng hiện tại trong TablePanel
            TablePanel.Controls.Clear();

            // Thực hiện truy vấn dữ liệu từ database với điều kiện tìm kiếm
            string qry = $"Select * from tables where LOWER(tName) like '%{searchText}%'";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                AddItems(item["tId"].ToString(), item["tName"].ToString());
            }
        }


        private void AddItems(string id, string name)
        {
            var w = new ucTables()
            {
                tName = name,
                id = Convert.ToInt32(id)
            };
            w.onSelect += UcTables_OnSelect;
            w.onDelete += UcTables_OnDelete;
            TablePanel.Controls.Add(w);
            

        }

        private void UcTables_OnSelect(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi người dùng click vào nút sửa ở ucTables
            ucTables selectedTable = sender as ucTables;
            if (selectedTable != null)
            {
                // Sử dụng selectedTable.id để xác định bàn cần sửa
                // Mở form sửa thông tin bàn hoặc thực hiện các thao tác cần thiết
                frmTableAdd frm = new frmTableAdd();
                frm.id = Convert.ToInt32(selectedTable.id);
                frm.txtNameTable.Text = selectedTable.tName;
                MainClass.blurBackground(frm);
                TablePanel.Controls.Clear();
                LoadProducts();
            }
        }

        private void UcTables_OnDelete(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi người dùng click vào nút xóa ở ucTables
            ucTables selectedTable = sender as ucTables;
            if (selectedTable != null)
            {
                int tableIdToDelete = selectedTable.id;
                // Thực hiện các thao tác cần thiết để xóa bàn có ID là tableIdToDelete
                // Sau khi xóa, có thể cập nhật lại giao diện hoặc làm gì đó khác
                MessageBox.Show($"Bạn đang sửa thông tin bàn có ID: {selectedTable.id}");
                noticeFormView.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                noticeFormView.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                noticeFormView.Parent = this.ParentForm;
                messSuccess.Parent = this.ParentForm;


                if (noticeFormView.Show("Bạn chắn chắn xóa bàn này?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(selectedTable.id);
                    string qry = "Delete from tables where tId= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    messSuccess.Show("Xóa thành công!");
                    TablePanel.Controls.Clear();
                    LoadProducts();
                }

            }

        }
        

        private void LoadProducts()
        {
            string qry = "Select * from tables";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                AddItems(item["tId"].ToString(), item["tName"].ToString());
            }    
        }

        private void frmTableView_Load(object sender, EventArgs e)
        {
            TablePanel.Controls.Clear();
            LoadProducts();
        }

        
    }
}
