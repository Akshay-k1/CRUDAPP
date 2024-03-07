using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CRUDAPP.Controllers
{
	public class EMPUpdateController : Controller
	{
		EmployyeDB DBobj=new EmployyeDB();
		public IActionResult Load_Update(int id)
		{
			Employee getlist = DBobj.Profileview(id);
			return View(getlist);
		}
		public IActionResult Profile_Upadate(Employee objcls)
		{
			try
			{
				if (ModelState.IsValid)
				{
					string s = DBobj.DBUpdate(objcls);
					TempData["msg"] = s;
				}
			}
			catch (Exception ex)
			{
				TempData["msg"] = ex.Message.ToString();
			}
			return View("Load_Update");
}
	}
}
