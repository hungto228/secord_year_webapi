using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
using System.Web.Http.Description;
using Student_API_MVC.Models;

namespace Student_API_MVC.Controllers
{
    public class StudentsController : ApiController
    {
        private QLSVEntities db = new QLSVEntities();

        // GET: api/Students
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }
        [ResponseType(typeof(Student))]
        [Route("get-all")]
        public List<Student> getAll()
        {
            List<Student> st = db.Students.ToList();
            return st;
        }
        [ResponseType(typeof(Student))]
        [Route("get-one/{id}")]
        public Student getOne(string id)
        {
            Student st = db.Students.Find(id);
            return st;
        }
        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        [Route("edit/{id}")]
        public IHttpActionResult PutStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentID||getOne(id)==null)
            {
                return BadRequest();
            }
            
            db.Set<Student>().AddOrUpdate(student);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        [Route("post")]
        public Student PostStudent(Student student)
        {
            
            Student st = getOne(student.StudentID);
            if(st != null)
            {
                db.Students.Add(student);

            }
            

            try
            {
                db.SaveChanges();
                return student;
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentID))
                {
                    return student;
                }
                else
                {
                    throw;
                }
            }
           
            
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        [Route("delete/{id}")]
        public IHttpActionResult DeleteStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(string id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}