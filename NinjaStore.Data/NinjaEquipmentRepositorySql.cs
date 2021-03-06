﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NinjaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Schema;

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
				ninja.Gold = ninja.Gold - equipment.Value;
				NinjaEquipment ninjaEquipment = new NinjaEquipment
				{
					Ninja = ninja,
					Equipment = equipment,
					NinjaId = ninjaId,
					EquipmentId = equipmentId
				};

				
				context.Attach(ninja);
				context.Ninjas.Update(ninja);
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
				ninja.Gold = ninja.Gold + equipment.Value;
				NinjaEquipment ninjaEquipment = new NinjaEquipment
				{
					Ninja = ninja,
					Equipment = equipment,
					NinjaId = ninjaId,
					EquipmentId = equipmentId
				};
				context.Attach(ninja);
				context.Ninjas.Update(ninja);

				context.NinjaEquipment.Remove(ninjaEquipment);
				context.SaveChanges();

				return true;
			}
		}

        public int getWorth(int value)
        {
			int total = 0;
            foreach(var item in ShowEquipment(value)) {
				total = total + item.Value;
            }
			return total;
        }

        public List<Equipment> buyAbleEquipment(int ninjaId, Category category)
		{
			using (var context = new NinjaStoreDbContext())
			{
				IEnumerable<Equipment> result ;
				if(category == null)
                {
					result = context.Equipment.ToList().Where(n => ShowEquipment(ninjaId).All(n2 => n2.EquipmentId != n.EquipmentId));
				}
				result = context.Equipment.ToList().Where(n => ShowEquipment(ninjaId).All(n2 => n2.EquipmentId != n.EquipmentId)).Where(e => e.Category.Equals(category));

				return result.ToList();
			}
			
		}
		public Equipment getOneItem(int ninjaId, Category cat)
        {
			
				var list = ShowEquipment(ninjaId).Where(item => item.Category == cat);
				Equipment item;
				if (list.ToArray().Length != 0) {
					item = list.ToArray()[0];
				}else
                {
					return null;
                }
				return item;
			
		}
		public int getPoints(int ninjaId, string pointscat)
        {
			var list = ShowEquipment(ninjaId);
			int points = 0;
			foreach(var item in list)
            {
				if(pointscat.Equals("Strength"))
                {
					points = points + item.Strength;
                }
				if (pointscat.Equals("Agility"))
				{
					points = points + item.Agility;
				}
				if (pointscat.Equals("Intelligence"))
				{
					points = points + item.Intelligence;
				}
			}
			return points;

		}
	}
}
