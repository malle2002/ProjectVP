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

namespace VPProject
{
    public partial class Registration : Form
    {
        SqlConnection connection;
        SqlDataReader dr;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\atanasPC\source\repos\VPProject\VPProject\Database1.mdf;Integrated Security=True");
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
                        cmd = new SqlCommand("INSERT INTO Users (username,password) VALUES(@username,@password)", connection);
                        cmd.Parameters.AddWithValue("username", tbUsername.Text);
                        cmd.Parameters.AddWithValue("password", tbPassword.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Login login = new Login();
                        login.ShowDialog();
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
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
