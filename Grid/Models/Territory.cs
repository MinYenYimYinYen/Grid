using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class Territory
	{
		private Location topLeft;
		public Location TopLeft
		{
			get
			{
				if (topLeft == null)
				{
					var sa = MainWindow.sa;
					var top = sa.markcusts.Select(m => m.latitude).Max();
					var left = sa.markcusts.Select(m => m.longitude).Min();
					return new Location
					{
						Latitude = (double)top,
						Longitude = (double)left
					};
				}
				return topLeft;
			}
			set => topLeft = value;
		}

		private Location bottomRight;
		public Location BottomRight
		{
			get
			{
				if (bottomRight == null)
				{
					var sa = MainWindow.sa;
					var bottom = sa.markcusts.Select(m => m.latitude).Min();
					var right = sa.markcusts.Select(m => m.longitude).Max();
					return new Location
					{
						Latitude = (double)bottom,
						Longitude = (double)right
					};
				}
				return bottomRight;
			}
			set => bottomRight = value;
		}

		private int divLat;
		public int DivLat
		{
			get
			{
				if (divLat < 1) return 1;
				return divLat;
			}
			set => divLat = value;
		}

		private int divLon;
		public int DivLon
		{
			get
			{
				if (divLon <1) return 1;
				return divLon;
			}
			set => divLon = value;
		}

		//public ObservableCollection<Block> Blocks { }

	}
}
