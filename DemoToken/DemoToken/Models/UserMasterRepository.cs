using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoToken.Models
{
    public class UserMasterRepository : IDisposable
    {
        testtokenEntities db = new testtokenEntities();
        public UserMaster ValidateUser(string username, string password)
        {
            return db.UserMasters.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}