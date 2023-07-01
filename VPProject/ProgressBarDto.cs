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

        // Serialization
        public string SerializeProgressBar(ProgressBar progressBar)
        {
            ProgressBarDto dto = new ProgressBarDto
            {
                Minimum = progressBar.Minimum,
                Maximum = progressBar.Maximum,
                Value = progressBar.Value
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, dto);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        // Deserialization
        public void DeserializeProgressBar(string serializedData, ProgressBar progressBar)
        {
            byte[] data = Convert.FromBase64String(serializedData);

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ProgressBarDto dto = (ProgressBarDto)formatter.Deserialize(memoryStream);
                progressBar.Minimum = dto.Minimum;
                progressBar.Maximum = dto.Maximum;
                progressBar.Value = dto.Value;
            }
        }
    }
}
