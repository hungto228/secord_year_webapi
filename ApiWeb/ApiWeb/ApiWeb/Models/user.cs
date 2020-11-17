using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb.Models
{
    public class user
    {
        int id;
        string name, email, phone;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}