using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models.BlockResults
{
	public class AverageSize : IBlockResult
	{
		public AverageSize(Block _block)
		{
			block = _block;
		}
		private Block block;

		public IEnumerable<LiveRecord> FullSet
		{
			get
			{
				var x= MainWindow.LiveRecords
					.Where(r => r.Latitude <= block.LatTop && r.Latitude > block.LatBottom)
					.Where(r => r.Longitude >= block.LonLeft && r.Longitude < block.LonRight)
					.Where(r => r.Size >= 1 && r.Size <= 24)
					.ToList();
				return x;
			}
		}

		public IEnumerable<LiveRecord> Hits => FullSet;

		public string blockType()
		{
			return "averagesize";
		}

		public double? getDoubleResult;
		public double GetDoubleResult()
		{
			if (getDoubleResult != null)
			{
				return (double)getDoubleResult;
			}
			else
			{
				if (Hits.Count() > 0)
				{
					getDoubleResult = Hits.Select(h => h.Size).Average();
				}
				else
				{
					getDoubleResult = 0;
				}
				return (double)getDoubleResult;
			}
		}


	}
}
