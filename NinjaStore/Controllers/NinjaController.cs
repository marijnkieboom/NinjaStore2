using Microsoft.AspNetCore.Mvc;
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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Ninja ninja)
		{
			ninjaRepositorySql.Create(ninja);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int? id)
		{
			if (id.HasValue)
			{
				var ninja = ninjaRepositorySql.GetOne(id.Value);
				ViewBag.NinjaEquipment = ninjaEquipmentRepositorySql.ShowEquipment(id.Value);
				ViewBag.AllEquipment = equipmentRepositorySql.GetAll();
				ViewBag.BuyAbleEquipment = ninjaEquipmentRepositorySql.buyAbleEquipment(id.Value);
				ViewBag.Head = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Head);
				ViewBag.Hands = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Hand);
				ViewBag.Feet = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Feet);
				ViewBag.Necklace = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Necklace);
				ViewBag.Chest = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Chest);
				ViewBag.Ring = ninjaEquipmentRepositorySql.getOneItem(id.Value, Category.Ring);
				ViewBag.Strength = ninjaEquipmentRepositorySql.getPoints(id.Value, "Strength");
				ViewBag.Agility = ninjaEquipmentRepositorySql.getPoints(id.Value, "Agility");
				ViewBag.Intelligence = ninjaEquipmentRepositorySql.getPoints(id.Value, "Intelligence");
				return View(ninja);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Edit(int id, Ninja ninja)
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
				if(ninjaEquipmentRepositorySql.getOneItem(ninjaId, item.Category) ==null)
                {
					ninjaEquipmentRepositorySql.BuyEquipment(ninjaId, itemId);
				}
				else
                {
					//heeft dit item al
                }
				// te weinig  geld
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

	


	}
}