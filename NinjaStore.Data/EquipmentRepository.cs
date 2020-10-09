using NinjaStore.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace NinjaStore.Data
{
	public class EquipmentRepository
	{
		public void Create(Equipment equipment)
		{
			using (var context = new NinjaStoreDbContext())
			{
				context.Equipment.Add(equipment);
				context.SaveChanges();
			}
		}

		public bool Delete(int id)
		{
			using (var context = new NinjaStoreDbContext())
			{
				var toRemove = context.Equipment.Find(id);
				if (toRemove != null)
				{
					context.Equipment.Remove(toRemove);
					context.SaveChanges();
					return true;
				}
				return false;
			}
		}

		public List<Equipment> GetAll()
		{
			using (var context = new NinjaStoreDbContext())
			{
				return context.Equipment.ToList();
			}
		}

		public Equipment GetOne(int id)
		{
			using (var context = new NinjaStoreDbContext())
			{
				return context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
			}
		}

		public void Update(Equipment equipment)
		{
			using (var context = new NinjaStoreDbContext())
			{
				context.Attach(equipment);

				context.Equipment.Update(equipment);
				context.SaveChanges();
			}
		}
	}
}
