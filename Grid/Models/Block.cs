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
		public Location TopLeft { get; set; }
		public Location BottomRight { get; set; }

		private ObservableCollection<Location> content;
		public ObservableCollection<Location> Content
		{
			get
			{
				if (content == null) content = new ObservableCollection<Location>();
				return content;
			}
		}


		public void Fill(List<Location> locations, bool ClearExisting)
		{
			if (ClearExisting) this.Content.Clear();
			foreach (var loc in locations)
			{
				this.Content.Add(loc);
			}
		}
	}
}
