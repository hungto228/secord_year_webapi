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
using QLTHUVIENSACH.Models;

namespace QLTHUVIENSACH.Controllers
{
    public class QLTHUVIENSACHController : ApiController
    {
        private QLTHUVIENSACHEntities db = new QLTHUVIENSACHEntities();
        //lấy các loại sách theo tên sách
        [HttpGet]
        [ActionName("Tohung")]
        //[Route("api/QLTVS/books")]
        public List<Sach> getSachWithTenSach(string tensach)
        {
            List<Sach> listSach = new List<Sach>();
            foreach (Sach item in db.Saches)
            {
                if (item.TenSach.Contains(tensach))
                {
                    listSach.Add(item);
                }
            }
            return listSach;
        }


            [HttpGet]
            [Route("api/QLTVS/books")]
            public List<Sach> getSachWithTG(string tenTG, string sdt)
            {
                List<Sach> listSach = new List<Sach>();

                foreach (TacGia itemTG in db.TacGias)
                {
                    if (itemTG.TenTG.Contains(tenTG) && itemTG.SDT.Contains(sdt))
                    {
                        foreach (Sach itemSach in db.Saches)
                        {
                            if (itemSach.MaTG.Contains(itemTG.MaTG))
                            {
                                listSach.Add(itemSach);
                            }
                        }
                    }
                }
                return listSach;
            }

            [HttpGet]
            [Route("api/QLTVS/books")]
            public List<Sach> getSachWithNXB(string tenNXB, string gt, string email)
            {
                List<Sach> listSach = new List<Sach>();

                foreach (NXB itemNXB in db.NXBs)
                {
                    if (itemNXB.TenNXB.Contains(tenNXB) && itemNXB.GioiTinh.Contains(gt) && itemNXB.Email.Contains(email))
                    {
                        foreach (Sach itemSach in db.Saches)
                        {
                            if (itemSach.MaNXB.Contains(itemNXB.MaNXB))
                            {
                                listSach.Add(itemSach);
                            }
                        }
                    }
                }
                return listSach;
            }

            [HttpGet]
            [Route("api/QLTVS/booksnew")]
            public List<Sach> getSachNew(string tenNXB, string gt, string email)
            {
                List<Sach> listSach = new List<Sach>();
                int currentYear = DateTime.Now.Year;
                int recipe = currentYear - 5;
                foreach (NXB itemNXB in db.NXBs)
                {
                    if (itemNXB.TenNXB.Contains(tenNXB) && itemNXB.GioiTinh.Contains(gt) && itemNXB.Email.Contains(email))
                    {
                        foreach (Sach itemSach in db.Saches)
                        {
                            DateTime date = Convert.ToDateTime(itemSach.NamXB);
                            int namXB = date.Year;
                            if (itemSach.MaNXB.Contains(itemNXB.MaNXB) && namXB >= recipe && namXB <= currentYear)
                            {
                                listSach.Add(itemSach);
                            }
                        }
                    }
                }
                return listSach;
            }

            private bool NXBExists(string id)
            {
                return db.NXBs.Count(e => e.MaNXB == id) > 0;
            }
        }
    }

