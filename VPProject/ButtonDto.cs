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
    public class ButtonDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string SerializeButton(Button button)
        {
            ButtonDto dto = new ButtonDto
            {
                Text = button.Text,
                Left = button.Left,
                Top = button.Top,
                Width = button.Width,
                Height = button.Height
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, dto);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        // Deserialization
        public void DeserializeButton(string serializedData, Button button)
        {
            byte[] data = Convert.FromBase64String(serializedData);

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ButtonDto dto = (ButtonDto)formatter.Deserialize(memoryStream);
                button.Text = dto.Text;
                button.Left = dto.Left;
                button.Top = dto.Top;
                button.Width = dto.Width;
                button.Height = dto.Height;
            }
        }
    } 

}
