﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using NinjaStore.Data;
using NinjaStore.Data.Models;

namespace NinjaStore.Controllers
{
	public class NinjaController : Controller
	{
		readonly NinjaRepositorySql ninjaRepositorySql = new NinjaRepositorySql();
		readonly EquipmentRepository equipmentRepositorySql = new EquipmentRepository();
		readonly NinjaEquipmentRepositorySql ninjaEquipmentRepositorySql = new NinjaEquipmentRepositorySql();
		public IActionResult Index()
		{
			return View(ninjaRepositorySql.GetAll());
		}
		public IActionResult NinjaEdit(int? id)
		{
			if (!id.HasValue)
			{
				return RedirectToAction("NinjaEdit");
			}

			var ninja = ninjaRepositorySql.GetOne(id.Value);
			if (ninja == null)
			{
				return RedirectToAction("Index");
			}

			ninjaEquipmentRepositorySql.ShowEquipment(id.Value);


			return View(ninja);
		}
		[HttpPost]
		public IActionResult NinjaEdit(int id, Ninja ninja)
		{
			if (ModelState.IsValid)
			{
				if (id != ninja.NinjaId)
				{
					return RedirectToAction("Index");
				}
				if (ModelState.IsValid)
				{
					ninjaRepositorySql.Update(ninja);
					return RedirectToAction("Index");
				}
				return View(ninja);
			}
			else
			{
				return View(ninja);
			}
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Ninja ninja)
		{
			if (ModelState.IsValid)
			{
				ninjaRepositorySql.Create(ninja);
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Create", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
					new { controller = "Ninja", action = "Create", Id = ninja.NinjaId }));
			}
		}

		public IActionResult Edit(int? id, Category category)
		{
			if (id.HasValue)
			{
				var ninja = ninjaRepositorySql.GetOne(id.Value);
				ViewBag.BuyAbleEquipment = ninjaEquipmentRepositorySql.buyAbleEquipment(id.Value, category);

				
				ViewBag.NinjaEquipment = ninjaEquipmentRepositorySql.ShowEquipment(id.Value);
				ViewBag.AllEquipment = equipmentRepositorySql.GetAll();
				
				ViewBag.Head = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Head);
				ViewBag.Hands = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Hand);
				ViewBag.Feet = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Feet);
				ViewBag.Necklace = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Necklace);
				ViewBag.Chest = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Chest);
				ViewBag.Ring = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Ring);
				ViewBag.Strength = ninjaEquipmentRepositorySql.getPoints(id.Value, "Strength");
				ViewBag.Agility = ninjaEquipmentRepositorySql.getPoints(id.Value, "Agility");
				ViewBag.Intelligence = ninjaEquipmentRepositorySql.getPoints(id.Value, "Intelligence");
				ViewBag.Worth = ninjaEquipmentRepositorySql.getWorth(id.Value);
				return View(ninja);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Edit(int id, Ninja ninja)
		{
			if (ModelState.IsValid)
			{
				if (id != ninja.NinjaId)
				{
					return RedirectToAction("Index");
				}
				if (ModelState.IsValid)
				{
					ninjaRepositorySql.Update(ninja);
					return RedirectToAction("Index");
				}
				return View(ninja);
			}
			else
			{
				return View(ninja);
			}
		}

		public IActionResult Details(int? id)
		{
			if (!id.HasValue)
			{
				return RedirectToAction("Create");
			}

			var ninja = ninjaRepositorySql.GetOne(id.Value);
			if (ninja == null)
			{
				return RedirectToAction("Index");
			}
			
			ninjaEquipmentRepositorySql.ShowEquipment(id.Value);


			return View(ninja);
		}

		public IActionResult Delete(int? id)
		{
			if (id.HasValue)
			{
				var ninja = ninjaRepositorySql.GetOne(id.Value);
				if (ninja != null)
				{
					return View(ninja);
				}
				else
				{
					return NotFound();
				}
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			ninjaRepositorySql.Delete(id);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult BuyItem(int itemId, int ninjaId)
		{
			Ninja ninja = ninjaRepositorySql.GetOne(ninjaId);
			Equipment item = equipmentRepositorySql.GetOne(itemId);
			if (ninja.Gold >= item.Value)
			{
				if(ninjaEquipmentRepositorySql.getOneItem(ninjaId, item.Category) == null)
                {
					ninjaEquipmentRepositorySql.BuyEquipment(ninjaId, itemId);
					TempData["Error"] = null;
				}
				else
                {
					//heeft dit item al
					TempData["Error"] = "Ninja heeft al een item van dezelfde categorie";
                }
			}
			else
			{
				// te weinig  geld
				TempData["Error"] = "Ninja heeft te weinig goud";
			}
			return RedirectToAction("Edit", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
					new { controller = "Ninja", action = "Edit", Id = ninjaId }));
		}

		[HttpPost]
		public IActionResult SellItem(int itemId, int ninjaId)
		{
			ninjaEquipmentRepositorySql.SellEquipment(ninjaId, itemId);
			return RedirectToAction("Edit", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
				new { controller = "Ninja", action = "Edit", Id = ninjaId }));
		}

		[HttpPost]
		public IActionResult SellAll(int ninjaId)
		{
			foreach(var item in ninjaEquipmentRepositorySql.ShowEquipment(ninjaId))
            {
				SellItem(item.EquipmentId, ninjaId);
            }
			return RedirectToAction("Edit", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
				new { controller = "Ninja", action = "Edit", Id = ninjaId }));
		}
	}
}