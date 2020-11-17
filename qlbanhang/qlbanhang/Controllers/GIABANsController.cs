using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using qlbanhang.Models;

namespace qlbanhang.Controllers
{
    public class GIABANsController : ApiController
    {
        private QLBANHANGEntities2 db = new QLBANHANGEntities2();

        //lấy các loại hàng hóa theo mã loại
        [HttpGet]
         [Route("api/QLBanHangs/getHangHoas")]
        [BasicAuthentication]
        public List<HANGHOA> getHangHoaWithML(string maLoai)
        {
            List<HANGHOA> listHH = new List<HANGHOA>();
            foreach (HANGHOA hh in db.HANGHOAs)
            {
                if (hh.MALOAI.Contains(maLoai))
                {
                    listHH.Add(hh);
                }
            }
            return listHH;
        }

        //lấy các loại hàng hóa theo tên loại
        [HttpGet]
      //  [Route("api/QLBanHangs/getHangHoas")]
        public List<HANGHOA> getHangHoaWithTL(string tenLoai)
        {
            List<HANGHOA> listHH = new List<HANGHOA>();
            LOAIHANG loai = new LOAIHANG();
            string id = "";
            foreach (LOAIHANG item in db.LOAIHANGs)
            {
                if (item.TENLOAI.Contains(tenLoai))
                {
                    id = item.MALOAI;
                    foreach (HANGHOA hh in db.HANGHOAs)
                    {
                        if (hh.MALOAI.Contains(id))
                        {
                            listHH.Add(hh);
                        }

                    }
                }

            }
            return listHH;
        }

        //lấy các loại hàng hóa sắp hết (<5)
        [HttpGet]
      //  [Route("api/QLBanHangs/getHangHoaSapHet")]
        public List<HANGHOA> getHangHoaWithSL()
        {
            List<HANGHOA> listHH = new List<HANGHOA>();
            foreach (HANGHOA hh in db.HANGHOAs)
            {
                if (hh.SOLUONGCON < 5)
                {
                    listHH.Add(hh);
                }
            }
            return listHH;
        }

