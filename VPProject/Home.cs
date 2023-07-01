using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPProject;

namespace VPProject
{
    public partial class Home : Form
    {
        public Game game { get; set; }
        public Home()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Deserialize();
        }
        public void AddStores()
        {
            Store Lemonade = new Store(LemonadeTimer, LemonadeProgressBar, LemonadeButton, 1, 3.738, 3000, LemonadeLevel, LemonadeEarnsYouLabel,game,true);
            Lemonade.Name = "Lemonade";
            Lemonade.game = game;
            Lemonade.Configuration();
            game.Stores.Add(Lemonade);

            Store NewspaperShop = new Store(NewspaperTimer, NewspaperProgressBar, NewspaperButton, 60, 60, 18000, NewspaperLevel, NewspaperEarnsYouLabel,game,false);
            NewspaperShop.Name = "Newspaper Shop";
            NewspaperShop.game = game;
            NewspaperShop.Configuration();
            game.Stores.Add(NewspaperShop);
        }
        public void Update()
        {     
            game.Update();
        }
        public void Update2()
        {
            InfoLabel.Text = $"Money: ${this.game.Money} \t \t \t Gold: {this.game.Gold}";
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public void Serialize()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream($"C:\\CapitalistGame\\SavedGame.sg", FileMode.Create);
                List<StoreDto> newListStoreDto = new List<StoreDto>();
                GameDto gameDto = new GameDto
                {
                    Money = game.Money,
                    Gold = game.Gold
                };
                game.Stores.ForEach(x =>
                {
                    newListStoreDto.Add(new StoreDto
                    {
                        ProgressBar = new ProgressBarDto
                        {
                            Name = x.ProgressBar.Name,
                            Value = x.ProgressBar.Value,
                            Minimum = x.ProgressBar.Minimum,
                            Maximum = x.ProgressBar.Maximum,
                        },
                        Button = new ButtonDto
                        {
                            Text = x.UpgradeButton.Text,
                            Left = x.UpgradeButton.Left,
                            Top = x.UpgradeButton.Top,
                            Width = x.UpgradeButton.Width,
                            Height = x.UpgradeButton.Height,
                            Name = x.UpgradeButton.Name
                        },
                        Timer = new TimerDto
                        {
                            Interval = x.Timer.Interval,
                            Enabled = x.Timer.Enabled
                        },
                        Label = new LabelDto
                        {
                            Text = x.Label.Text,
                            Left = x.Label.Left,
                            Top = x.Label.Top,
                            Width = x.Label.Width,
                            Height = x.Label.Height,
                            Name = x.Label.Name
                        },
                        Label2 = new LabelDto
                        {
                            Text = x.EarnLabel.Text,
                            Left = x.EarnLabel.Left,
                            Top = x.EarnLabel.Top,
                            Width = x.EarnLabel.Width,
                            Height = x.EarnLabel.Height,
                            Name = x.EarnLabel.Name
                        },
                        Name = x.Name,
                        Interval = x.Interval,
                        Num_Upgrades = x.Num_Upgrades,
                        BaseCost = x.BaseCost,
                        BaseMoney = x.BaseMoney,
                        MoneyMaking = x.MoneyMaking,
                        BaseInterval = x.BaseInterval,
                        CostOfUpgrade = x.CostOfUpgrade,
                        IntervalReducer = x.IntervalReducer,
                        EarnMultiplier = x.EarnMultiplier,
                        Clicked = x.Clicked,
                        IsBought = x.IsBought,
                        hasManager = x.hasManager,
                        game = gameDto
                    });
                });
                gameDto.Stores = newListStoreDto;
                formatter.Serialize(fileStream, gameDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("2");
                MessageBox.Show(ex.Message);
            }
            
        }
        private void Deserialize()
        {

            if (File.Exists($"C:\\CapitalistGame\\SavedGame.sg"))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    FileStream fileStream = new FileStream($"C:\\CapitalistGame\\SavedGame.sg", FileMode.Open);
                    GameDto gameDto = (GameDto)formatter.Deserialize(fileStream);
                    List<Store> newListStore = new List<Store>();
                    game = new Game
                    {
                        Money = gameDto.Money,
                        Gold = gameDto.Gold
                    };
                    gameDto.Stores.ForEach(x =>
                    {
                        ProgressBar pbd = new CustomProgressBar
                        {
                            Name = x.ProgressBar.Name,
                            Value = x.ProgressBar.Value,
                            Minimum = x.ProgressBar.Minimum,
                            Maximum = x.ProgressBar.Maximum
                        };
                        Button bd = new Button
                        {
                            Text = x.Button.Text,
                            Left = x.Button.Left,
                            Top = x.Button.Top,
                            Width = x.Button.Width,
                            Height = x.Button.Height,
                            Name = x.Button.Name
                        };
                        Timer dt = new Timer
                        {
                            Interval = x.Timer.Interval,
                            Enabled = x.Timer.Enabled
                        };
                        System.Windows.Forms.Label ld = new System.Windows.Forms.Label
                        {
                            Text = x.Label.Text,
                            Left = x.Label.Left,
                            Top = x.Label.Top,
                            Width = x.Label.Width,
                            Height = x.Label.Height,
                            Name = x.Label.Name
                        };
                        System.Windows.Forms.Label ld2 = new System.Windows.Forms.Label
                        {
                            Text = x.Label2.Text,
                            Left = x.Label2.Left,
                            Top = x.Label2.Top,
                            Width = x.Label2.Width,
                            Height = x.Label2.Height,
                            Name = x.Label2.Name
                        };
                        newListStore.Add(new Store(dt, pbd, bd, x.BaseMoney, x.BaseCost, x.BaseInterval, ld, ld2, game, x.IsBought)
                        {
                            Name = x.Name,
                            Interval = x.Interval,
                            Num_Upgrades = x.Num_Upgrades,
                            BaseCost = x.BaseCost,
                            BaseMoney = x.BaseMoney,
                            MoneyMaking = x.MoneyMaking,
                            BaseInterval = x.BaseInterval,
                            CostOfUpgrade = x.CostOfUpgrade,
                            IntervalReducer = x.IntervalReducer,
                            EarnMultiplier = x.EarnMultiplier,
                            Clicked = x.Clicked,
                            IsBought = x.IsBought,
                            hasManager = x.hasManager,
                            game = game
                        });
                    });
                    game.Stores = newListStore;
                    game.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("1");
                }
                
            }
            else
            {
                game = new Game();
                AddStores();
                Serialize();
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialize();
        }
    }
}