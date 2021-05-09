using InventoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApi.Repositories.Interface
{
   public interface IProductRepository
    {
        List<MST_Product> Get_Product_List();
        MST_Product Get_Product_By_Id(int id);
        bool Update_Product(int id, MST_Product Product_Obj);
        bool Create_Product(MST_Product Product_Obj);
        bool Delete_Product_By_Id(int id);
        bool Product_Exist_Or_Not(int id);
        bool Product_Exist_Or_Not_By_Name(string name);
    }
}
