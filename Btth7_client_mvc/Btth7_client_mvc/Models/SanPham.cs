using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btth7_client_mvc.Models
{
    public class SanPham
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public Nullable<int> DonGia { get; set; }
        public string MaDanhMuc { get; set; }

     //   public virtual Danhmuc DanhMuc { get; set; }
    }
}