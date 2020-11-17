using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

using EClassWebApp.Models;
using Newtonsoft.Json;

namespace EClassWebApp.Controllers
{
    public class StudentController : Controller
    {
        string BASE_URI = "http://localhost:16046/api/Student/";
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> students = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    students = JsonConvert.DeserializeObject<List<Student>>(data);
                }
            }

            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data,Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("AddStudent",content);
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
                Student s = null;
                client.BaseAddress = new Uri(BASE_URI);
                var responseTask = client.GetAsync("Get/"+id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<Student>(data);
                }
                return View("Edit",s);
            }
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                
                var putTask = client.PutAsync("EditStudent/"+s.StudentID, content);
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