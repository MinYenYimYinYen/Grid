using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models.BlockResults
{
	public class Penetration124 : IBlockResult
	{
		public Penetration124(Block _block)
		{
			block = _block;
		}
		private Block block;

		public IEnumerable<LiveRecord> FullSet => MainWindow.LiveRecords
			.Where(r => r.Latitude <= block.LatTop && r.Latitude > block.LatBottom)
			.Where(r => r.Longitude >= block.LonLeft && r.Longitude < block.LonRight)
			.Where(r=>r.Size >=1 && r.Size <=24)
			.ToList();

		public IEnumerable<LiveRecord> Hits => FullSet.Where(r => r.Status == "9").ToList();

		public string blockType()
		{
			return "penetration124";
		}

		public double GetDoubleResult()
		{
			if (FullSet.Count() == 0) return 0;
			return (double)Hits.Count() / (double)FullSet.Count();
		}
	}
}
