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
    public partial class frnStaffAdd : SampleAdd
    {
        public frnStaffAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void frnStaffAdd_Load(object sender, EventArgs e)
        {

        }

        public override void guna2TileButton1_Click(object sender, EventArgs e)
        {
            string qry = "";
            guna2MessageDialog1.Parent = this;

            if (id == 0)
            {
                qry = "Insert into staff Values(@Name, @phone, @role)";
            }
            else // update
            {
                qry = "Update staff Set sName = @Name, sPhone = @phone, sRoleName = @role where staffId = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id ", id);
            ht.Add("@Name ", txtFullName.Text);
            ht.Add("@phone ", txtPhone.Text);
            ht.Add("@role ", cbRole.Text);


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
