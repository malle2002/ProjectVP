using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace VPProject
{
    public partial class Registration : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        SqlConnection connection;
        SqlDataReader dr;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(Environment.CurrentDirectory);
            string databaseName = "Database1.mdf";
            string fullpath = path + @"\" + databaseName;
            MessageBox.Show(fullpath);
            if (File.Exists(fullpath))
            {
                connection = new SqlConnection($"Server=DESKTOP-5OTFSPI;Database=Users;User Id=sa;Password=ASds12:D;");
                //connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + databaseName + "; Integrated Security=True");
            }
            else
            {
                throw new Exception("Database Not Found :(");
            }
            connection.Open();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (tbRepeatPassword.Text != string.Empty || tbPassword.Text != string.Empty || tbUsername.Text != string.Empty)
            {
                if (tbPassword.Text == tbRepeatPassword.Text)
                {
                    SqlCommand cmd = new SqlCommand("select * from Users where username='" + tbUsername.Text + "'", connection);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand($"INSERT INTO Users (username,password,lastlogin) VALUES(@username,@password,@date)", connection);
                        cmd.Parameters.AddWithValue("username", tbUsername.Text);
                        cmd.Parameters.AddWithValue("password", tbPassword.Text);
                        cmd.Parameters.AddWithValue("date", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
