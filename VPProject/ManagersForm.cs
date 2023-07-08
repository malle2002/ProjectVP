using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
    public partial class ManagersForm : Form
    {
        public Game game;
        public ManagersForm(Game game2)
        {
            game = game2;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(game.Stores.Find(x => x.Name.Equals("Lemonade")).IsBought)
            {
                if (game.Money >= 1000)
                {
                    game.Stores.Find(x => x.Name.Equals("Lemonade")).ManagerSet();
                    game.Money -= 1000;
                    button1.Enabled = false;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).IsBought)
            {
                if (game.Money >= 15000)
                {
                    game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).ManagerSet();
                    game.Money -= 15000;
                    button2.Enabled = false;
                }
            }
                
        }
        public void CheckButtons()
        {
            if (game.Stores.Find(x => x.Name.Equals("Lemonade")).hasManager)
            {
                button1.Enabled = false;
            }
            else
            {
                if(game.Money < 1000)
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).hasManager)
            {
                button2.Enabled = false;
            }
            else
            {
                if (game.Money < 15000)
                {
                    button2.Enabled = false;
                }
                else
                {
                    button2.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Car Wash")).hasManager)
            {
                button3.Enabled = false;
            }
            else
            {
                if (game.Money < 100000)
                {
                    button3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Pizza Restaurant")).hasManager)
            {
                button4.Enabled = false;
            }
            else
            {
                if (game.Money < 500000)
                {
                    button4.Enabled = false;
                }
                else
                {
                    button4.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Donut Shop")).hasManager)
            {
                button5.Enabled = false;
            }
            else
            {
                if (game.Money < 1200000)
                {
                    button5.Enabled = false;
                }
                else
                {
                    button5.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Donut Shop")).hasManager)
            {
                button6.Enabled = false;
            }
            else
            {
                if (game.Money < 10000000)
                {
                    button6.Enabled = false;
                }
                else
                {
                    button6.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Hockey Team")).hasManager)
            {
                button7.Enabled = false;
            }
            else
            {
                if (game.Money < 30000000)
                {
                    button7.Enabled = false;
                }
                else
                {
                    button7.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Movie Studio")).hasManager)
            {
                button8.Enabled = false;
            }
            else
            {
                if (game.Money < 60000000)
                {
                    button8.Enabled = false;
                }
                else
                {
                    button8.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Bank")).hasManager)
            {
                button9.Enabled = false;
            }
            else
            {
                if (game.Money < 150000000)
                {
                    button9.Enabled = false;
                }
                else
                {
                    button9.Enabled = true;
                }
            }
            if (game.Stores.Find(x => x.Name.Equals("Oil Company")).hasManager)
            {
                button10.Enabled = false;
            }
            else
            {
                if (game.Money < 450000000)
                {
                    button10.Enabled = false;
                }
                else
                {
                    button10.Enabled = true;
                }
            }
        }

        private void ManagersForm_Load(object sender, EventArgs e)
        {
            CheckButtons();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Car Wash")).IsBought)
            {
                if (game.Money >= 100000)
                {
                    game.Stores.Find(x => x.Name.Equals("Car Wash")).ManagerSet();
                    game.Money -= 100000;
                    button2.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Pizza Restaurant")).IsBought)
            {
                if (game.Money >= 500000)
                {
                    game.Stores.Find(x => x.Name.Equals("Pizza Restaurant")).ManagerSet();
                    game.Money -= 500000;
                    button2.Enabled = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Donut Shop")).IsBought)
            {
                if (game.Money >= 1200000)
                {
                    game.Stores.Find(x => x.Name.Equals("Donut Shop")).ManagerSet();
                    game.Money -= 1200000;
                    button2.Enabled = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Shrimp Shop")).IsBought)
            {
                if (game.Money >= 10000000)
                {
                    game.Stores.Find(x => x.Name.Equals("Shrimp Shop")).ManagerSet();
                    game.Money -= 10000000;
                    button2.Enabled = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Hockey Team")).IsBought)
            {
                if (game.Money >= 30000000)
                {
                    game.Stores.Find(x => x.Name.Equals("Hockey Team")).ManagerSet();
                    game.Money -= 30000000;
                    button2.Enabled = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Movie Studio")).IsBought)
            {
                if (game.Money >= 60000000)
                {
                    game.Stores.Find(x => x.Name.Equals("Movie Studio")).ManagerSet();
                    game.Money -= 60000000;
                    button2.Enabled = false;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Bank")).IsBought)
            {
                if (game.Money >= 150000000)
                {
                    game.Stores.Find(x => x.Name.Equals("Bank")).ManagerSet();
                    game.Money -= 150000000;
                    button2.Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Oil Company")).IsBought)
            {
                if (game.Money >= 450000000)
                {
                    game.Stores.Find(x => x.Name.Equals("Oil Company")).ManagerSet();
                    game.Money -= 450000000;
                    button2.Enabled = false;
                }
            }
        }
    }
}
