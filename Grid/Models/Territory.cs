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
		public Location TopLeft { get; set; }
		public Location BottomRight { get; set; }

		public int DivLat { get; set; }
		public int DivLon { get; set; }

		public ObservableCollection<Block> Blocks;

	}
}
