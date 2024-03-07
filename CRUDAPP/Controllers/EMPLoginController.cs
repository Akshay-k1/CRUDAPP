using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;
namespace CRUDAPP.Controllers
{
	public class EMPLoginController : Controller
	{
		EmployyeDB DBobj = new EmployyeDB();
		public IActionResult LoginLoad()
		{
			return View();
		}
		public IActionResult Login_Click(Employee objcls) 
		{
			try
			{
				if(ModelState.IsValid)
				{
					int employeeId;
					string resp = DBobj.DBlogin(objcls, out employeeId);
					TempData["msg"] = resp;

					if (resp == "success")
					{
						return RedirectToAction("Profile_Load", "ProfileView", new { id = employeeId });
					}
					else
					{
						TempData["msg2"] = resp;
						return View("LoginLoad");
					}
				}
			}
			catch (Exception ex)
			{
				TempData["msg"] = ex.Message;
			}
			return View("LoginLoad");
		}
	}
}
