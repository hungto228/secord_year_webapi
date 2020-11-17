using btth7_client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace btth7_client.Controllers
{
    public class DanhMucController : Controller
    {
       string BASE_URI = "https://localhost:44388/api/DanhMucs/";
        // GET: DanhMuc
        public ActionResult Index()
        {
            IEnumerable<Danhmuc> danhmucs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var responseTask = client.GetAsync("Get"); 
              
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    danhmucs = JsonConvert.DeserializeObject<List<Danhmuc>>(data);
                }
            }

            return View(danhmucs);
          
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Danhmuc s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("AddDanhMuc", content);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Server Error. Please contact administrator!");

            return View(s);
        }
        public ActionResult Edit(string id)
        {
            using (var client = new HttpClient())
            {
                Danhmuc s = null;
                client.BaseAddress = new Uri(BASE_URI);
                var responseTask = client.GetAsync("Get/api/DanhMucs/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<Danhmuc>(data);
                }
                return View("Edit", s);
            }
        }
        [HttpPost]
        public ActionResult Edit(Danhmuc s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var putTask = client.PutAsync("EditDanhMuc/" + s.MaDanhMuc, content);
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
    }
  
}