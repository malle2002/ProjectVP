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
                if (game.Money >= 500)
                {
                    game.Stores.Find(x => x.Name.Equals("Lemonade")).ManagerSet();
                    game.Money -= 500;
                    button1.Enabled = false;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).IsBought)
            {
                if (game.Money >= 2500)
                {
                    game.Stores.Find(x => x.Name.Equals("Newspaper Shop")).ManagerSet();
                    game.Money -= 2500;
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
                if(game.Money < 500)
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
                if (game.Money < 2500)
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
                if (game.Money < 12500)
                {
                    button3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
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
                if (game.Money >= 12500)
                {
                    game.Stores.Find(x => x.Name.Equals("Car Wash")).ManagerSet();
                    game.Money -= 12500;
                    button2.Enabled = false;
                }
            }
        }
    }
}
