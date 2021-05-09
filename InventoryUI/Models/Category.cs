using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryUI.Models
{
    public class Category
    {
      
            public int Category_Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<System.DateTime> Created_On { get; set; }
            public Nullable<int> Created_By { get; set; }
            public Nullable<System.DateTime> Modified_On { get; set; }
            public Nullable<int> Modified_By { get; set; }

        }
    }
