using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
    public partial class ShopForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Game Game { get; set; }
        public ShopForm(Game game)
        {
            Game = game;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LemonadeButton_Click(object sender, EventArgs e)
        {
            if (Game.Gold >= 50)
            {
                Game.Stores.Find(x=>x.Name.Equals("Lemonade")).hasBoughtMultiplier = true;
                Game.Stores.Find(x => x.Name.Equals("Lemonade")).EarnMultiplier *= 3;
                LemonadeButton.Enabled = false;
            }
        }

        private void NewspaperButton_Click(object sender, EventArgs e)
        {
            if (Game.Gold >= 100)
            {
                Game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).hasBoughtMultiplier = true;
                Game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).EarnMultiplier *= 3;
                NewspaperButton.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Game.Gold >= 150)
            {
                Game.Stores.Find(x=>x.Name.Equals("Car Wash")).hasBoughtMultiplier = true;
                Game.Stores.Find(x => x.Name.Equals("Car Wash")).EarnMultiplier *= 3;
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Game.Gold >= 250)
            {
                Game.HasBoughtEverythingX3 = true;
                Game.Stores.ForEach(x => x.EarnMultiplier *= 3);
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Game.Gold >= 1000)
            {
                Game.HasBoughtEverything2 = true;
                Game.Stores.ForEach(x => x.EarnMultiplier *= 3);
                button4.Enabled = false;
            }
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            if(Game.Stores.Find(x=>x.Name.Equals("Lemonade")).hasBoughtMultiplier)
            {
                LemonadeButton.Enabled = false;
            }
            if (Game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).hasBoughtMultiplier)
            {
                NewspaperButton.Enabled = false;
            }
            if (Game.Stores.Find(x => x.Name.Equals("Car Wash")).hasBoughtMultiplier)
            {
                button2.Enabled = false;
            }
            if (Game.HasBoughtEverythingX3)
            {
                button3.Enabled = false;
            }
            if (Game.HasBoughtEverything2)
            {
                button4.Enabled = false;
            }
        }
    }
}
