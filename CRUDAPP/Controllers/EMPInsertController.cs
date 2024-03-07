using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPP.Controllers
{
    public class EMPInsertController : Controller
    {
        EmployyeDB dbobj = new EmployyeDB();
        public IActionResult Insert_Load()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert_Click(Employee objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.DBinsert(objcls);
                    TempData["msg"] = resp;
                }
              
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Insert_Load", objcls);
        }
    }
}
