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
    public class CategoryController : ApiController
    {
        CategoryRepository CategoryRepo;

        private CategoryController()
        {
            CategoryRepo = new CategoryRepository();
        }
        [HttpGet]
        public List<MST_Category> GetCategory()
        {
            return CategoryRepo.Get_Category_List();
        }

        [ResponseType(typeof(MST_Category))]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            var Category_Details = CategoryRepo.Get_Category_By_Id(id);

            return Ok(Category_Details);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(int id, MST_Category Category_Obj)
        {
            var Update_Category = CategoryRepo.Update_Category(id, Category_Obj);
            if (Update_Category)
            {
                return StatusCode(HttpStatusCode.OK);

            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);

            }
        }

        [ResponseType(typeof(MST_Category))]
        public async Task<IHttpActionResult> PostCategory(MST_Category Category_Obj)
        {
            var result = CategoryRepo.Create_Category(Category_Obj);
            if (result)
            {
                return StatusCode(HttpStatusCode.OK);

            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);

            }

        }

        [ResponseType(typeof(MST_Category))]
        public async Task<IHttpActionResult> DeleteCategory(int id)
        {
            var result = CategoryRepo.Delete_Category_By_Id(id);
            if (result)
            {
                return  StatusCode(HttpStatusCode.OK);

            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);

            }

        }

    }
}