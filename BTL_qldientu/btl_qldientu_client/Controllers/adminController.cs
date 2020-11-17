using btl_qldientu_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace btl_qldientu_client.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            IEnumerable<admin> emplist;
            HttpResponseMessage respont = GlobalVariable.webapiClient.GetAsync("admins").Result;
            emplist = respont.Content.ReadAsAsync<IEnumerable<admin>>().Result;
            return View(emplist);
        }
        public ActionResult addOrEdit()
        {
            return View(new admin());
        }

        [HttpPost]
        public ActionResult addOrEdit(admin admin)
        {



            HttpResponseMessage response = GlobalVariable.webapiClient.PostAsJsonAsync("admins/postadmin", admin).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            //HttpResponseMessage response = GlobalVariable.webapiClient.PutAsJsonAsync("admins" , admin).Result;
            //TempData["SuccessMessage"] = "Updated Successfully";

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.webapiClient.DeleteAsync("admin/xoaadmin" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}