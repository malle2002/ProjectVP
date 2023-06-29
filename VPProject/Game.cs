using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace VPProject
{
    [Serializable]
    public class Game
    {
        public static int Money { get; set; } = 111111110;
        public static int Gold { get; set; } = 250;
        public List<Store> Stores { get; set; }
        public Game()
        {
            Stores = new List<Store>();
        }
        public void Update()
        {
            foreach (Store s in Stores)
            {
                s.Update();
            }
        }
        public static void SaveGame()
        {
            Home.Serialize();
        }
    }
}
