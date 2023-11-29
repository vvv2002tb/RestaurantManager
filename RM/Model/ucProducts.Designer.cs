
namespace RM.Model
{
    partial class ucProducts
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.txtProductNameCard = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPriceProductCard = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.imageProductCard = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageProductCard)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // txtProductNameCard
            // 
            this.txtProductNameCard.BackColor = System.Drawing.Color.Transparent;
            this.txtProductNameCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductNameCard.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txtProductNameCard.Location = new System.Drawing.Point(9, 134);
            this.txtProductNameCard.Name = "txtProductNameCard";
            this.txtProductNameCard.Size = new System.Drawing.Size(91, 19);
            this.txtProductNameCard.TabIndex = 1;
            this.txtProductNameCard.Text = "Product Name";
            this.txtProductNameCard.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPriceProductCard
            // 
            this.txtPriceProductCard.BackColor = System.Drawing.Color.Transparent;
            this.txtPriceProductCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceProductCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPriceProductCard.Location = new System.Drawing.Point(134, 134);
            this.txtPriceProductCard.Name = "txtPriceProductCard";
            this.txtPriceProductCard.Size = new System.Drawing.Size(75, 19);
            this.txtPriceProductCard.TabIndex = 1;
            this.txtPriceProductCard.Text = "10,000 VND";
            this.txtPriceProductCard.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(9, 173);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(102, 19);
            this.guna2HtmlLabel3.TabIndex = 1;
            this.guna2HtmlLabel3.Text = "Thêm sản phẩm";
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::RM.Properties.Resources.icons8_add_50;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButton1.Location = new System.Drawing.Point(176, 167);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(30, 30);
            this.guna2ImageButton1.TabIndex = 2;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // imageProductCard
            // 
            this.imageProductCard.Image = global::RM.Properties.Resources.coffee_main_envat_1280x720_1;
            this.imageProductCard.ImageRotate = 0F;
            this.imageProductCard.Location = new System.Drawing.Point(0, 0);
            this.imageProductCard.Name = "imageProductCard";
            this.imageProductCard.Size = new System.Drawing.Size(221, 119);
            this.imageProductCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageProductCard.TabIndex = 0;
            this.imageProductCard.TabStop = false;
            // 
            // ucProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.txtPriceProductCard);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.txtProductNameCard);
            this.Controls.Add(this.imageProductCard);
            this.Margin = new System.Windows.Forms.Padding(32, 15, 32, 15);
            this.Name = "ucProducts";
            this.Size = new System.Drawing.Size(221, 222);
            ((System.ComponentModel.ISupportInitialize)(this.imageProductCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox imageProductCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtPriceProductCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtProductNameCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
    }
}
