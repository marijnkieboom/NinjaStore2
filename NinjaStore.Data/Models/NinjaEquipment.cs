﻿using System.ComponentModel.DataAnnotations;

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