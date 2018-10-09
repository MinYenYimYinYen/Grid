using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class LocationFactory
	{
		public LocationFactory(Database.SADBContext SA)
		{
			sa = SA;
		}
		private Database.SADBContext sa;

		public List<Database.customer> Customers { get; set; }
		public List<Database.markcust> MarkCusts { get; set; }

		public List<Location> ActiveCustomers
		{
			get
			{
				return sa.customers.Where(c => c.status == "9")
					.Select(c => new Location
					{
						Latitude = c.latitude == null ? 0 : (double)c.latitude,
						Longitude = c.longitude == null ? 0 : (double)c.longitude
					})
					.ToList();
			}
		}

		public List<Location> CancelledCustomers
		{
			get
			{
				return sa.customers.Where(c => c.status == "6" || c.status == "7")
					.Select(c => new Location
					{
						Latitude = c.latitude == null ? 0 : (double)c.latitude,
						Longitude = c.longitude == null ? 0 : (double)c.longitude
					})
					.ToList();
			}
		}

	}
}
