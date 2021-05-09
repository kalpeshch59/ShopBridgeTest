using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryUI.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Product Name", Prompt = "Product Name", Description = "Please enter Product Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]{1,50}$", ErrorMessage = "Special Characters Not Allowed")]
        public string Name { get; set; }
        [Display(Name = "Product Description", Prompt = "Product Description", Description = "Please Enter Product Description")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]{1,200}$", ErrorMessage = "Special Characters Not Allowed")]
        public string Description { get; set; }
        [Display(Name = "Product Category", Prompt = "Product Category", Description = "Please Enter Product Category")]
        [Required]
        public int Category_Id { get; set; }
        [Display(Name = "Product Price", Prompt = "Product Price", Description = "Please Enter Product Price")]
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Display(Name = "Product Brand", Prompt = "Product Brand", Description = "Please Enter Product Brand")]
        [RegularExpression(@"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]{1,200}$", ErrorMessage = "Special Characters Not Allowed")]
        public string Brand { get; set; }
        [Display(Name = "Product Model", Prompt = "Product Model", Description = "Please Enter Product Model")]
        [RegularExpression(@"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]{1,200}$", ErrorMessage = "Special Characters Not Allowed")]
        public string Model { get; set; }
        [Display(Name = "Product Brand", Prompt = "Product Brand", Description = "Please Enter Product Brand")]
        [RegularExpression(@"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]{1,200}$", ErrorMessage = "Special Characters Not Allowed")]
        public string Weight { get; set; }
        [Display(Name = "Product In Box Details", Prompt = "Product In Box Details", Description = "Please Enter In Box Details")]
        [RegularExpression(@"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]{1,200}$", ErrorMessage = "Special Characters Not Allowed")]
        public string In_Box_Details { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public Nullable<int> Modified_By { get; set; }

    }
}
