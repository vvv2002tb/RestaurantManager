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

namespace RM.Model
{
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;


        public override void guna2TileButton1_Click(object sender, EventArgs e)
        {
            string qry = "";
            guna2MessageDialog1.Parent = this;

            if (id == 0)
            {
                qry = "Insert into tables Values(@Name)";
            }
            else // update
            {
                qry = "Update tables Set tName = @Name where tId = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id ", id);
            ht.Add("@Name ", txtNameTable.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {

                guna2MessageDialog1.Show("Thêm thành công!");
                id = 0;
                /*txtName.Focus();*/
                this.Close();

            }
        }

        public override void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
