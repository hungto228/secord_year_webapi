using BasicAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuthentication.Controllers
{
    public class BasicAuthentication : ApiController
    {
        [BasicAuthentication]
        public string Get()
        {
            return "WebAPI Method Called";
        }

    }
}
