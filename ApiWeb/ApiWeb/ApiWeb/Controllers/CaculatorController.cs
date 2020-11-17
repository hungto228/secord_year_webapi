using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWeb.Controllers
{
    public class CaculatorController : ApiController
    {
        // GET: api/Caculator
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Caculator/5
        public string Get(int id)
        {
            return "Welcomto caculato with api";
        }
        [HttpPut]
        public float Sum(float a, float b)
        {
            return a + b;
        }
        [HttpPut]
        public float Subtract(float a, float b)
        {
            return a - b;

        }

        [HttpPut]
        public float Mutil(float a, float b)
        {
            return a * b;
        }
        [HttpPut]
        public float Divice(float a, float b)
        {
            float kg = 0;
            try
            {
                kg = a / b;
            }
            catch { }
            return kg;
        }


        [HttpPut]
        public float BassicCaculator(float a, float b, char c)
        {
            float kg = 0;
            switch (c)
            {
                case'+':kg = a + b;
                    break;
                case '-':kg = a - b;
                    break;
                case '*':kg = a * b;
                    break;
                case '/':if (b != 0)
                    { kg = a / b; }
                    break;

            }
            return kg;

        }
    }
}
