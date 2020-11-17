using EclassWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EclassWebAPI.DTO;

namespace EclassWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public HttpResponseMessage Get()
        {
            using (ECLASSEntities db = new ECLASSEntities())
            {
                //var result = from s in db.Students
                //       select new { s.StudentID, s.FullName, s.Class.Period };

                var result = db.Students;

                return Request.CreateResponse(HttpStatusCode.OK, result.ToList());

                //List<StudentPeriodDTO> listS = new List<StudentPeriodDTO>();
                //foreach(var student in result)
                //{
                //    StudentPeriodDTO s = new StudentPeriodDTO(student.StudentID, student.FullName, student.Period);
                //    listS.Add(s);
                //}
                
                //return listS;
            }

        }

        // GET: api/Student/5
        public Student Get(string id)
        {
            using (ECLASSEntities db = new ECLASSEntities())
            {
                Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                if (s != null)
                    return s;
                else
                    return null;
            }
        }

        [HttpGet]
        public List<Student> GetStudentsByGender(string gender)
        {

            List<Student> listStudent = new List<Student>();
            using (ECLASSEntities db = new ECLASSEntities())
            {
                if (gender.ToLower() == "all")
                    listStudent = db.Students.ToList();
                else if (gender.ToLower() == "female")
                    listStudent = db.Students.Where(s => s.Gender.Value == false).ToList();
                else if (gender.ToLower() == "male")
                    listStudent = db.Students.Where(s => s.Gender.Value == true).ToList();
            }
            return listStudent;
        }

        // POST: api/Student
        [HttpPost]
        public HttpResponseMessage AddStudent([FromBody]Student student)
        {
            try
            {
                using (ECLASSEntities db = new ECLASSEntities())
                {
                    db.Students.Add(student);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Student/5
        [HttpPut]
        public HttpResponseMessage EditStudent(string id, [FromBody]Student student)
        {
            try
            {
                using (ECLASSEntities db = new ECLASSEntities())
                {
                    var s = db.Students.SingleOrDefault(x => x.StudentID == id);
                    if (s != null)
                    {
                        s.FullName = student.FullName;
                        s.ClassID = student.ClassID;
                        s.Birthday = student.Birthday;
                        s.Address = student.Address;
                        s.Email = student.Email;
                        s.Gender = student.Gender;

                        db.SaveChanges();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Student/5
        [HttpDelete]
        public HttpResponseMessage DeleteStudent(string id)
        {
            try
            {
                using (ECLASSEntities db = new ECLASSEntities())
                {
                    Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                    db.Students.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
