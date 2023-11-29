using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            /*AddCategory();*/
            flowLayoutListProduct.Controls.Clear();
            LoadProducts();

        }

        /*private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            flowCatTop.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2TileButton b = new Guna.UI2.WinForms.Guna2TileButton();
                    b.FillColor = Color.Transparent;
                    b.ForeColor = Color.Black;
                    b.Size = new Size(180, 66);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();
                    flowCatTop.Controls.Add(b);

                }    
               

            }    
        }*/


        private void AddItems(string id, string name, string price, Image pimage)
        {
            var w = new ucProducts()
            {
                productName = name,
                productPrice = price,
                productImage = pimage,
                id = Convert.ToInt32(id)
            };

            flowLayoutListProduct.Controls.Add(w);

            

            w.onSelectAdd += (ss, ee) =>
            {
                var wdg = (ucProducts)ss;

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                { 
                    if (Convert.ToInt32(item.Cells["dgvId"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        return;
                    }
                }

                // add new product 
                guna2DataGridView1.Rows.Add(new object[] {0, wdg.id ,  wdg.productName, 1, wdg.productPrice, wdg.productPrice });
                getTotal();
            };

            

        }

        private void LoadProducts()
        {
            string qry = "Select * from products inner join category on catId = CategoryID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Byte[] imagearray = (byte[])item["pImage"];
                    byte[] imamagebytearray = imagearray;

                    AddItems(item["pId"].ToString(), item["pName"].ToString(), item["pPrice"].ToString(), Image.FromStream(new MemoryStream(imagearray)));
                }


            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutListProduct.Controls)
            {
                var pro = (ucProducts)item;
                pro.Visible = pro.productName.ToLower().Contains(guna2TextBox1.Text.Trim().ToLower());
            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
            getTotal();
        }


        private void getTotal()
        {
            double total = 0;
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }

            guna2HtmlLabel4.Text = "Tổng tiền: " + total.ToString("N0") + " VND";
        }


        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
