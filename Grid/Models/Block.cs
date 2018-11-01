using Grid.Models.BlockResults;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class Block
	{
		#region MapStuff
		public double LatTop { get; set; }
		public double LatBottom { get; set; }
		public double LonLeft { get; set; }
		public double LonRight { get; set; }

		public double LatCenter { get => (LatTop + LatBottom) / 2; }
		public double LonCenter { get => (LonLeft + LonRight) / 2; }

		public Location Center
		{
			get => new Location
			{
				Latitude = LatCenter,
				Longitude = LonCenter
			};
		}

		public Location TopLeft { get => new Location { Latitude = LatTop, Longitude = LonLeft }; }
		public Location TopRight { get => new Location { Latitude = LatTop, Longitude = LonRight }; }
		public Location BotLeft { get => new Location { Latitude = LatBottom, Longitude = LonLeft }; }
		public Location BotRight { get => new Location { Latitude = LatBottom, Longitude = LonRight }; }

		public LocationCollection LocationCellection { get => new LocationCollection { TopLeft, TopRight, BotRight, BotLeft }; }
		#endregion

		#region DataStuff
		public Density Density => new Density(this);


		#endregion

	}
}
