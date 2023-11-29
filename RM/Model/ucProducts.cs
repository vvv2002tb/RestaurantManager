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
    public partial class ucProducts : UserControl
    {

        public ucProducts()
        {
            InitializeComponent();
        }
        public event EventHandler onSelectAdd = null;
        public int id { get; set; }

        public string productPrice {
            get { return txtPriceProductCard.Text; }
            set { txtPriceProductCard.Text = value; }
        }
        public string productCat { get; set; }

        public string productName
        {
            get { return txtProductNameCard.Text; }
            set { txtProductNameCard.Text = value; }
        }

        
        
        public Image productImage
        {
            get { return imageProductCard.Image; }
            set { imageProductCard.Image = value; }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            onSelectAdd.Invoke(this, e);
            MessageBox.Show(productName);
        }
    }
    
}
