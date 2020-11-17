using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btth7_client.Models
{
    public class Danhmuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Danhmuc()
        {
            this.SanPhams = new HashSet<SanPham>();
        }

        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}