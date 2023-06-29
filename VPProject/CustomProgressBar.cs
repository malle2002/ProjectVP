using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
	public enum TextPosition
	{
		Left,
		Right,
		Center,
		Sliding,
		None
	}
	public class CustomProgressBar : ProgressBar
    {
		private Color channelColor = Color.LightSteelBlue;
		private Color sliderColor = Color.RoyalBlue;
		private Color foreBackColor = Color.RoyalBlue;
		private int channelHeight = 6;
		private int sliderHeight = 6;

		private bool paintedBack = false;
		private bool stopPainting = false;

		public CustomProgressBar()
		{
			this.SetStyle(ControlStyles.UserPaint, true);
			this.ForeColor = Color.White;
		}
		[Category("RJ Code Advance")]
		public Color ChannelColor
		{
			get { return channelColor; }
			set
			{
				channelColor = value;
				this.Invalidate();
			}
		}
		[Category("RJ Code Advance")]
		public Color SliderColor
		{
			get { return sliderColor; }
			set
			{
				sliderColor = value;
				this.Invalidate();
			}
		}
		[Category("RJ Code Advance")]
		public Color ForeBackColor
		{
			get { return foreBackColor; }
			set
			{
				foreBackColor = value;
				this.Invalidate();
			}
		}
		[Category("RJ Code Advance")]
		public int ChannelHeight
		{
			get { return channelHeight; }
			set
			{
				channelHeight = value;
				this.Invalidate();
			}
		}
		[Category("RJ Code Advance")]
		public int SliderHeight
		{
			get { return sliderHeight; }
			set
			{
				sliderHeight = value;
				this.Invalidate();
			}
		}
		[Category("RJ Code Advance")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
			}
		}
		[Category("RJ Code Advance")]
		public override Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
			}
		}
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (stopPainting == false)
			{
				if (paintedBack == false)
				{
					//Fields
					Graphics graph = pevent.Graphics;
					Rectangle rectChannel = new Rectangle(0, 0, this.Width, ChannelHeight);
					using (var brushChannel = new SolidBrush(channelColor))
					{
						if (channelHeight >= sliderHeight)
							rectChannel.Y = this.Height - channelHeight;
						else rectChannel.Y = this.Height - ((channelHeight + sliderHeight) / 2);
						//Painting
						graph.Clear(this.Parent.BackColor);//Surface
						graph.FillRectangle(brushChannel, rectChannel);//Channel
																	   //Stop painting the back & Channel
						if (this.DesignMode == false)
							paintedBack = true;
					}
				}
				//Reset painting the back & channel
				if (this.Value == this.Maximum || this.Value == this.Minimum)
					paintedBack = false;
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			if (stopPainting == false)
			{
				//Fields
				Graphics graph = e.Graphics;
				double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
				int sliderWidth = (int)(this.Width * scaleFactor);
				Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, sliderHeight);
				using (var brushSlider = new SolidBrush(sliderColor))
				{
					if (sliderHeight >= channelHeight)
						rectSlider.Y = this.Height - sliderHeight;
					else rectSlider.Y = this.Height - ((sliderHeight + channelHeight) / 2);
					//Painting
					if (sliderWidth > 1) //Slider
						graph.FillRectangle(brushSlider, rectSlider);
				}
			}
			if (this.Value == this.Maximum) stopPainting = true;//Stop painting
			else stopPainting = false; //Keep painting
		}
	}
}
