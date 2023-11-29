﻿using System;
using System.Collections;
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
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cID = 0;


        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            // for cb fill
            string qry = "Select catId 'id', catName 'name' from category";
            MainClass.cbFill(qry, cbCat);

            if (cID > 0)
            {
                cbCat.SelectedValue = cID;
            } 

            if (id>0)
            {
                ForUpdateLoadData();
            }    
        }

        string filePath;
        Byte[] imageByteArray;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                imgProduct.Image = new Bitmap(filePath);
            }    
        }

        public override void guna2TileButton1_Click(object sender, EventArgs e)
        {
            string qry = "";
            guna2MessageDialog1.Parent = this;

            if (id == 0)
            {
                qry = "Insert into products Values(@Name, @price, @cat, @img)";
            }
            else // update
            {
                qry = "Update products Set pName = @Name, pPrice = @price, CategoryId = @cat, pImage = @img where pId = @id ";
            }

            // Image
            Image temp = new Bitmap(imgProduct.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id ", id);
            ht.Add("@Name ", txtNameProduct.Text);
            ht.Add("@price ", txtPrice.Text);
            ht.Add("@cat ", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@img ", imageByteArray);


            if (MainClass.SQL(qry, ht) > 0)
            {

                guna2MessageDialog1.Show("Thêm thành công!");
                id = 0;
                cID = 0;
                
                /*txtName.Focus();*/
                this.Close();

            }
        }

        private void ForUpdateLoadData()
        {
            string qry = @"SELECT p.*, c.catName 
               FROM products p 
               INNER JOIN category c ON p.CategoryId = c.catId 
               WHERE p.pId = @id";

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtNameProduct.Text = dt.Rows[0]["pName"].ToString();
                txtPrice.Text = dt.Rows[0]["pPrice"].ToString();
                cbCat.Text = dt.Rows[0]["catName"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                imgProduct.Image = Image.FromStream(new MemoryStream(imageArray));
            }    

        }

        public override void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
