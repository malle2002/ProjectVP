using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace VPProject
{
    [Serializable]
    public class ProgressBarDto
    {
        public string Name { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
