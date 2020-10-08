using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NinjaStore.Data.Models
{
	public class NinjaEquipment
	{
		[Key]
		public int NinjaId { get; set; }
		[Key]
		public int EquipmentId { get; set; }
		public Ninja Ninja { get; set; }
		public Equipment Equipment { get; set; }
	}
}