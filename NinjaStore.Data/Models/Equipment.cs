using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace NinjaStore.Data.Model
{
	public enum Category
	{
		Head,
		Chest,
		Hand,
		Feet,
		Ring,
		Necklace
	}

	public class Equipment
	{
		[Key]
		public int id { get; set; }
		[Required]
		public int Value { get; set; }
		[Required]
		public Category Category { get; set; }
		public int Strength { get; set; }
		public int Intelligence { get; set; }
		public int Agility { get; set; }
	}
}