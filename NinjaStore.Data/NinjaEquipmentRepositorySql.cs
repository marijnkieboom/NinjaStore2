using NinjaStore.Data.Models;
using System;
using System.Collections.Generic;
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
			
				var existingNinja = context.Ninjas.FirstOrDefault(n => n.NinjaId == ninjaId);


				context.Attach(existingNinja);

				context.Entry(existingNinja).Collection(p => p.Bevat).Load();
				var equipmentVanNinja = existingNinja.Bevat.Select(i => i.EquipmentId);
				List<Equipment> returnList = new List<Equipment>();
				foreach(var id in equipmentVanNinja.ToList())
				{
					var item = context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
					returnList.Add(item);
				}
			
				
				return returnList;
		
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

		public List<Equipment> buyAbleEquipment(int ninjaId)
		{
			using (var context = new NinjaStoreDbContext())
			{
				List<Equipment> returnList = new List<Equipment>();
				var allEquipment = context.Equipment.ToList();
				foreach (var item in allEquipment){
					foreach(var item2 in ShowEquipment(ninjaId))
					{
						if(item.EquipmentId == item2.EquipmentId)
						{
							break;
						}
						returnList.Add(item);
					}
				}
				return returnList;
			}
		}
	}
}
