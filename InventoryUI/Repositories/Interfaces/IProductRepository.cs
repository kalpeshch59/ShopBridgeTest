using InventoryUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        System.Threading.Tasks.Task<List<Product>> Get_Product_List();
        System.Threading.Tasks.Task<Product> Get_Product_By_Id(int id);
        System.Threading.Tasks.Task<bool> Update_Product(int id, Product Product_Obj);
        System.Threading.Tasks.Task<bool> Create_Product(Product Product_Obj);
        System.Threading.Tasks.Task<bool> Delete_Product_By_Id(int id);
        System.Threading.Tasks.Task<bool> Product_Exist_Or_Not(int id);
        System.Threading.Tasks.Task<bool> Product_Exist_Or_Not_By_Name(string name);
    }
}
