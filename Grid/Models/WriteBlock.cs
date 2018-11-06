using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Models
{
	public class WriteBlock
	{

		/*
		 * Objective: When block completes a BlockResult, it should Identify itself and save relevant calculation in a database.
		 *						Then, when query is called again, the BlockResults can load from DB instead of having to be calculated.
		 * 1. In order for this to work, each block needs a parseable identifier
		 *			a. All 4 LatLon corners, in consistent order
		 *			b. The type of iBlockResult (like AverageSize)
		 *			c. The GetResult() value.
		 * 2. Upon completion of calculation this writes to db
		 * 3. Upon call for calculation, db is queried to see if data already exists.
		 *			a. If so, GetResult() returns the value stored in db.
		 * 4. There needs to be an option to clear BlockResults
		 * 
		 * 
		 * 
		 * 
		 * 
		 * */
	}
}
