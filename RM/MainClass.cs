using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM
{
    class MainClass
    {
        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        public static SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");

        public static bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            string qpy = @"Select * from account where username = '" + username + "' and  password ='" + password + "' ";
            SqlCommand cmd = new SqlCommand(qpy, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["uName"].ToString();


            }

            return isValid;


        }

        public static bool RegisterUser(string username, string password, string name, string phone)
        {
            bool isRegistered = false;

            try
            {
                con.Open();

                // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                string checkUsernameQuery = "SELECT COUNT(*) FROM account WHERE username = @username";
                using (SqlCommand checkUsernameCmd = new SqlCommand(checkUsernameQuery, con))
                {
                    checkUsernameCmd.Parameters.AddWithValue("@username", username);
                    int existingUserCount = (int)checkUsernameCmd.ExecuteScalar();

                    if (existingUserCount > 0)
                    {
                        // Tên đăng nhập đã tồn tại
                        isRegistered = false;
                    }
                    else
                    {
                        // Tên đăng nhập chưa tồn tại, thực hiện đăng ký
                        string registerQuery = "INSERT INTO account (username, password, uName, uPhone) VALUES (@username, @password, @uName, @uPhone)";
                        using (SqlCommand registerCmd = new SqlCommand(registerQuery, con))
                        {
                            registerCmd.Parameters.AddWithValue("@username", username);
                            registerCmd.Parameters.AddWithValue("@password", password);
                            registerCmd.Parameters.AddWithValue("@uName", name);
                            registerCmd.Parameters.AddWithValue("@uPhone", phone);
                            int rowsAffected = registerCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Đăng ký thành công
                                isRegistered = true;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi đăng ký tài khoản: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return isRegistered;
        }

        // method for crud operation
        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {

                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return res;
        }


        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            // lấy stt
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormating);

            // lấy dữ liệu
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }


        private static void gv_CellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            } 
                
        }

        // làm mờ khi add
        public static void blurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = fMainManager.Instance.Size;
                Background.Location = fMainManager.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();


            }    
        }

        // lấy dữ liệu Category đổ vào cb
        public static void cbFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;

        }

    }
}
