using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
    [Serializable]
    public class Store
    {
        public Game game { get; set; }
        public CustomProgressBar ProgressBar;
        public Button UpgradeButton;
        public Label Label { get; set; }
        public Label EarnLabel { get; set; }
        public System.Windows.Forms.Timer Timer;
        public string Name { get; set; }
        public int Interval { get; set; }
        public int Num_Upgrades { get; set; } = 0;
        public double BaseCost { get; set; }
        public int BaseMoney { get; set; }
        public int MoneyMaking { get; set; }
        public int BaseInterval { get; set; }
        public int CostOfUpgrade { get; set; }
        public int IntervalReducer { get; set; } = 1;
        public int EarnMultiplier { get; set; } = 1;
        public bool Clicked { get; set; } = false;
        public bool IsBought { get; set; }
        public bool hasManager { get; set; } = false;
        [NonSerialized]
        Random random = new Random();
        public Store(System.Windows.Forms.Timer timer, ProgressBar progressbar, Button upgradebutton, int baseMoney, double baseCost, int baseInterval, Label label, Label earnLabel, Game Game, bool isbought)
        {
            Timer = timer;
            ProgressBar = (CustomProgressBar)progressbar;
            UpgradeButton = upgradebutton;
            BaseCost = baseCost;
            BaseMoney = baseMoney;
            MoneyMaking = BaseMoney;
            BaseInterval = baseInterval;
            Label = label;
            EarnLabel = earnLabel;
            Timer.Enabled = false;
            game = Game;
            IsBought = isbought;
            CostOfUpgrade = (int)Math.Ceiling(BaseCost);
            ClickProgressBarConfiguration();
            Update();
        }
        public void Update()
        {
            Interval = BaseInterval / 100;
            MoneyMaking = BaseMoney * (Num_Upgrades + 1) * EarnMultiplier;
            CostOfUpgrade = (int)(Num_Upgrades == 0 ? Math.Ceiling(BaseCost) : Math.Ceiling(1.07 * CostOfUpgrade));
            Timer.Interval = Interval != 0 ? Interval : 1;
            Label.Text = $"Level: {Num_Upgrades}";
            EarnLabel.Text = $"Earns you: ${MoneyMaking}";
            UpdateButtons();
        }
        public void UpdateButtons()
        {
            if (!IsBought)
            {
                UpgradeButton.Text = $"Buy ${BaseCost}";
                if (BaseCost > game.Money)
                {
                    UpgradeButton.Enabled = false;
                }
                else
                {
                    UpgradeButton.Enabled = true;
                }
            }
            else
            {
                UpgradeButton.Text = $"Upgrade ${CostOfUpgrade}";
                if (CostOfUpgrade > game.Money)
                {
                    UpgradeButton.Enabled = false;
                }
                else
                {
                    UpgradeButton.Enabled = true;
                }
            }
        }
        public void ClickProgressBarConfiguration()
        {
            ProgressBar.MouseClick += (sender, e) =>
            {
                if (!Timer.Enabled && Clicked == false && IsBought)
                {
                    Clicked = true;
                    System.Windows.Forms.Timer ButtonTimer = new System.Windows.Forms.Timer();
                    ButtonTimer.Interval = Interval;
                    int i = 0;
                    ButtonTimer.Tick += (sender1, e1) =>
                    {
                        if (ProgressBar.Value == 100)
                        {
                            ProgressBar.Value = 0;
                            ButtonTimer.Stop();
                            Clicked = false;
                            game.Money += MoneyMaking;
                            Update();
                            i = 0;
                        }
                        else
                        {
                            ProgressBar.Value = ++i;
                            ProgressBar.Refresh();
                            //ProgressBar.PerformStep();
                        }

                    };
                    ButtonTimer.Start();
                }
            };
        }
        public void ManagerSet()
        {
            hasManager = true;
            Clicked = false;
            Timer.Tick += (sender, e) =>
            {

                if (ProgressBar.Value == 100)
                {
                    ProgressBar.Value = 0;
                    game.Money += MoneyMaking;
                    Update();
                }
                else
                {
                    ProgressBar.PerformStep();
                }
            };
            Timer.Start();
        }
        public void Configuration()
        {
            UpgradeButton.Click += (sender, e) =>
            {
                if (IsBought)
                {
                    UpgradeButton.Text = "Upgrade";
                    if (game.Money >= CostOfUpgrade)
                    {
                        Num_Upgrades++;
                        game.Money -= CostOfUpgrade;
                        if (Num_Upgrades % 25 == 0)
                        {
                            game.Gold += 25;
                            if (random.Next(2) == 0)
                            {
                                EarnMultiplier *= 3;
                            }
                            else
                            {
                                IntervalReducer *= 3;
                            }
                        }
                        Update();
                    }
                }
                else
                {
                    if (game.Money >= BaseCost)
                    {
                        game.Money -= (int)Math.Ceiling(BaseCost);
                        IsBought = true;
                        Update();
                    }
                }

            };
        }
    }
}
