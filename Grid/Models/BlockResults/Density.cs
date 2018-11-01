using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grid.Models;
using Microsoft.Maps.MapControl.WPF;

namespace Grid.Models.BlockResults
{
	public class Density : IBlockResult
	{
		public Density(Block _block)
		{
			block = _block;
		}
		private Block block;


		public IEnumerable<LiveRecord> FullSet =>  MainWindow.LiveRecords
			.Where(r=>r.Latitude <= block.LatTop && r.Latitude > block.LatBottom)
			.Where(r=>r.Longitude >=block.LonLeft && r.Longitude < block.LonRight).ToList();

		public IEnumerable<LiveRecord> Hits => FullSet;

		public double GetDoubleResult()
		{
			return FullSet.Count();
		}
	}
}
