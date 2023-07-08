# ProjectVP | Capitalist - game for money makers.
To start playing the game, first you need to register a account then log in with it.</br>This is done in the interaction between Login and Register Forms ( the users are stored in Database )
</hr>
After that you will start the game from scratch ( this is Home form ).</br>
In Home form we have 10 Stores ( Store is UI Class ), each of the store has : </br>
<strong>Button</strong> for upgrade,</br>
<strong>ProgressBar</strong> to show the progress of stores' work,</br>
<strong>Label</strong> to inform how much stores earns you and the level of it,</br>
<strong>Timer</strong> is used if we have manager that will run the store for us.
Otherwise if we don't have manager we need to click on the progress bar and we wait the work to be done.</br>
<hr>
The 10 Stores are : Lemonade Stand, Newspaper Shop, Car wash, Pizza Restaurant, Donut Shop, Shrimp Shop, Hockey Team, Movie Studio, Bank and Oil Company. </br>
Lemonade is free and it doesn't need to be bought while others firstly need to be bought.</br>
We use the button to buy store or to upgrade the amount of money we get from it for price that grows with each level.</br>
Also the time you wait for each store grows aswell as the money you get from it.</br>
At 25 level upgrade you gain 3x Multiplier ( 3 times the money you earn for that store ) and you gain 25 Gold which are used to buy upgrade from Shop.</br>
There are 2 Buttons that open 2 different forms. First one is for the Managers and the second is the Shop which you can buy multipliers for each store and also there are Multipliers for every store.
<hr>
If you get bored and close the game. The game will be stored and you will start from where you left, also you will gain the money you earned away from the keyboard.

</br>
</br>


###########################################################################################################
Classes:  Store, User, Game, CustomProgressBar </br>DTO:  StoreDto, GameDto, ButtonDto, LabelDto, TimerDto, ProgressBarDto </br>
Forms: Register, Login, Home, ManagersForm, ShopForm </br>
Game has List< Store >, money and gold. </br>Store has controls and variables.</br> User has Id and username.</br> CustomProgressBar from https://rjcodeadvance.com/custom-progressbar-winforms-c/ </br>
###########################################################################################################
<pre>
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
</pre>
Because we cannot serialize controls we need to make StoreDto to extract and serialize only the data of the controls. We also need to ControlDto for every control.
And because we need List< StoreDto > and not List< Store > we need to make GameDto. We use binary formatter to serialize the gameDto we will create from the game instance from Home Form.


###########################################################################################################
<strong>Screenshots</strong></br>
![1](https://github.com/malle2002/ProjectVP/assets/93403675/8dbd6e04-ee21-48e3-b89b-4ecca797bc18)
![2](https://github.com/malle2002/ProjectVP/assets/93403675/125d4208-89bb-4cec-b8cc-7a1713257b5f)
![3](https://github.com/malle2002/ProjectVP/assets/93403675/8e507a3a-84d2-4a12-ae97-b7f3228da5e8)
![4](https://github.com/malle2002/ProjectVP/assets/93403675/fcca1271-d33e-4489-894a-fd79808a8545)
![5](https://github.com/malle2002/ProjectVP/assets/93403675/1ffae315-2e68-4bc7-9a11-0f5b3a3ccee9)

