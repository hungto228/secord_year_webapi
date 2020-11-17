using BTL_qldientu_client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BTL_qldientu_client.Controllers
{
    public class adminController : Controller
    {
        string BASE_URI = "https://localhost:44348/api/";
        // GET: admin
        public ActionResult Index()
        {
            IEnumerable<admin> admin = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var responseTask = client.GetAsync("admins");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    admin = JsonConvert.DeserializeObject<List<admin>>(data);
                }
            }

            return View(admin);

        }

        // GET: admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Create
        [HttpPost]
        public ActionResult Create(admin collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(collection);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("postadmin", content);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Server Error. Please contact administrator!");

            return View(collection);
        }

        // GET: admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin/Edit/5
        [HttpPost]
        public ActionResult Edit(admin s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var putTask = client.PutAsync("capnhatadmin" + s.ad_id, content);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Server Error. Please contact administrator!");

            return View(s);
        }

        // GET: admin/Delete/5
        public ActionResult Delete()
        {
            IEnumerable<admin> Admin = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var responseTask = client.DeleteAsync("xoaadmin");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    Admin = JsonConvert.DeserializeObject<List<admin>>(data);
                }
            }

            return View(Admin);
        }

        // POST: admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(id);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var putTask = client.DeleteAsync("xoaadmin" );
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Server Error. Please contact administrator!");

            return View(id);
        }
    }
}
