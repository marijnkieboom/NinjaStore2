using System;
using System.Collections.Generic;
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
		public int Value { get; set; }
		public Category Category { get; set; }
		public int Strength { get; set; }
		public int Intelligence { get; set; }
		public int Agility { get; set; }
	}
}