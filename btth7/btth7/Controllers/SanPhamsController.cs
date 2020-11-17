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
using btth7.Models;

namespace btth7.Controllers
{
    public class SanPhamsController : ApiController
    {
        private btth7Entities1 db = new btth7Entities1();


        // GET: api/SanPhams
        //[Route("api/getall")]
        public IQueryable<SanPham> GetSanPhams()
        {
            return db.SanPhams;
        }


        // api/SanPhams/withtensp?tensp=macbook 
        [HttpGet]
        public List<SanPham> withtensp(string tensp)
        {
            List<SanPham> listsp = new List<SanPham>();
            foreach (SanPham item in db.SanPhams)
            {
                if (item.Ten.Contains(tensp))
                {
                    listsp.Add(item);
                }
            }
            return listsp;
        }
        // GET: api/SanPhams/getsanphamwithmadanhmuc?madanhmuc=1
        //get san pham with ma danh muc

        [HttpGet]
        public List<SanPham> getsanphamwithmadanhmuc(string madanhmuc)
        {
            List<SanPham> listsp = new List<SanPham>();

            foreach (DanhMuc itemdanhmuc in db.DanhMucs)
            {
                if (itemdanhmuc.MaDanhMuc.Contains(madanhmuc))
                {
                    foreach (SanPham itemsp in db.SanPhams)
                    {
                        if (itemsp.MaDanhMuc.Contains(itemdanhmuc.MaDanhMuc))
                        {
                            listsp.Add(itemsp);
                        }
                    }
                }
            }
            return listsp;
        }
        //get sp tu min roi max
        public List<SanPham> getSPMinMax(int min, int max)
        {
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (SanPham item in db.SanPhams)
            {
                int gia = (int)item.DonGia;
                if (gia >= min && gia <= max)
                {
                    sanPhams.Add(item);
                }
            }
            return sanPhams;
        }
        //Lấy thông tin các SanPham có DonGia (Cao thấp hơn giá nhập vào khoảng 1 triệu)
        public List<SanPham> getSPCT(int gia)
        {
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (SanPham item in db.SanPhams)
            {
                int donGia = (int)item.DonGia;
        int temp = gia + 1000000;
        int temp1 = gia - 1000000;
                //if (gia <= 1000000)
                //{
                //    if (gia >= temp1 && gia <= temp)
                //    {
                //        sanPhams.Add(item);
                //    }
                //}
                //{
                if (gia >= temp1 && gia <= temp)
                {
                    sanPhams.Add(item);
                }
    //}
}
            return sanPhams;
        }

        //thêm sản phẩm
        
        public SanPham PostGiaBan(SanPham sanPham)
        {
            db.SanPhams.Add(sanPham);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SPExists(sanPham.Ma))
                {

                }
                else
                {
                    throw;
                }
            }

            return sanPham;
        }
        private bool SPExists(string id)
        {
            return db.SanPhams.Count(e => e.Ma == id) > 0;
        }

        // Cập nhật sản phẩm theo mã sản phẩm
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/UpdateSP")]
        public IHttpActionResult updateHangHoa(string id, SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPham.Ma)
            {
                return BadRequest();
            }

            db.Entry(sanPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpDelete]
        [Route("api/XoaSp")]
        public bool DeleteGiaBan(string maSp)
        {
            bool isDelete = false;
            foreach (SanPham item in db.SanPhams)
            {
                if (item.Ma.Equals(maSp))
                {
                    isDelete = true;
                    db.SanPhams.Remove(item);
                }
                else
                {
                    isDelete = false;
                }

            }
            db.SaveChanges();
            return isDelete;
        }
    

        //[HttpGet]
        //public List<SanPham> getsanphamwithmadanhmuc(string madanhmuc)
        //{
        //    List<SanPham> listsp = new List<SanPham>();

        //    foreach (DanhMuc itemdanhmuc in db.DanhMucs)
        //    {
        //        if (itemdanhmuc.MaDanhMuc.Contains(madanhmuc))
        //        {
        //            foreach (SanPham itemsp in db.SanPhams)
        //            {
        //                if (itemsp.MaDanhMuc.Contains(itemdanhmuc.MaDanhMuc))
        //                {
        //                    listsp.Add(itemsp);
        //                }
        //            }
        //        }
        //    }
        //    return listsp;
        //}


    }
}