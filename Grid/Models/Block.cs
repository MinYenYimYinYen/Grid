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
		public Location topLeftOfBlock;
		public Location TopLeftOfBlock { get; set; }
		public Location BottomRightOfBlock { get; set; }
	}
}
