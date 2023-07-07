using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace VPProject
{
    [Serializable]
    public class Game
    {
        public int Money { get; set; } = 0;
        public int Gold { get; set; } = 0;
        public List<Store> Stores { get; set; }
        public Label Label { get; set; }
        public bool HasBoughtEverythingX3 { get; set; }
        public bool HasBoughtEverything2 { get; set; }
        public Game(Label label)
        {
            Label = label;
            Stores = new List<Store>();
        }
        public void Update()
        {
            foreach (Store s in Stores)
            {
                s.Update();
            }
        }
        public void UpdateLabel()
        {
            Label.Text = $"Money: ${Money} \t \t \t Gold: {Gold}";
        }
    }
}
