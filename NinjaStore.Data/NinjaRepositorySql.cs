using NinjaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStore.Data
{
	public class NinjaRepositorySql
	{
		public void Create(Ninja ninja)
		{
			using (var context = new NinjaStoreDbContext())
			{
				context.Ninjas.Add(ninja);
				context.SaveChanges();
			}
		}

		public bool Delete(int id)
		{
			using (var context = new NinjaStoreDbContext())
			{
				var toRemove = context.Ninjas.Find(id);
				if (toRemove != null)
				{
					context.Ninjas.Remove(toRemove);
					context.SaveChanges();
					return true;
				}
				return false;
			}
		}

		public List<Ninja> GetAll()
		{
			using (var context = new NinjaStoreDbContext())
			{
				return context.Ninjas.ToList();
			}
		}

		public Ninja GetOne(int id)
		{
			using (var context = new NinjaStoreDbContext())
			{
				return context.Ninjas.FirstOrDefault(n => n.NinjaId == id);
			}
		}

		public void Update(Ninja ninja)
		{
			using (var context = new NinjaStoreDbContext())
			{
				context.Attach(ninja);

				context.Ninjas.Update(ninja);
				context.SaveChanges();
			}
		}
	}
}