using ApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWeb.Controllers
{
    public class userController : ApiController
    {
        private user[] users = new user[]
{
    new user { Id = 1, Name = "Haleemah Redfern", Email = "Email1@mail.com", Phone = "01111111"},
    new user { Id = 2, Name = "Aya Bostock", Email = "Email2@mail.com", Phone = "01111111"},
    new user { Id = 3, Name = "Sohail Perez", Email = "Email3@mail.com", Phone = ""},
    new user { Id = 4, Name = "Merryn Peck", Email = "Email4@mail.com", Phone = "01111111"},
    new user { Id = 5, Name = "Cairon Reynolds", Email = "Email5@mail.com", Phone = ""}
};
        // GET: api/User
        //[ResponseType(typeof(IEnumerable<User>))]
        //public User[] Get()
        public IEnumerable<user> Get()
        {
            return users;
        }

        // GET: api/User/5
        public user Getname(string name)
        {
            bool ok = false;
            user tg = null;
            foreach (user u in users)
            {
                if (u.Name.Equals(name))
                {
                    ok = true;
                    tg = u;
                }
            }
            if (!ok)
                return null;
            else return tg;
        }
        public user Getid(int id)
        {
            if (id < 0 || id >= users.Length)
            {
                return null;
            }
            return users[id];// users[id].Name;
        }
        [Route("api/Users/{name}")]
        public IEnumerable<user> PostUsers(string name, [FromBody] user u)
        {
            int n = users.Length;
            Array.Resize(ref users, n + 1);
            users[n] = u;
            return users;
        }
        // PUT: api/Users/5
        //Body của response là true trong Trường hợp thành công, False trong trường hợp thất bại
        [Route("api/Users/{id}")]
        public IEnumerable<user> Put(int id, [FromBody] user value)
        {
            bool ok = true;
            int n = users.Length;
            if (id < 0 || id >= n)
                ok = false;
            else
            {
                users[id] = value;
            }
            return users;
        }

        // DELETE: api/Users/5
        [Route("api/Users/{id}")]
        public IEnumerable<user> Delete(int id)
        {
            int n = users.Length;
            user[] t = new user[n - 1];
            if (id < 0 || id >= n)
                return null;
            else
            {
                for (int i = 0; i < id; i++)
                    t[i] = users[i];
                for (int i = id; i < n - 1; i++)
                    t[i] = users[i + 1];
                users = t;
            }
            return t;
        }

    }

}
