using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    [Serializable]
    public class GameDto
    {
        public int Money { get; set; }
        public int Gold { get; set; }
        public List<StoreDto> Stores { get; set; }
    }
}
