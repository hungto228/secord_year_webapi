using Btth7_client_mvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Btth7_client_mvc.Controllers
{
    public class SanPhamController : Controller
    {
        string BASE_URI = "https://localhost:44388/api/SanPhams";
        // GET: DanhMuc
        public ActionResult Index()
        {
            IEnumerable<SanPham> sanpham = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var responseTask = client.GetAsync("Get");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    sanpham = JsonConvert.DeserializeObject<List<SanPham>>(data);
                }
            }

            return View(sanpham);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("AddSanPham", content);
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
                SanPham s = null;
                client.BaseAddress = new Uri(BASE_URI);
                var responseTask = client.GetAsync("Get/api/SanPhams/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<SanPham>(data);
                }
                return View("Edit", s);
            }
        }
        [HttpPost]
        public ActionResult Edit(SanPham s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var putTask = client.PutAsync("EditSanPham/" + s.MaDanhMuc, content);
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
