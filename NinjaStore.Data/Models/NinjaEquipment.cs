using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NinjaStore.Data.Models
{
	public class NinjaEquipment
	{
		public int NinjaId { get; set; }
		public int EquipmentId { get; set; }
		public Ninja Ninja { get; set; }
		public Equipment Equipment { get; set; }
	}
}