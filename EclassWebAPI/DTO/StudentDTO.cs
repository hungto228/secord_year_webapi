using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EclassWebAPI.DTO
{
    public class StudentDTO
    {
        string studentID;
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        string birthday;
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public StudentDTO(string studentID, string fullName, string birthday)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.birthday = birthday;
        }
    }
}