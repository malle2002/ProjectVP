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
    public class LabelDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string SerializeLabel(Label label)
        {
            LabelDto dto = new LabelDto
            {
                Text = label.Text,
                Left = label.Left,
                Top = label.Top,
                Width = label.Width,
                Height = label.Height
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, dto);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
        public void DeserializeLabel(string serializedData, Label label)
        {
            byte[] data = Convert.FromBase64String(serializedData);

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                LabelDto dto = (LabelDto)formatter.Deserialize(memoryStream);
                label.Text = dto.Text;
                label.Left = dto.Left;
                label.Top = dto.Top;
                label.Width = dto.Width;
                label.Height = dto.Height;
            }
        }
    }
}
