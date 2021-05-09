using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InventoryApi.Models;
using InventoryApi.Repositories.Class;

namespace InventoryApi.Controllers
{
    public class ProductController : ApiController
    {

      private  ProductRepository ProductRepo;

        public  ProductController()
        {
            ProductRepo = new ProductRepository();
        }
        [HttpGet]
        public List<MST_Product> GetProductList()
        {

            return ProductRepo.Get_Product_List();
        }

        [ResponseType(typeof(MST_Product))]
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var Product_Details = ProductRepo.Get_Product_By_Id(id);

            return Ok(Product_Details);
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutProduct(int id, MST_Product Product_Obj)
        {
            var Update_Product = ProductRepo.Update_Product(id, Product_Obj);
            if (Update_Product)
            {
                return StatusCode(HttpStatusCode.OK);

            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);

            }
        }

        [ResponseType(typeof(MST_Product))]
        [HttpPost]
        public async Task<IHttpActionResult> PostProduct(MST_Product Product_Obj)
        {
            var result = ProductRepo.Create_Product(Product_Obj);
            if (result)
            {
                return StatusCode(HttpStatusCode.OK);

            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);

            }

        }

        [ResponseType(typeof(MST_Product))]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete_Product(int id)
        {
            var result = ProductRepo.Delete_Product_By_Id(id);
            if (result)
            {
                return StatusCode(HttpStatusCode.OK);

            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);

            }

        }

    }
}