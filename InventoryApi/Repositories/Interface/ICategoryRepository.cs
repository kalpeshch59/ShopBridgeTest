using InventoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventoryApi.Repositories.Interface
{
    public interface ICategoryRepository
    {
        List<MST_Category> Get_Category_List();
        MST_Category Get_Category_By_Id(int id);
        bool Update_Category(int id, MST_Category Category_Obj);
        bool Create_Category(MST_Category Category_Obj);
        bool Delete_Category_By_Id(int id);
        bool Category_Exist_Or_Not(int id);
    }
}