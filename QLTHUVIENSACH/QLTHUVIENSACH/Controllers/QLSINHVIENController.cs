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
    public class QLSINHVIENController : ApiController
    {
        private QLSINHVIENEntities db = new QLSINHVIENEntities();

    
            [HttpGet]
            [Route("api/QLSV/sinhviens")]
            public List<SinhVien> getSachWithTenSV(string tenSV)
            {
                List<SinhVien> listSV = new List<SinhVien>();
                foreach (SinhVien item in db.SinhViens)
                {
                    if (item.TenSV.Contains(tenSV))
                    {
                        listSV.Add(item);
                    }
                }
                return listSV;
            }

            [HttpGet]
            [Route("api/QLSV/sinhviens")]
            public List<SinhVien> getSachWithDiaChi(string diaChi)
            {
                List<SinhVien> listSV = new List<SinhVien>();
                foreach (SinhVien item in db.SinhViens)
                {
                    if (item.DiaChi.Contains(diaChi))
                    {
                        listSV.Add(item);
                    }
                }
                return listSV;
            }

            [HttpGet]
            [Route("api/QLSV/sinhviens")]
            public List<SinhVien> getnamsinhYear()
            {
                int currentYear = DateTime.Now.Year;
                List<SinhVien> listSV = new List<SinhVien>();
                foreach (SinhVien item in db.SinhViens)
                {
                    DateTime date = Convert.ToDateTime(item.NamSinh);
                    int namSinh = date.Year;
                    int ageCalculation = currentYear - namSinh;
                    if (ageCalculation >= 20)
                    {
                        listSV.Add(item);
                    }
                }
                return listSV;
            }
        }
    }