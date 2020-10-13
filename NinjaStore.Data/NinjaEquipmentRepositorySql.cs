using Microsoft.EntityFrameworkCore;
using NinjaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NinjaStore.Data
{
	public class NinjaEquipmentRepositorySql
	{
		public List<Equipment> ShowEquipment(int ninjaId)
		{
			using (var context = new NinjaStoreDbContext())
			{
				var ninjaIncludingItems = context.Ninjas.Include(ninja => ninja.Bevat).ThenInclude(e => e.Equipment).First(n => n.NinjaId == ninjaId);

				var ninjaItems = ninjaIncludingItems.Bevat.Select(e => e.Equipment);

				return ninjaItems.ToList();
			}
		}
		public bool BuyEquipment(int ninjaId, int equipmentId)
		{
			using (var context = new NinjaStoreDbContext())
			{
				var ninja = context.Ninjas.FirstOrDefault(n => n.NinjaId == ninjaId);
				var equipment = context.Equipment.FirstOrDefault(e => e.EquipmentId == equipmentId);
				NinjaEquipment ninjaEquipment = new NinjaEquipment
				{
					Ninja = ninja,
					Equipment = equipment,
					NinjaId = ninjaId,
					EquipmentId = equipmentId
				};


				context.NinjaEquipment.Add(ninjaEquipment);
				context.SaveChanges();

				return true;
			}
		}

		public bool SellEquipment(int ninjaId, int equipmentId)
		{
			using (var context = new NinjaStoreDbContext())
			{
				var ninja = context.Ninjas.FirstOrDefault(n => n.NinjaId == ninjaId);
				var equipment = context.Equipment.FirstOrDefault(e => e.EquipmentId == equipmentId);
				NinjaEquipment ninjaEquipment = new NinjaEquipment
				{
					Ninja = ninja,
					Equipment = equipment,
					NinjaId = ninjaId,
					EquipmentId = equipmentId
				};


				context.NinjaEquipment.Remove(ninjaEquipment);
				context.SaveChanges();

				return true;
			}
		}

		public List<Equipment> buyAbleEquipment(int ninjaId)
		{
			using (var context = new NinjaStoreDbContext())
			{
				var result = context.Equipment.ToList().Where(n => ShowEquipment(ninjaId).All(n2 => n2.EquipmentId != n.EquipmentId));

				return result.ToList();
			}
			
		}
	}
}
