using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_qldientu_client.Models
{
    public class product
    {
        public string pro_id { get; set; }
        public string pro_username { get; set; }
        public string pro_image { get; set; }
        public string pro_desc { get; set; }
        public Nullable<int> pro_price { get; set; }
    }
}