using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EClassWebApp.Models
{
    public class Student
    {
        public string StudentID { get; set; }
        public string ClassID { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}