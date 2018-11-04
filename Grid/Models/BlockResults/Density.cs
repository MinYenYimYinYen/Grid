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


		public IEnumerable<LiveRecord> FullSet => block.FullSet;

		public IEnumerable<LiveRecord> Hits => FullSet;

		public double GetDoubleResult()
		{
			return FullSet.Count();
		}

		public string blockType()
		{
			return "density";
		}
	}
}
