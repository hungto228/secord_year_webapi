using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netcore_tk.model;

namespace netcore_tk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class taikhoancontroller : ControllerBase
    {
        String strconnect = @"Data Source = DESKTOP - L7TGSBN;  initial catalog=test; integrated security=true;";

        private ILogger<taikhoancontroller> _logger;

        public taikhoancontroller(ILogger<taikhoancontroller> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("api/{Controller}")]
        public List<model.taikhoan> getall()
        {
            SqlConnection cn = new SqlConnection(strconnect);
            String sqlString = @"select * from taikhoan";
            SqlDataAdapter da = new SqlDataAdapter(sqlString, cn);
            DataTable dt = new DataTable();//dt chứa dữ liệu lấy 
            da.Fill(dt);                    //Đẩy dữ liệu da vào dt
            List<model.taikhoan> ds = new List<model.taikhoan>();
            foreach (DataRow x in dt.Rows)
            {
                //TaiKhoan db = new TaiKhoan();
                //db.TenTK= x[0].ToString();
                //db.MatKhau = x[1].ToString();
                //db.Mota = x[2].ToString();
                //ds.Add(db);
                ds.Add(new taikhoan() { tentk = x[0].ToString(), matkhau = x[1].ToString() } );// Mota = x[2].ToString() });
            }
            return ds;
        }
        [HttpGet]
        [Route("api/{Controller}/{TenTK}")]
        public taikhoan Get(string TenTK)
        {
            // string strconnect = @"data source=DESKTOP-KL7N773\SQLEXPRESS2014; initial catalog=DEMOCRUD; integrated security=true;";
            SqlConnection cn = new SqlConnection(strconnect);
            // SqlDataAdapter da = new SqlDataAdapter(string.Format("select * from taikhoan where TenTK='{0}'", TenTK), cn);
            String sqlString = "select * from taikhoan where tentk=\'" + TenTK + "\'";
            SqlDataAdapter da = new SqlDataAdapter(sqlString, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            taikhoan db = new taikhoan();
            if (dt.Rows.Count > 0)
                try
                {
                    DataRow x = dt.Rows[0];
                    db.tentk = x[0].ToString();
                    db.matkhau = x[1].ToString();
                  //  db.Mota = x[2].ToString();
                }
                catch (Exception e) { }

            return db;


        }
        [HttpPut]
        [Route("api/{Controller}/{TenTK}")]
        public taikhoan update(string TenTK, taikhoan abc)
        {
            SqlConnection cn = new SqlConnection(strconnect);
            //String sqlString = @"select * from taikhoan";
            SqlDataAdapter da = new SqlDataAdapter(string.Format(@"select * from taikhoan where tentk='{0}'", TenTK), cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format(@"update taikhoan set matkhau='{0}' where tentk='{1}'", abc.matkhau,  TenTK), cn);
                cmd.ExecuteNonQuery();//cập nhật dữ liệu
                cmd.Dispose();
                cn.Close();
                //abc.TenTK = TenTK;
                return abc;
            }
            else
                return null;
        }
        [HttpDelete]
        [Route("api/{Controller}/{TenTK}")]
        public Boolean Delete(string TenTK)//xl
        {
            SqlConnection cn = new SqlConnection(strconnect);
            //String sqlString = @"select * from taikhoan";
            SqlDataAdapter da = new SqlDataAdapter(string.Format(@"select * from taikhoan where tentk='{0}'", TenTK), cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//có
            {
                cn.Open();
                //SqlCommand cmd = new SqlCommand(string.Format(@"delete from taikhoan where TenTK='{0}'", TenTK), cn);
                String deleteString = "delete from taikhoan where tentk = \'" + TenTK + "\'";
                //cmd.ExecuteNonQuery();//lỗi do lệnh ExecuteNonQuery để cập nhật dữ liệu
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand();
                // 2. Set the CommandText property
                cmd.CommandText = deleteString;
                // 3. Set the Connection property
                cmd.Connection = cn;
                // 4. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cn.Close();
                return true;
            }
            else return false;
        }
        [HttpPost]
        [Route("api/{Controller}")]
        public taikhoan Post(taikhoan abc)
        {
            SqlConnection cn = new SqlConnection(strconnect);
            //String sqlgetString = @"select * from taikhoan";
            //String postsqlString = "INSERT INTO taikhoan VALUES('{0}', '{1}', '{2})'", abc.TenTK, abc.MatKhau, abc.Mota);
            SqlDataAdapter da = new SqlDataAdapter(string.Format("select * from taikhoan where tentk='{0}'", abc.tentk), cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)//chưa có
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO taikhoan VALUES ('{0}','{1}')'", abc.tentk, abc.matkhau), cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                return abc;
            }
            else return null;//đã có ko thêm
        }
    




    }
}
