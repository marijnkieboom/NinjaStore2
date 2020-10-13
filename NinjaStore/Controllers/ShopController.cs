using Microsoft.AspNetCore.Mvc;
using NinjaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Web.Controllers
{
	public class ShopController
	{
		NinjaEquipmentRepositorySql nerepo = new NinjaEquipmentRepositorySql();
		

		private IActionResult View()
		{
			throw new NotImplementedException();
		}
	}
}
