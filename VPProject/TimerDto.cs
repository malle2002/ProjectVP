using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
    [Serializable]
    public class TimerDto
    {
        public int Interval { get; set; }
        public bool Enabled { get; set; }
    }
}
