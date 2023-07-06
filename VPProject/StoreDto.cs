using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    [Serializable]
    public class StoreDto
    {
        public ProgressBarDto ProgressBar { get; set; }
        public ButtonDto Button { get; set; }
        public LabelDto Label { get; set; }
        public LabelDto Label2 { get; set; }
        public TimerDto Timer { get; set; }
        public string Name { get; set; }
        public int Interval { get; set; }
        public int Num_Upgrades { get; set; }
        public double BaseCost { get; set; }
        public int BaseMoney { get; set; }
        public int MoneyMaking { get; set; }
        public int BaseInterval { get; set; }
        public int CostOfUpgrade { get; set; }
        public int IntervalReducer { get; set; }
        public int EarnMultiplier { get; set; }
        public bool Clicked { get; set; }
        public bool IsBought { get; set; }
        public bool hasManager { get; set; }
        public bool hasBoughtMultiplier { get; set; }
        public GameDto game { get; set; }
    }
}
