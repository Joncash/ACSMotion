using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hanbo.ACS
{
	class HaltedResultViewModel
	{
		public Axis Axis { get; set; }
		public Axis[] AxisList { get; set; }

		public string Message { get; set; }
	}
}
