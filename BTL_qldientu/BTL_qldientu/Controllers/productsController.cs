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
using BTL_qldientu.Models;

namespace BTL_qldientu.Controllers
{
    public class productsController : ApiController
    {
        private DBMAKETAPI db = new DBMAKETAPI();

        //get all
        [HttpGet]
        [Route("api/products")] 
        public IQueryable<product> Getproducts()
        {
            return db.products;
        }


        //thêm sản phẩm

        public product PostGiaBan(product product)
        {
            db.products.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SPExists(product.pro_id))
                {

                }
                else
                {
                    throw;
                }
            }

            return product;
        }
        private bool SPExists(string id)
        {
            return db.products.Count(e => e.pro_id == id) > 0;
        }

    }
}