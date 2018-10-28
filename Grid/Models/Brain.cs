using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class Brain
	{
		public static Database.SADBContext sa = new Database.SADBContext();
		public static Database.IMCDBContext imc = new Database.IMCDBContext();
		public Territory HOL010 { get; set; }
	}
}
