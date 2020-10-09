using Microsoft.AspNetCore.Mvc;
using NinjaStore.Data;
using NinjaStore.Data.Models;

namespace NinjaStore.Web.Controllers
{
	public class EquipmentController : Controller
	{
		// GET: EquipmentController
		readonly EquipmentRepository equipmentRepository = new EquipmentRepository();
		public ActionResult Index()
		{
			var model = equipmentRepository.GetAll();
			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Equipment equipment)
		{
			equipmentRepository.Create(equipment);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int? id)
		{
			if (id.HasValue)
			{
				var equipment = equipmentRepository.GetOne(id.Value);
				return View(equipment);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Edit(int id, Equipment equipment)
		{
			if (id != equipment.EquipmentId)
			{
				return RedirectToAction("Index");
			}
			if (ModelState.IsValid)
			{
				equipmentRepository.Update(equipment);
				return RedirectToAction("Index");
			}
			return View(equipment);
		}

		public IActionResult Details(int? id)
		{
			if (!id.HasValue)
			{
				return RedirectToAction("Create");
			}

			var equipment = equipmentRepository.GetOne(id.Value);
			if (equipment == null)
			{
				return RedirectToAction("Index");
			}

			return View(equipment);
		}

		public IActionResult Delete(int? id)
		{
			if (id.HasValue)
			{
				var equipment = equipmentRepository.GetOne(id.Value);
				if (equipment != null)
				{
					return View(equipment);
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
			equipmentRepository.Delete(id);
			return RedirectToAction("Index");
		}

	}
}
