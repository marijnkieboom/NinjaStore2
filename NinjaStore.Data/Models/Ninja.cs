using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Data.Model
{
	public class Ninja
	{
		public string Name { get; set; }
		public int Gold { get; set; }
		public List<Equipment> Inventory { get; set; }
	}
}
