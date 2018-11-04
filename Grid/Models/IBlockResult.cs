using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public interface IBlockResult
	{
		double GetDoubleResult();
		IEnumerable<LiveRecord> FullSet { get; }
		IEnumerable<LiveRecord> Hits { get; }
		string blockType();
		
	}
}
