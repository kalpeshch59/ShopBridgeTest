using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryUI.Data;
using InventoryUI.Models;
using InventoryUI.Repositories.Classes;

namespace InventoryUI.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository ProductRepo;
        private CommonRepository CommonRepo;

        public ProductsController()
        {
            ProductRepo = new ProductRepository();
            CommonRepo = new CommonRepository();
        }
        public async Task<ActionResult> Index()
        {
            if (Session["CategoryList"] == null)
            {
                Session["CategoryList"] = await CommonRepo.Get_Category_List();
            }
            return View(await ProductRepo.Get_Product_List());
        }

        public async Task<ActionResult> Details(long? id)
        {
           var result= await ProductRepo.Delete_Product_By_Id((int)id);
            if(result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new ExecutionEngineException();
                     
            }
        }

        public async Task<ActionResult> Create()
        {
            var CategoryList = 
            ViewBag.Category_Id = new SelectList(await CommonRepo.Get_Category_List(), "Category_Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Category_Id,Price,Brand,Model,Weight,In_Box_Details,IsActive,Created_On,Created_By,Modified_On,Modified_By")] Product product)
        {
            ViewBag.Category_Id = new SelectList(await CommonRepo.Get_Category_List(), "Category_Id", "Name",product.Category_Id);
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await ProductRepo.Create_Product(product);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new ExecutionEngineException();

                    }
                }

                return View(product);
            }
            catch
            {
                        throw new ExecutionEngineException();
            }
        }

        public async Task<ActionResult> Edit(long? id)
        {

            ViewBag.Category_Id = new SelectList(await CommonRepo.Get_Category_List(), "Category_Id", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await ProductRepo.Get_Product_By_Id((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Category_Id,Price,Brand,Model,Weight,In_Box_Details,IsActive,Created_On,Created_By,Modified_On,Modified_By")] Product product)
        {
            try
            {

                ViewBag.Category_Id = new SelectList(await CommonRepo.Get_Category_List(), "Category_Id", "Name", product.Category_Id);
                if (ModelState.IsValid)
                {
                    var result = await ProductRepo.Update_Product((int)product.Id,product);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new ExecutionEngineException();

                    }
                }

                return View(product);
            }
            catch
            {
                throw new ExecutionEngineException();
            }
        }

        public async Task<ActionResult> Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await ProductRepo.Get_Product_By_Id((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category_Id = new SelectList(await CommonRepo.Get_Category_List(), "Category_Id", "Name");
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await ProductRepo.Delete_Product_By_Id((int)id);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new ExecutionEngineException();

                    }
                }

                return RedirectToAction("Delete",id);
            }
            catch
            {
                throw new ExecutionEngineException();
            }
        }

    }
}
