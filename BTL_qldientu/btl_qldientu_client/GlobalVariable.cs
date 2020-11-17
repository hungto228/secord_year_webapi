using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace btl_qldientu_client
{
    public class GlobalVariable
    {
        public static HttpClient webapiClient = new HttpClient();

    static    GlobalVariable()
        {
            webapiClient.BaseAddress = new Uri("https://localhost:44348/api/");
            webapiClient.DefaultRequestHeaders.Clear();
            webapiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}