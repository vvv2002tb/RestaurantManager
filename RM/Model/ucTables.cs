using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.Model
{
    public partial class ucTables : UserControl
    {
        public ucTables()
        {
            InitializeComponent();
        }

        public EventHandler onSelect = null;
        public EventHandler onDelete = null; // Thêm sự kiện xóa


        public int id { get; set; }

        public string tName
        {
            get { return guna2HtmlLabel2.Text; }
            set { guna2HtmlLabel2.Text = value; }
        }
        
        

        

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            onDelete?.Invoke(this, e);
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ucTables_Load(object sender, EventArgs e)
        {

        }
    }
}
