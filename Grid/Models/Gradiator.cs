using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grid.Models
{
	public class Gradiator
	{
		public Gradiator(double min, double max, double meVal)
		{
			Min = min;
			Max = max;
			MeVal = meVal;
		}

		public double Min { get; set; }
		public double Max { get; set; }
		private double MeVal { get; set; }
		private double Perc => MeVal / (Min + Max);


		public SolidColorBrush SolidColorBrush
		{
			get
			{
				if (Perc <= .5) return GreenToYellow(Perc);
				return YellowToRed(Perc);
			}
		}

		private SolidColorBrush GreenToYellow(double val)
		{
			var b = new SolidColorBrush();
			b.Color = new Color
			{
				ScG = 1f,
				ScR = (float)(val * 2),
				ScA = 1
			};

			return b;
		}

		private SolidColorBrush YellowToRed(double val)
		{
			var b = new SolidColorBrush();
		b.Color = new Color
		{
			ScR = 1f,
			ScG = (float)(1 - (val - .50) * 2),
			ScA = 1
			};
			return b;
		}
	}
}
