using BTL_qldientu_client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BTL_qldientu_client.Controllers
{
    public class categoryController : Controller
    {
        string BASE_URI = "https://localhost:44348/api/";
        // GET: category
        public ActionResult Index()
        {

            IEnumerable<category> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var responseTask = client.GetAsync("categories");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<List<category>>(data);
                }
            }

            return View(categories);
         
        }

        // GET: category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
