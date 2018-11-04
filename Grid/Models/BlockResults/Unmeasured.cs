using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models.BlockResults
{
	public class Unmeasured : IBlockResult
	{
		public Unmeasured(Block _block)
		{
			block = _block;
		}
		private Block block;

		public IEnumerable<LiveRecord> FullSet => MainWindow.LiveRecords
			.Where(r => r.Latitude <= block.LatTop && r.Latitude > block.LatBottom)
			.Where(r => r.Longitude >= block.LonLeft && r.Longitude < block.LonRight)
			.ToList();

		public IEnumerable<LiveRecord> Hits => FullSet.Where(r => r.Size == 0 || r.Size == .07);

		public string blockType()
		{
			return "unmeasured";
		}

		public double GetDoubleResult()
		{
			return Hits.Count();
		}
	}
}
