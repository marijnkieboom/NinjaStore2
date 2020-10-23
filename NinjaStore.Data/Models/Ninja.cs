using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaStore.Data.Models
{
	public class Ninja
	{
		[Key]
		public int NinjaId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Alleen getallen groter of gelijk aan 0 toegestaan")]
		public int Gold { get; set; }

		public virtual List<NinjaEquipment> Bevat { get; set; }
	}
}