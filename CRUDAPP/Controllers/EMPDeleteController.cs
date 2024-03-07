using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPP.Controllers
{
	public class EMPDeleteController : Controller
	{
		EmployyeDB DBobj=new EmployyeDB();
		public IActionResult Load_Delete(int id)
		{	
			return View();
		}
		public IActionResult Profile_Delete(Employee objcls)
		{
			try
			{
				if (ModelState.IsValid)
				{
					string s = DBobj.DBDelete(objcls);
					TempData["msg"] = s;
				}
			}
			catch (Exception ex)
			{
				TempData["msg1"] = ex.Message.ToString();
			}
			return View("Load_Delete");
		}
	}
}
