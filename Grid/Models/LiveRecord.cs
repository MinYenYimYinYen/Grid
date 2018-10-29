using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class LiveRecord
	{
		public LiveRecord(Database.customer customer)
		{
			Cust_No = customer.cust_no;
			Status = customer.status;
			Latitude = customer.latitude != null ? (double)customer.latitude : 0;
			Longitude = customer.longitude != null ? (double)customer.longitude : 0;

		}
		public LiveRecord(Database.markcust markcust)
		{
			Cust_No = markcust.cust_no;
			Status = "0";
			Latitude = markcust.latitude != null ? (double)markcust.latitude : 0;
			Longitude = markcust.longitude != null ? (double)markcust.longitude : 0;
		}

		public int Cust_No { get; set; }
		public string Status { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

	}
}
