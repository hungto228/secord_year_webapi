using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Student_API_MVC.Models;

namespace Student_API_MVC.Controllers
{
    public class Students1Controller : Controller
    {
        private QLSVEntities db = new QLSVEntities();
        public string url = "https://localhost:44333/";
        public HttpClient httpClient = new HttpClient();
        public List<Student> get_API(string URL)
        {
            List<Student> students = new List<Student>();
            var response = httpClient.GetAsync(url + "/"+URL);
            response.Wait();
            var rs = response.Result;
            if (rs.IsSuccessStatusCode)
            {

                var js = rs.Content.ReadAsAsync<List<Student>>();
                js.Wait();
                students = js.Result.ToList();
            }
            else
            {

            }
            return students;
        }
        // GET: Students1
        public ActionResult Index()
        {
            List<Student> students = get_API("get-all");   
            
            return View(students);
        }

        // GET: Students1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string URL = "get-one/" + id;
            var response = httpClient.GetAsync(url + "/get-one/"+id);
            response.Wait();
            var rs = response.Result;
            Student student = new Student();
            if (rs.IsSuccessStatusCode)
            {

                var js = rs.Content.ReadAsAsync<Student>();
                js.Wait();
                student = js.Result;
            }
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students1/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "FacultyID");
            return View();
        }

        // POST: Students1/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,ClassID,FullName,Gender,Birthday,Address,Email,PhoneNumber,Password,Photo")] Student student)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
                var response = httpClient.PostAsync(url + "post",data);
                response.Wait();
                var rs = response.Result;
               
                if (rs.IsSuccessStatusCode)
                {
                    var js = rs.Content.ReadAsAsync<Student>();
                    js.Wait();
                    Student st = js.Result;
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "FacultyID", student.ClassID);
            return View(student);
        }

        // GET: Students1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string URL = "get-one/" + id;
            var response = httpClient.GetAsync(url + "/get-one/" + id);
            response.Wait();
            var rs = response.Result;
            Student student = new Student();
            if (rs.IsSuccessStatusCode)
            {

                var js = rs.Content.ReadAsAsync<Student>();
                js.Wait();
                student = js.Result;
            }
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "FacultyID", student.ClassID);
            return View(student);
        }

        // POST: Students1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,ClassID,FullName,Gender,Birthday,Address,Email,PhoneNumber,Password,Photo")] Student student)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
                var response = httpClient.PutAsync(url + "/edit/" + student.StudentID,data);
                response.Wait();
                var rs = response.Result;
                
                if (rs.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");

                }
                
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "FacultyID", student.ClassID);
            return View(student);
        }

        // GET: Students1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string URL = "get-one/" + id;
            var response = httpClient.GetAsync(url + "/get-one/" + id);
            response.Wait();
            var rs = response.Result;
            Student student = new Student();
            if (rs.IsSuccessStatusCode)
            {

                var js = rs.Content.ReadAsAsync<Student>();
                js.Wait();
                student = js.Result;
            }
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //Student student = db.Students.Find(id);
          
           
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            var response = httpClient.DeleteAsync(url + "/delete/" + id);
            response.Wait();
            var rs = response.Result;

            if (rs.IsSuccessStatusCode)
            {

                //return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
