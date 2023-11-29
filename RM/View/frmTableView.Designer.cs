
namespace RM.View
{
    partial class frmTableView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TablePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.messSuccess = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(118, 32);
            this.guna2HtmlLabel2.Text = "Quản lý bàn";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(85, 19);
            this.guna2HtmlLabel1.Text = "Tìm kiếm bàn";
            // 
            // TablePanel
            // 
            this.TablePanel.AutoScroll = true;
            this.TablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TablePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TablePanel.Location = new System.Drawing.Point(31, 156);
            this.TablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(1205, 490);
            this.TablePanel.TabIndex = 4;
            // 
            // messSuccess
            // 
            this.messSuccess.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.messSuccess.Caption = "Thông báo";
            this.messSuccess.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.messSuccess.Parent = null;
            this.messSuccess.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.messSuccess.Text = null;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(91, 84);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(71, 22);
            this.guna2HtmlLabel3.TabIndex = 11;
            this.guna2HtmlLabel3.Text = "Thêm bàn";
            // 
            // frmTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 671);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.TablePanel);
            this.Name = "frmTableView";
            this.Text = "frmTableView";
            this.Load += new System.EventHandler(this.frmTableView_Load);
            this.Controls.SetChildIndex(this.TablePanel, 0);
            this.Controls.SetChildIndex(this.guna2ImageButton1, 0);
            this.Controls.SetChildIndex(this.guna2HtmlLabel1, 0);
            this.Controls.SetChildIndex(this.guna2HtmlLabel2, 0);
            this.Controls.SetChildIndex(this.guna2HtmlLabel3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI2.WinForms.Guna2MessageDialog messSuccess;
        public System.Windows.Forms.FlowLayoutPanel TablePanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    }
}