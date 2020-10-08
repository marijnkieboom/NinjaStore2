using NinjaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NinjaStore.Data.Models
{
	public class Ninja
	{
		[Key]
		public int NinjaId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Gold { get; set; }

		public virtual IEnumerable<NinjaEquipment> Bevat { get; set; }
	}
}