        //get giá bán mã hàng tại thời điểm hiện tại
        [HttpGet]
       // [Route("api/QLBanHangs/getGiaBanCurrentDate")]
        public List<GIABAN> getGBCurrentDate()
        {
            string currentDatetime = DateTime.Now.ToString("dd/MM/yyyy");
            List<GIABAN> listGB = new List<GIABAN>();
            foreach (GIABAN gb in db.GIABANs)
            {
                //if (gb.MaHang.Contains(mh))
                //{
                DateTime startDatetime = DateTime.ParseExact(gb.NGAYBD, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime endDatetime = DateTime.ParseExact(gb.NGAYKT, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                for (DateTime i = startDatetime; i <= endDatetime; i = i.AddDays(1))
                {
                    string time = i.ToString("dd/MM/yyyy");
                    if (currentDatetime.Contains(time))
                    {
                        listGB.Add(gb);
                    }
                }

                //}
            }
            return listGB;
        }

        //get giá bán mã hàng tại thời điểm hiện tại trong khoảng giá min max
        [HttpGet]
      //  [Route("api/QLBanHangs/getGiaBan")]
        public List<GIABAN> getGBMinMax(int min, int max)
        {
            string currentDatetime = DateTime.Now.ToString("yyyy/MM/dd");
            List<GIABAN> listGB = new List<GIABAN>();
            foreach (GIABAN gb in db.GIABANs)
            {
                int gia = (int)gb.GIA;
                if (gia >= min && gia <= max)
                {
                    DateTime startDatetime = DateTime.ParseExact(gb.NGAYBD, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    DateTime endDatetime = DateTime.ParseExact(gb.NGAYKT, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    for (DateTime i = startDatetime; i <= endDatetime; i = i.AddDays(1))
                    {
                        string time = i.ToString("yyyy/MM/dd");
                        if (currentDatetime.Contains(time))
                        {
                            listGB.Add(gb);
                        }
                    }
                }
            }
            return listGB;
        }

        //lấy toàn bộ thông tin giá bán theo mã hàng
        [HttpGet]
        //[Route("api/QLBanHangs/getGiaBan")]
        public List<GIABAN> getGBWithMH(string maHang)
        {
            List<GIABAN> listGB = new List<GIABAN>();
            foreach (GIABAN item in db.GIABANs)
            {
                if (item.MAHANG.Contains(maHang))
                {
                    listGB.Add(item);
                }

            }
            return listGB;
        }

        //thêm giá bán
      //  [Route("api/QLBanHangs/addGiaBan")]
        public GIABAN PostGiaBan(GIABAN giaBan)
        {
            db.GIABANs.Add(giaBan);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GiaBanExists(giaBan.MAGIABAN))
                {

                }
                else
                {
                    throw;
                }
            }

            return giaBan;
        }

        // Cập nhật giá bán theo mã
        [ResponseType(typeof(void))]
      //  [Route("api/QLBanHangs/updateGiaBan")]
        public IHttpActionResult PutGiaBan(string id, GIABAN giaBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giaBan.MAGIABAN)
            {
                return BadRequest();
            }

            db.Entry(giaBan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaBanExists(id))
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

        private bool GiaBanExists(string id)
        {
            return db.GIABANs.Count(e => e.MAGIABAN == id) > 0;
        }

        //xóa giá bán theo mã
        [HttpDelete]
       // [Route("api/QLBanHangs/deleteGiaBan")]
        public bool DeleteGiaBan(string id)
        {
            bool isDelete = false;
            GIABAN giaBan = db.GIABANs.Find(id);
            if (giaBan != null)
            {
                db.GIABANs.Remove(giaBan);
                db.SaveChanges();
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
            return isDelete;
        }

        //Lấy toàn bộ thông tin hàng hóa và giá bán hiện tại (theo mã hàng)
        [HttpGet]
      //  [Route("api/QLBanHangs/getAll")]
        public List<HANGHOA> getAll(string maHang)
        {
            string currentDatetime = DateTime.Now.ToString("yyyy/MM/dd");
            List<GIABAN> listGB = new List<GIABAN>();

            List<HANGHOA> listHH = new List<HANGHOA>();
            foreach (HANGHOA hh in db.HANGHOAs)
            {
                if (hh.MAHANG.Contains(maHang))
                {
                    foreach (GIABAN gb in db.GIABANs)
                    {
                        if (gb.MAHANG.Contains(maHang))
                        {
                            DateTime startDatetime = DateTime.ParseExact(gb.NGAYBD, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                            DateTime endDatetime = DateTime.ParseExact(gb.NGAYKT, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                            for (DateTime i = startDatetime; i <= endDatetime; i = i.AddDays(1))
                            {
                                string time = i.ToString("yyyy/MM/dd");
                                if (currentDatetime.Contains(time))
                                {
                                    listGB.Add(gb);
                                    HANGHOA hangHoa = new HANGHOA();
                                    hangHoa = hh;
                                    hangHoa.gIABANs = listGB;

                                }

                            }
                        }
                    }
                    listHH.Add(hh);
                }
            }
            return listHH;
        }

        //thêm hàng hóa
        [Route("api/QLBanHangs/addHangHoa")]
        public HANGHOA addHangHoa(HANGHOA hangHoa)
        {
            db.HANGHOAs.Add(hangHoa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HangHoaExists(hangHoa.MAHANG))
                {

                }
                else
                {
                    throw;
                }
            }
            return hangHoa;
        }

        // Cập nhật hàng hóa theo mã hàng
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/QLBanHangs/updateHangHoa")]
        public IHttpActionResult updateHangHoa(string id, HANGHOA hangHoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hangHoa.MAHANG)
            {
                return BadRequest();
            }

            db.Entry(hangHoa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangHoaExists(id))
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
        private bool HangHoaExists(string id)
        {
            return db.HANGHOAs.Count(e => e.MAHANG == id) > 0;
        }

        //xóa hàng hóa theo mã
        [HttpDelete]
        [Route("api/QLBanHangs/deleteHangHoa")]
        public bool DeleteHangHoa(string id)
        {
            bool isDelete = false;
            HANGHOA hangHoa = db.HANGHOAs.Find(id);
            if (hangHoa != null)
            {
                db.HANGHOAs.Remove(hangHoa);
                db.SaveChanges();
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
            return isDelete;
        }

    }
}