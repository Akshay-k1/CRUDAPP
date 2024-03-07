using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPP.Controllers
{
	public class ProfileViewController : Controller
	{
		EmployyeDB DBobj=new EmployyeDB();
		public IActionResult Profile_Load(int id)
		{
			Employee getlist = DBobj.Profileview(id);
			return View(getlist);
		}
		
	}
}
