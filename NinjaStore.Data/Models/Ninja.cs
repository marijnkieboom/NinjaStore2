using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NinjaStore.Data.Model
{
	public class Ninja
	{
		[Key]
		public string Name { get; set; }
		[Required]
		public int Gold { get; set; }
		public List<Equipment> Inventory { get; set; }
	}
}
