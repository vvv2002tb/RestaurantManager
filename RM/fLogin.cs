using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(0);
        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(1);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // let create database and user table
            if (MainClass.IsValidUser(guna2TextBox1.Text.Trim(), guna2TextBox2.Text.Trim()) == false)
            {
                guna2MessageDialog1.Show("Sai tài khoản mật khẩu!");
            }
            else
            {

                /*System.Threading.Thread.Sleep(1000);*/

                this.Hide();
                fMainManager ftm = new fMainManager();
                ftm.Show();
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = Properties.Settings.Default.username;
            guna2TextBox2.Text = Properties.Settings.Default.password;

            if (Properties.Settings.Default.username != "")
            {
                guna2ToggleSwitch1.Checked = true;
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
            {
                if (guna2ToggleSwitch1.Checked == true)
                {
                    string user = guna2TextBox1.Text.Trim();
                    string pass = guna2TextBox2.Text.Trim();
                    Properties.Settings.Default.username = user;
                    Properties.Settings.Default.password = pass;
                    Properties.Settings.Default.Save();

                }
                else
                {

                    Properties.Settings.Default.Reset();
                }

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox4.Text.Trim();
            string password = guna2TextBox3.Text.Trim();
            string name = guna2TextBox5.Text.Trim();
            string phone = guna2TextBox6.Text.Trim();

            if (guna2CheckBox1.Checked == false)
            {
                guna2MessageDialog1.Show("Chưa chấp nhận điều khoản!");
                // Không thực hiện đăng ký nếu chưa chấp nhận điều khoản
            }
            else
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
                {
                    guna2MessageDialog1.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }



                bool isRegistered = MainClass.RegisterUser(username, password, name, phone);

                if (isRegistered)
                {
                    guna2MessageDialog1.Show("Đăng kí thành công, đăng nhập để sử dụng hệ thống!");
                    
                    guna2TabControl1.SelectTab(0);

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại hoặc có lỗi trong quá trình đăng ký.");
                }
            }
        }
    }
}
