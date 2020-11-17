using EclassWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EclassWebAPI.DTO
{
    public class StudentPeriodDTO
    {
       
        private string studentID;
        private string fullName;
        private string period;

        public string Period { get => period; set => period = value; }
        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }

        public StudentPeriodDTO(string studentID, string fullName, string period)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.period = period;
        }
    }
}