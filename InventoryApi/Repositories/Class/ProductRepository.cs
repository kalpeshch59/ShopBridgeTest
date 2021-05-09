using InventoryApi.Models;
using InventoryApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace InventoryApi.Repositories.Class
{
    public class ProductRepository : IProductRepository
    {
        private InventoryTestEntities _db = new InventoryTestEntities();
        public bool Create_Product(MST_Product Product_Obj)
        {
            if (Product_Exist_Or_Not_By_Name(Product_Obj.Name))
            {
                Product_Obj.Created_On = DateTime.Now;
                Product_Obj.IsActive = true;
                _db.MST_Product.Add(Product_Obj);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool Delete_Product_By_Id(int id)
        {

            if (!Product_Exist_Or_Not(id))
            {
                MST_Product Product_Obj = _db.MST_Product.Find(id);
                Product_Obj.IsActive = false;
                _db.MST_Product.Remove(Product_Obj);
                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }

        }

        public MST_Product Get_Product_By_Id(int id)
        {
            MST_Product Product_Obj = _db.MST_Product.Find(id);
            return Product_Obj;
        }

        public List<MST_Product> Get_Product_List()
        {
            return _db.MST_Product.AsQueryable().Where(x => x.IsActive == true).ToList();
        }

        public bool Update_Product(int id, MST_Product Product_Obj)
        {
            if (Product_Exist_Or_Not(id))
            {
                return false;
            }
            var Old_Product_Details = _db.MST_Product.AsQueryable().Where(x => x.Id == id).FirstOrDefault();

            Old_Product_Details.Name = Product_Obj.Name;
            Old_Product_Details.Description = Product_Obj.Description;
            Old_Product_Details.Modified_By = 1;
            Old_Product_Details.Modified_On = DateTime.Now;

            _db.Entry(Old_Product_Details).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
                return true;

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_Exist_Or_Not(id))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Product_Exist_Or_Not(int id)
        {
            var Old_Product_Details = _db.MST_Product.AsQueryable().Where(x => x.Id == id&&x.IsActive==true).FirstOrDefault();

            if (Old_Product_Details == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Product_Exist_Or_Not_By_Name(string name)
        {
            var Old_Product_Details = _db.MST_Product.AsQueryable().Where(x => x.Name == name && x.IsActive == true).FirstOrDefault();

            if (Old_Product_Details == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}