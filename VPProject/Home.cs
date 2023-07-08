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
using System.Runtime.InteropServices;
using VPProject;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace VPProject
{
    [Serializable]
    public partial class Home : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Game game { get; set; }
        public User user { get; set; }
        SqlConnection connection;
        public Home(User user2)
        {
            string path = Path.GetFullPath(Environment.CurrentDirectory);
            string databaseName = "Database1.mdf";
            string fullpath = path + @"\" + databaseName;
            if (File.Exists(fullpath))
            {
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + databaseName + "; Integrated Security=True");
            }
            else
            {
                throw new Exception("Database Not Found :(");
            }
            connection.Open();
            user = user2;
            InitializeComponent();
            this.DoubleBuffered = true;
            Deserialize();
        }
        public void AddStores()
        {
            Store Lemonade = new Store(LemonadeTimer, LemonadeProgressBar, LemonadeButton, 1, 3.738, 600, LemonadeLevel, LemonadeEarnsYouLabel,game,true);
            Lemonade.Name = "Lemonade";
            Lemonade.game = game;
            Lemonade.Configuration();
            game.Stores.Add(Lemonade);

            Store NewspaperShop = new Store(NewspaperTimer, NewspaperProgressBar, NewspaperButton, 60, 60, 3000, NewspaperLevel, NewspaperEarnsYouLabel,game,false);
            NewspaperShop.Name = "Newspaper Shop";
            NewspaperShop.game = game;
            NewspaperShop.Configuration();
            game.Stores.Add(NewspaperShop);

            Store CarWash = new Store(CarWashTimer, CarWashProgressBar, CarWashButton, 720, 720, 6000, CarWashLevel, CarWashEarnsYouLabel, game, false);
            CarWash.Name = "Car Wash";
            CarWash.game = game;
            CarWash.Configuration();
            game.Stores.Add(CarWash);

            Store Pizza = new Store(PizzaTimer, PizzaProgressBar, PizzaButton, 8640, 8640, 12000, PizzaLevel, PizzaEarnsYouLabel, game, false);
            Pizza.Name = "Pizza Restaurant";
            Pizza.game = game;
            Pizza.Configuration();
            game.Stores.Add(Pizza);

            Store Donut = new Store(DonutTimer, DonutProgressBar, DonutButton, 103680, 103680, 24000, DonutLevel, DonutEarnsYouLabel, game, false);
            Donut.Name = "Donut Shop";
            Donut.game = game;
            Donut.Configuration();
            game.Stores.Add(Donut);

            Store Shrimp = new Store(ShrimpTimer, ShrimpProgressBar, ShrimpButton, 1244160, 1244160, 96000, ShrimpLevel, ShrimpEarnsYouLabel, game, false);
            Shrimp.Name = "Shrimp Shop";
            Shrimp.game = game;
            Shrimp.Configuration();
            game.Stores.Add(Shrimp);

            Store Hockey = new Store(HockeyTimer, HockeyProgressBar, HockeyButton, 14929920, 14929920, 384000, HockeyLevel, HockeyEarnsYouLabel, game, false);
            Hockey.Name = "Hockey Team";
            Hockey.game = game;
            Hockey.Configuration();
            game.Stores.Add(Hockey);

            Store Movie = new Store(MovieTimer, MovieProgressBar, MovieButton, 179159040, 179159040, 1536000, MovieLevel, MovieEarnsYouLabel, game, false);
            Movie.Name = "Movie Studio";
            Movie.game = game;
            Movie.Configuration();
            game.Stores.Add(Movie);

            Store Bank = new Store(BankTimer, BankProgressBar, BankButton, 350908480, 350908480, 3000000, BankLevel, BankEarnsYouLabel, game, false);
            Bank.Name = "Bank";
            Bank.game = game;
            Bank.Configuration();
            game.Stores.Add(Bank);

            Store OilCompany = new Store(OilCompanyTimer, OilCompanyProgressBar, OilCompanyButton, 650908480, 650908480, 5000000, OilCompanyLevel, OilCompanyEarnsYouLabel, game, false);
            OilCompany.Name = "Oil Company";
            OilCompany.game = game;
            OilCompany.Configuration();
            game.Stores.Add(OilCompany);
        }
        public void Update()
        {     
            game.Update();
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
                FileStream fileStream = new FileStream($"C:\\CapitalistGame\\SavedGame{user.Id}.sg",
                                                       FileMode.Create,
                                                       FileAccess.Write,
                                                       FileShare.None,
                                                       bufferSize:4096,
                                                       useAsync: true);
                List<StoreDto> newListStoreDto = new List<StoreDto>();
                GameDto gameDto = new GameDto
                {
                    Money = game.Money,
                    Gold = game.Gold,
                    HasBoughtEverything2 = game.HasBoughtEverything2,
                    HasBoughtEverythingX3 = game.HasBoughtEverythingX3
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
                            Text = x.ProgressBar.Text
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
                        game = gameDto,
                        hasBoughtMultiplier = x.hasBoughtMultiplier,
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

            if (File.Exists($"C:\\CapitalistGame\\SavedGame{user.Id}.sg"))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    FileStream fileStream = new FileStream($"C:\\CapitalistGame\\SavedGame{user.Id}.sg", FileMode.Open);
                    GameDto gameDto = (GameDto)formatter.Deserialize(fileStream);
                    List<Store> newListStore = new List<Store>();
                    game = new Game(InfoLabel);
                    AddStores();
                    game.Money = gameDto.Money;
                    game.Gold = gameDto.Gold;
                    game.HasBoughtEverything2 = gameDto.HasBoughtEverything2;
                    game.HasBoughtEverythingX3 = gameDto.HasBoughtEverythingX3;
                    game.Stores.ElementAt(0).ProgressBar.Value = gameDto.Stores.ElementAt(0).ProgressBar.Value;
                    game.Stores.ElementAt(0).UpgradeButton.Text = gameDto.Stores.ElementAt(0).Button.Text;
                    game.Stores.ElementAt(0).Label.Text = gameDto.Stores.ElementAt(0).Label.Text;
                    game.Stores.ElementAt(0).EarnLabel.Text = gameDto.Stores.ElementAt(0).Label2.Text;
                    game.Stores.ElementAt(0).Interval = gameDto.Stores.ElementAt(0).Interval;
                    game.Stores.ElementAt(0).MoneyMaking = gameDto.Stores.ElementAt(0).MoneyMaking;
                    game.Stores.ElementAt(0).IsBought = gameDto.Stores.ElementAt(0).IsBought;
                    game.Stores.ElementAt(0).BaseCost = gameDto.Stores.ElementAt(0).BaseCost;
                    game.Stores.ElementAt(0).Clicked = gameDto.Stores.ElementAt(0).Clicked;
                    game.Stores.ElementAt(0).BaseInterval = gameDto.Stores.ElementAt(0).BaseInterval;
                    game.Stores.ElementAt(0).CostOfUpgrade = gameDto.Stores.ElementAt(0).CostOfUpgrade;
                    game.Stores.ElementAt(0).EarnMultiplier = gameDto.Stores.ElementAt(0).EarnMultiplier;
                    game.Stores.ElementAt(0).IntervalReducer = gameDto.Stores.ElementAt(0).IntervalReducer;
                    game.Stores.ElementAt(0).hasManager = gameDto.Stores.ElementAt(0).hasManager;
                    if (game.Stores.ElementAt(0).hasManager)
                    {
                        game.Stores.ElementAt(0).ManagerSet();
                    }
                    game.Stores.ElementAt(0).hasBoughtMultiplier = gameDto.Stores.ElementAt(0).hasBoughtMultiplier;
                    game.Stores.ElementAt(0).Num_Upgrades = gameDto.Stores.ElementAt(0).Num_Upgrades;

                    game.Stores.ElementAt(1).ProgressBar.Value = gameDto.Stores.ElementAt(1).ProgressBar.Value;
                    game.Stores.ElementAt(1).UpgradeButton.Text = gameDto.Stores.ElementAt(1).Button.Text;
                    game.Stores.ElementAt(1).Label.Text = gameDto.Stores.ElementAt(1).Label.Text;
                    game.Stores.ElementAt(1).EarnLabel.Text = gameDto.Stores.ElementAt(1).Label2.Text;
                    game.Stores.ElementAt(1).Interval = gameDto.Stores.ElementAt(1).Interval;
                    game.Stores.ElementAt(1).MoneyMaking = gameDto.Stores.ElementAt(1).MoneyMaking;
                    game.Stores.ElementAt(1).IsBought = gameDto.Stores.ElementAt(1).IsBought;
                    game.Stores.ElementAt(1).BaseCost = gameDto.Stores.ElementAt(1).BaseCost;
                    game.Stores.ElementAt(1).Clicked = gameDto.Stores.ElementAt(1).Clicked;
                    game.Stores.ElementAt(1).BaseInterval = gameDto.Stores.ElementAt(1).BaseInterval;
                    game.Stores.ElementAt(1).CostOfUpgrade = gameDto.Stores.ElementAt(1).CostOfUpgrade;
                    game.Stores.ElementAt(1).EarnMultiplier = gameDto.Stores.ElementAt(1).EarnMultiplier;
                    game.Stores.ElementAt(1).IntervalReducer = gameDto.Stores.ElementAt(1).IntervalReducer;
                    game.Stores.ElementAt(1).hasManager = gameDto.Stores.ElementAt(1).hasManager;
                    if (game.Stores.ElementAt(1).hasManager)
                    {
                        game.Stores.ElementAt(1).ManagerSet();
                    }
                    game.Stores.ElementAt(1).hasBoughtMultiplier = gameDto.Stores.ElementAt(1).hasBoughtMultiplier;
                    game.Stores.ElementAt(1).Num_Upgrades = gameDto.Stores.ElementAt(1).Num_Upgrades;

                    game.Stores.ElementAt(2).ProgressBar.Value = gameDto.Stores.ElementAt(2).ProgressBar.Value;
                    game.Stores.ElementAt(2).UpgradeButton.Text = gameDto.Stores.ElementAt(2).Button.Text;
                    game.Stores.ElementAt(2).Label.Text = gameDto.Stores.ElementAt(2).Label.Text;
                    game.Stores.ElementAt(2).EarnLabel.Text = gameDto.Stores.ElementAt(2).Label2.Text;
                    game.Stores.ElementAt(2).Interval = gameDto.Stores.ElementAt(2).Interval;
                    game.Stores.ElementAt(2).MoneyMaking = gameDto.Stores.ElementAt(2).MoneyMaking;
                    game.Stores.ElementAt(2).IsBought = gameDto.Stores.ElementAt(2).IsBought;
                    game.Stores.ElementAt(2).BaseCost = gameDto.Stores.ElementAt(2).BaseCost;
                    game.Stores.ElementAt(2).Clicked = gameDto.Stores.ElementAt(2).Clicked;
                    game.Stores.ElementAt(2).BaseInterval = gameDto.Stores.ElementAt(2).BaseInterval;
                    game.Stores.ElementAt(2).CostOfUpgrade = gameDto.Stores.ElementAt(2).CostOfUpgrade;
                    game.Stores.ElementAt(2).EarnMultiplier = gameDto.Stores.ElementAt(2).EarnMultiplier;
                    game.Stores.ElementAt(2).IntervalReducer = gameDto.Stores.ElementAt(2).IntervalReducer;
                    game.Stores.ElementAt(2).hasManager = gameDto.Stores.ElementAt(2).hasManager;
                    if (game.Stores.ElementAt(2).hasManager)
                    {
                        game.Stores.ElementAt(2).ManagerSet();
                    }
                    game.Stores.ElementAt(2).hasBoughtMultiplier = gameDto.Stores.ElementAt(2).hasBoughtMultiplier;
                    game.Stores.ElementAt(2).Num_Upgrades = gameDto.Stores.ElementAt(2).Num_Upgrades;

                    game.Stores.ElementAt(3).ProgressBar.Value = gameDto.Stores.ElementAt(3).ProgressBar.Value;
                    game.Stores.ElementAt(3).UpgradeButton.Text = gameDto.Stores.ElementAt(3).Button.Text;
                    game.Stores.ElementAt(3).Label.Text = gameDto.Stores.ElementAt(3).Label.Text;
                    game.Stores.ElementAt(3).EarnLabel.Text = gameDto.Stores.ElementAt(3).Label2.Text;
                    game.Stores.ElementAt(3).Interval = gameDto.Stores.ElementAt(3).Interval;
                    game.Stores.ElementAt(3).MoneyMaking = gameDto.Stores.ElementAt(3).MoneyMaking;
                    game.Stores.ElementAt(3).IsBought = gameDto.Stores.ElementAt(3).IsBought;
                    game.Stores.ElementAt(3).BaseCost = gameDto.Stores.ElementAt(3).BaseCost;
                    game.Stores.ElementAt(3).Clicked = gameDto.Stores.ElementAt(3).Clicked;
                    game.Stores.ElementAt(3).BaseInterval = gameDto.Stores.ElementAt(3).BaseInterval;
                    game.Stores.ElementAt(3).CostOfUpgrade = gameDto.Stores.ElementAt(3).CostOfUpgrade;
                    game.Stores.ElementAt(3).EarnMultiplier = gameDto.Stores.ElementAt(3).EarnMultiplier;
                    game.Stores.ElementAt(3).IntervalReducer = gameDto.Stores.ElementAt(3).IntervalReducer;
                    game.Stores.ElementAt(3).hasManager = gameDto.Stores.ElementAt(3).hasManager;
                    if (game.Stores.ElementAt(3).hasManager)
                    {
                        game.Stores.ElementAt(3).ManagerSet();
                    }
                    game.Stores.ElementAt(3).hasBoughtMultiplier = gameDto.Stores.ElementAt(3).hasBoughtMultiplier;
                    game.Stores.ElementAt(3).Num_Upgrades = gameDto.Stores.ElementAt(3).Num_Upgrades;

                    game.Stores.ElementAt(4).ProgressBar.Value = gameDto.Stores.ElementAt(4).ProgressBar.Value;
                    game.Stores.ElementAt(4).UpgradeButton.Text = gameDto.Stores.ElementAt(4).Button.Text;
                    game.Stores.ElementAt(4).Label.Text = gameDto.Stores.ElementAt(4).Label.Text;
                    game.Stores.ElementAt(4).EarnLabel.Text = gameDto.Stores.ElementAt(4).Label2.Text;
                    game.Stores.ElementAt(4).Interval = gameDto.Stores.ElementAt(4).Interval;
                    game.Stores.ElementAt(4).MoneyMaking = gameDto.Stores.ElementAt(4).MoneyMaking;
                    game.Stores.ElementAt(4).IsBought = gameDto.Stores.ElementAt(4).IsBought;
                    game.Stores.ElementAt(4).BaseCost = gameDto.Stores.ElementAt(4).BaseCost;
                    game.Stores.ElementAt(4).Clicked = gameDto.Stores.ElementAt(4).Clicked;
                    game.Stores.ElementAt(4).BaseInterval = gameDto.Stores.ElementAt(4).BaseInterval;
                    game.Stores.ElementAt(4).CostOfUpgrade = gameDto.Stores.ElementAt(4).CostOfUpgrade;
                    game.Stores.ElementAt(4).EarnMultiplier = gameDto.Stores.ElementAt(4).EarnMultiplier;
                    game.Stores.ElementAt(4).IntervalReducer = gameDto.Stores.ElementAt(4).IntervalReducer;
                    game.Stores.ElementAt(4).hasManager = gameDto.Stores.ElementAt(4).hasManager;
                    if (game.Stores.ElementAt(4).hasManager)
                    {
                        game.Stores.ElementAt(4).ManagerSet();
                    }
                    game.Stores.ElementAt(4).hasBoughtMultiplier = gameDto.Stores.ElementAt(4).hasBoughtMultiplier;
                    game.Stores.ElementAt(4).Num_Upgrades = gameDto.Stores.ElementAt(4).Num_Upgrades;

                    game.Stores.ElementAt(5).ProgressBar.Value = gameDto.Stores.ElementAt(5).ProgressBar.Value;
                    game.Stores.ElementAt(5).UpgradeButton.Text = gameDto.Stores.ElementAt(5).Button.Text;
                    game.Stores.ElementAt(5).Label.Text = gameDto.Stores.ElementAt(5).Label.Text;
                    game.Stores.ElementAt(5).EarnLabel.Text = gameDto.Stores.ElementAt(5).Label2.Text;
                    game.Stores.ElementAt(5).Interval = gameDto.Stores.ElementAt(5).Interval;
                    game.Stores.ElementAt(5).MoneyMaking = gameDto.Stores.ElementAt(5).MoneyMaking;
                    game.Stores.ElementAt(5).IsBought = gameDto.Stores.ElementAt(5).IsBought;
                    game.Stores.ElementAt(5).BaseCost = gameDto.Stores.ElementAt(5).BaseCost;
                    game.Stores.ElementAt(5).Clicked = gameDto.Stores.ElementAt(5).Clicked;
                    game.Stores.ElementAt(5).BaseInterval = gameDto.Stores.ElementAt(5).BaseInterval;
                    game.Stores.ElementAt(5).CostOfUpgrade = gameDto.Stores.ElementAt(5).CostOfUpgrade;
                    game.Stores.ElementAt(5).EarnMultiplier = gameDto.Stores.ElementAt(5).EarnMultiplier;
                    game.Stores.ElementAt(5).IntervalReducer = gameDto.Stores.ElementAt(5).IntervalReducer;
                    game.Stores.ElementAt(5).hasManager = gameDto.Stores.ElementAt(5).hasManager;
                    if (game.Stores.ElementAt(5).hasManager)
                    {
                        game.Stores.ElementAt(5).ManagerSet();
                    }
                    game.Stores.ElementAt(5).hasBoughtMultiplier = gameDto.Stores.ElementAt(5).hasBoughtMultiplier;
                    game.Stores.ElementAt(5).Num_Upgrades = gameDto.Stores.ElementAt(5).Num_Upgrades;

                    game.Stores.ElementAt(6).ProgressBar.Value = gameDto.Stores.ElementAt(6).ProgressBar.Value;
                    game.Stores.ElementAt(6).UpgradeButton.Text = gameDto.Stores.ElementAt(6).Button.Text;
                    game.Stores.ElementAt(6).Label.Text = gameDto.Stores.ElementAt(6).Label.Text;
                    game.Stores.ElementAt(6).EarnLabel.Text = gameDto.Stores.ElementAt(6).Label2.Text;
                    game.Stores.ElementAt(6).Interval = gameDto.Stores.ElementAt(6).Interval;
                    game.Stores.ElementAt(6).MoneyMaking = gameDto.Stores.ElementAt(6).MoneyMaking;
                    game.Stores.ElementAt(6).IsBought = gameDto.Stores.ElementAt(6).IsBought;
                    game.Stores.ElementAt(6).BaseCost = gameDto.Stores.ElementAt(6).BaseCost;
                    game.Stores.ElementAt(6).Clicked = gameDto.Stores.ElementAt(6).Clicked;
                    game.Stores.ElementAt(6).BaseInterval = gameDto.Stores.ElementAt(6).BaseInterval;
                    game.Stores.ElementAt(6).CostOfUpgrade = gameDto.Stores.ElementAt(6).CostOfUpgrade;
                    game.Stores.ElementAt(6).EarnMultiplier = gameDto.Stores.ElementAt(6).EarnMultiplier;
                    game.Stores.ElementAt(6).IntervalReducer = gameDto.Stores.ElementAt(6).IntervalReducer;
                    game.Stores.ElementAt(6).hasManager = gameDto.Stores.ElementAt(6).hasManager;
                    if (game.Stores.ElementAt(6).hasManager)
                    {
                        game.Stores.ElementAt(6).ManagerSet();
                    }
                    game.Stores.ElementAt(6).hasBoughtMultiplier = gameDto.Stores.ElementAt(6).hasBoughtMultiplier;
                    game.Stores.ElementAt(6).Num_Upgrades = gameDto.Stores.ElementAt(6).Num_Upgrades;

                    game.Stores.ElementAt(7).ProgressBar.Value = gameDto.Stores.ElementAt(7).ProgressBar.Value;
                    game.Stores.ElementAt(7).UpgradeButton.Text = gameDto.Stores.ElementAt(7).Button.Text;
                    game.Stores.ElementAt(7).Label.Text = gameDto.Stores.ElementAt(7).Label.Text;
                    game.Stores.ElementAt(7).EarnLabel.Text = gameDto.Stores.ElementAt(7).Label2.Text;
                    game.Stores.ElementAt(7).Interval = gameDto.Stores.ElementAt(7).Interval;
                    game.Stores.ElementAt(7).MoneyMaking = gameDto.Stores.ElementAt(7).MoneyMaking;
                    game.Stores.ElementAt(7).IsBought = gameDto.Stores.ElementAt(7).IsBought;
                    game.Stores.ElementAt(7).BaseCost = gameDto.Stores.ElementAt(7).BaseCost;
                    game.Stores.ElementAt(7).Clicked = gameDto.Stores.ElementAt(7).Clicked;
                    game.Stores.ElementAt(7).BaseInterval = gameDto.Stores.ElementAt(7).BaseInterval;
                    game.Stores.ElementAt(7).CostOfUpgrade = gameDto.Stores.ElementAt(7).CostOfUpgrade;
                    game.Stores.ElementAt(7).EarnMultiplier = gameDto.Stores.ElementAt(7).EarnMultiplier;
                    game.Stores.ElementAt(7).IntervalReducer = gameDto.Stores.ElementAt(7).IntervalReducer;
                    game.Stores.ElementAt(7).hasManager = gameDto.Stores.ElementAt(7).hasManager;
                    if (game.Stores.ElementAt(7).hasManager)
                    {
                        game.Stores.ElementAt(7).ManagerSet();
                    }
                    game.Stores.ElementAt(7).hasBoughtMultiplier = gameDto.Stores.ElementAt(7).hasBoughtMultiplier;
                    game.Stores.ElementAt(7).Num_Upgrades = gameDto.Stores.ElementAt(7).Num_Upgrades;

                    game.Stores.ElementAt(8).ProgressBar.Value = gameDto.Stores.ElementAt(8).ProgressBar.Value;
                    game.Stores.ElementAt(8).UpgradeButton.Text = gameDto.Stores.ElementAt(8).Button.Text;
                    game.Stores.ElementAt(8).Label.Text = gameDto.Stores.ElementAt(8).Label.Text;
                    game.Stores.ElementAt(8).EarnLabel.Text = gameDto.Stores.ElementAt(8).Label2.Text;
                    game.Stores.ElementAt(8).Interval = gameDto.Stores.ElementAt(8).Interval;
                    game.Stores.ElementAt(8).MoneyMaking = gameDto.Stores.ElementAt(8).MoneyMaking;
                    game.Stores.ElementAt(8).IsBought = gameDto.Stores.ElementAt(8).IsBought;
                    game.Stores.ElementAt(8).BaseCost = gameDto.Stores.ElementAt(8).BaseCost;
                    game.Stores.ElementAt(8).Clicked = gameDto.Stores.ElementAt(8).Clicked;
                    game.Stores.ElementAt(8).BaseInterval = gameDto.Stores.ElementAt(8).BaseInterval;
                    game.Stores.ElementAt(8).CostOfUpgrade = gameDto.Stores.ElementAt(8).CostOfUpgrade;
                    game.Stores.ElementAt(8).EarnMultiplier = gameDto.Stores.ElementAt(8).EarnMultiplier;
                    game.Stores.ElementAt(8).IntervalReducer = gameDto.Stores.ElementAt(8).IntervalReducer;
                    game.Stores.ElementAt(8).hasManager = gameDto.Stores.ElementAt(8).hasManager;
                    if (game.Stores.ElementAt(8).hasManager)
                    {
                        game.Stores.ElementAt(8).ManagerSet();
                    }
                    game.Stores.ElementAt(8).hasBoughtMultiplier = gameDto.Stores.ElementAt(8).hasBoughtMultiplier;
                    game.Stores.ElementAt(8).Num_Upgrades = gameDto.Stores.ElementAt(8).Num_Upgrades;

                    game.Stores.ElementAt(9).ProgressBar.Value = gameDto.Stores.ElementAt(9).ProgressBar.Value;
                    game.Stores.ElementAt(9).UpgradeButton.Text = gameDto.Stores.ElementAt(9).Button.Text;
                    game.Stores.ElementAt(9).Label.Text = gameDto.Stores.ElementAt(9).Label.Text;
                    game.Stores.ElementAt(9).EarnLabel.Text = gameDto.Stores.ElementAt(9).Label2.Text;
                    game.Stores.ElementAt(9).Interval = gameDto.Stores.ElementAt(9).Interval;
                    game.Stores.ElementAt(9).MoneyMaking = gameDto.Stores.ElementAt(9).MoneyMaking;
                    game.Stores.ElementAt(9).IsBought = gameDto.Stores.ElementAt(9).IsBought;
                    game.Stores.ElementAt(9).BaseCost = gameDto.Stores.ElementAt(9).BaseCost;
                    game.Stores.ElementAt(9).Clicked = gameDto.Stores.ElementAt(9).Clicked;
                    game.Stores.ElementAt(9).BaseInterval = gameDto.Stores.ElementAt(9).BaseInterval;
                    game.Stores.ElementAt(9).CostOfUpgrade = gameDto.Stores.ElementAt(9).CostOfUpgrade;
                    game.Stores.ElementAt(9).EarnMultiplier = gameDto.Stores.ElementAt(9).EarnMultiplier;
                    game.Stores.ElementAt(9).IntervalReducer = gameDto.Stores.ElementAt(9).IntervalReducer;
                    game.Stores.ElementAt(9).hasManager = gameDto.Stores.ElementAt(9).hasManager;
                    if (game.Stores.ElementAt(9).hasManager)
                    {
                        game.Stores.ElementAt(9).ManagerSet();
                    }
                    game.Stores.ElementAt(9).hasBoughtMultiplier = gameDto.Stores.ElementAt(9).hasBoughtMultiplier;
                    game.Stores.ElementAt(9).Num_Upgrades = gameDto.Stores.ElementAt(9).Num_Upgrades;
                    game.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("1");
                }
                int AfkMoney = 0;
                game.Stores.ForEach(x =>
                {
                    if (x.hasManager)
                    {
                        DateTime now = DateTime.Now;
                        double span = now.Subtract(user.LastTimeLogged).TotalMilliseconds;
                        
                        AfkMoney += (int)(span / x.BaseInterval * x.MoneyMaking);
                    }


                });
                game.Money += AfkMoney;
                MessageBox.Show($"You have gotten ${AfkMoney} since last login");
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET lastlogin = '{DateTime.Now}' WHERE Id = '{user.Id}'", connection);
                cmd.ExecuteNonQuery();
            }
            else
            {
                game = new Game(InfoLabel);
                AddStores();
                Serialize();
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            user.LastTimeLogged = DateTime.Now;
            while (!IsFileReady($"C:\\CapitalistGame\\SavedGame{user.Id}.sg"));
            Serialize();
        }
        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ManagersButton_Click(object sender, EventArgs e)
        {
            ManagersForm newform = new ManagersForm(game);
            newform.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopForm form = new ShopForm(game);
            form.Show();
        }
    }
}