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
    public class CategoryRepository : ICategoryRepository
    {
        private InventoryTestEntities _db = new InventoryTestEntities();
        public bool Create_Category(MST_Category Category_Obj)
        {
            if (Category_Exist_Or_Not_By_Name(Category_Obj.Name))
            {
                Category_Obj.Created_On = DateTime.Now;
                _db.MST_Category.Add(Category_Obj);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public bool Delete_Category_By_Id(int id)
        {

            if (Category_Exist_Or_Not(id))
            {
                MST_Category Category_Obj = _db.MST_Category.Find(id);
                Category_Obj.IsActive = false;
                _db.MST_Category.Remove(Category_Obj);
                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
            
        }

        public MST_Category Get_Category_By_Id(int id)
        {
            MST_Category Category_Obj = _db.MST_Category.Find(id);
            return Category_Obj;
        }

        public List<MST_Category> Get_Category_List()
        {
            return _db.MST_Category.AsQueryable().Where(x=>x.IsActive==true).ToList();
        }

        public bool Update_Category(int id, MST_Category Category_Obj)
        {
            if (Category_Exist_Or_Not(id))
            {
                return false;
            }
            var Old_Category_Details = _db.MST_Category.AsQueryable().Where(x => x.Category_Id == id).FirstOrDefault();

            Old_Category_Details.Name = Category_Obj.Name;
            Old_Category_Details.Description = Category_Obj.Description;
            Old_Category_Details.Modified_By = 1;
            Old_Category_Details.Modified_On = DateTime.Now;

            _db.Entry(Old_Category_Details).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
                return true;

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Category_Exist_Or_Not(id))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Category_Exist_Or_Not(int id)
        {
            var Old_Category_Details = _db.MST_Category.AsQueryable().Where(x => x.Category_Id == id && x.IsActive == true).FirstOrDefault();

            if (Old_Category_Details == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Category_Exist_Or_Not_By_Name(string name)
        {
            var Old_Category_Details = _db.MST_Category.AsQueryable().Where(x => x.Name == name && x.IsActive == true).FirstOrDefault();

            if (Old_Category_Details == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}