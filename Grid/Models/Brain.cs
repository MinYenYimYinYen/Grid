using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class Brain
	{
		public static Database.SADBContext sa = new Database.SADBContext();
		public static Database.IMCDBContext imc = new Database.IMCDBContext();
		private static ObservableCollection<LiveRecord> liveRecords;
		public static ObservableCollection<LiveRecord> LiveRecords
		{
			get
			{
				if (liveRecords == null)
				{
					liveRecords = new ObservableCollection<LiveRecord>();

					//Add Live Records for customer table where latitude is valid
					foreach (var rec in sa.customers
						.Where(c => c.latitude != 0 && c.latitude != null && c.longitude != 0 && c.longitude != null))
					{
						liveRecords.Add(new LiveRecord(rec));
					}

					//And again for markcust table
					foreach (var rec in sa.markcusts
						.Where(c => c.latitude != 0 && c.latitude != null && c.longitude != 0 && c.longitude != null))
					{
						liveRecords.Add(new LiveRecord(rec));
					}
				}
				return liveRecords;
			}
		}

		private Territory hol010;
		public Territory HOL010
		{
			get
			{
				if (hol010 == null)
				{
					hol010 = new Territory();
				}
				return hol010;
			}
		}
	}
}
