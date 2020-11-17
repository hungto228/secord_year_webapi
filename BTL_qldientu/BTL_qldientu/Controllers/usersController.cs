using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BTL_qldientu.Models;

namespace BTL_qldientu.Controllers
{
    public class usersController : ApiController
    {
        private DBMAKETAPI db = new DBMAKETAPI();

        //get all
        [HttpGet]
        [Route("api/users/getname")]
        public IQueryable<user> Getusers()
        {
            return db.users;
        }
        //get ten with username
        [HttpGet]
        [Route("api/users/getname")]
        public List<user> getTenWithUsername(string username)
        {
            List<user> listuser = new List<user>();
            foreach (user Users in db.users)
            {
                if (Users.u_username.Contains(username))
                {
                    listuser.Add(Users);
                }
            }
            return listuser;
        }
        //get ten with email
        [HttpGet]
        [Route("api/users/getemail")]
        public List<user> getTenWithEmail(string email)
        {
            List<user> listuser = new List<user>();
            foreach (user Users in db.users)
            {
                if (Users.u_email.Contains(email))
                {
                    listuser.Add(Users);
                }
            }
            return listuser;
        }


    }
}