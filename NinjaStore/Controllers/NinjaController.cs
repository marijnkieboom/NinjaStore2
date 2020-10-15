using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
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
		public IActionResult BuyItem(Equipment equipment, Ninja ninja)
		{
			if (equipment.Value <= ninja.Gold)
			{
				
				ninjaEquipmentRepositorySql.BuyEquipment(ninja, equipment);
				return RedirectToAction("Edit", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
					new { controller = "Ninja", action = "Edit", Id = ninja.NinjaId }));
			} else
            {
				ViewBag.Error = "dit kan je niet betalen";
				return RedirectToAction("Edit", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
					new { controller = "Ninja", action = "Edit", Id = ninja.NinjaId }));
			}
		}


		[HttpPost]
		public IActionResult SellItem(Equipment equipment, Ninja ninja)
		{
			ninjaEquipmentRepositorySql.SellEquipment(ninja.NinjaId, equipment.EquipmentId);
			return RedirectToAction("Edit", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
				new { controller = "Ninja", action = "Edit", Id = ninja.NinjaId }));
		}


	}
}