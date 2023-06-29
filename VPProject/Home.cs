using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPProject;

namespace VPProject
{
    public partial class Home : Form
    {
        public static Game game { get; set; }
        public Home()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Deserialize();
        }
        public void AddStores()
        {
            Store Lemonade = new Store(LemonadeTimer, LemonadeProgressBar, LemonadeButton, this, 1, 3.738, 3000, LemonadeLevel, LemonadeEarnsYouLabel);
            Lemonade.Name = "Lemonade";
            Lemonade.IsBought = true;
            Lemonade.Configuration();
            game.Stores.Add(Lemonade);

            Store NewspaperShop = new Store(NewspaperTimer, NewspaperProgressBar, NewspaperButton, this, 60, 60, 18000, NewspaperLevel, NewspaperEarnsYouLabel);
            NewspaperShop.Name = "Newspaper Shop";
            NewspaperShop.IsBought = false;
            NewspaperShop.Configuration();
            game.Stores.Add(NewspaperShop);
        }
        public void Update()
        {
            InfoLabel.Text = $"Money: ${Game.Money} \t \t \t Gold: {Game.Gold}";
            game.Update();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public static void Serialize()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream($"C:\\CapitalistGame\\SavedGame.sg", FileMode.Create);
                formatter.Serialize(fileStream, game);
            }
            catch (Exception ex)
            {

            }
            
        }
        private void Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                FileStream fileStream = new FileStream($"C:\\CapitalistGame\\SavedGame.sg", FileMode.Open);
                game = (Game)formatter.Deserialize(fileStream);
                game.Update();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                game = new Game();
                AddStores();
                game.Update();
                Home.Serialize();
                this.DialogResult= DialogResult.Cancel;
            }
        }
    }
}