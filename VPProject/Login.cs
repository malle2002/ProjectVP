using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VPProject
{
    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        SqlConnection connection;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\atanasPC\source\repos\VPProject\VPProject\Database1.mdf;Integrated Security=True");
            connection.Open();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != string.Empty || tbUsername.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("select * from Users where username='" + tbUsername.Text + "' and password='" + tbPassword.Text + "'", connection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Hide();
                    Home home = new Home(new User(dr.GetString(1), dr.GetInt32(0), Convert.ToDateTime(dr.GetValue(3).ToString())));
                    dr.Close();
                    home.ShowDialog();
                    if(home.DialogResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                    // To-Do deserialization

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
