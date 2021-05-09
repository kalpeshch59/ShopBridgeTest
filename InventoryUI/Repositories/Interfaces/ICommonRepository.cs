using InventoryUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUI.Repositories.Interfaces
{
    interface ICommonRepository
    {
        System.Threading.Tasks.Task<List<Category>> Get_Category_List();
    }
}
