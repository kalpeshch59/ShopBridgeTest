using InventoryUI.Models;
using InventoryUI.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web;

namespace InventoryUI.Repositories.Classes
{
    public class ProductRepository : IProductRepository
    {
        private MemoryCache _cache = MemoryCache.Default;

        public async System.Threading.Tasks.Task<bool> Create_Product(Product Product_Obj)
        {

            using (var Client = CommonRepository.GetHttpClient())
            {

                HttpResponseMessage response = await Client.PostAsJsonAsync("api/Product/PostProduct", Product_Obj);

                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async System.Threading.Tasks.Task<bool> Delete_Product_By_Id(int id)
        {
            using (var Client = CommonRepository.GetHttpClient())
            {

                HttpResponseMessage response = await Client.DeleteAsync("api/Product/Delete_Product/" + id);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async System.Threading.Tasks.Task<Product> Get_Product_By_Id(int id)
        {
            var ProductList = await Get_Product_List();
            var _product = ProductList.AsQueryable().Where(x => x.Id == id).FirstOrDefault();
            return _product;
        }

        public async System.Threading.Tasks.Task<List<Product>> Get_Product_List()
        {

            using (var Client = CommonRepository.GetHttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync("api/Product/GetProductList/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //List<Category> Category_List = await response.Content.ReadAsAsync<JsonConvert.DeserializeObject<List<Category>>>();
                    List<Product> Product_List = JsonConvert.DeserializeObject<List<Product>>(content);


                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1);

                    if (Product_List != null)
                        _cache.Add("Product_List", Product_List, cacheItemPolicy);

                    return Product_List;

                }
            }
            return null;
        }

        public async System.Threading.Tasks.Task<bool> Update_Product(int id, Product Product_Obj)
        {
            using (var Client = CommonRepository.GetHttpClient())
            {

                HttpResponseMessage response = await Client.PutAsJsonAsync("api/Product/PutProduct/" + id, Product_Obj);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async System.Threading.Tasks.Task<bool> Product_Exist_Or_Not(int id)
        {
            var ProductList = await Get_Product_List();
            var _product = ProductList.AsQueryable().Where(x => x.Id == id).FirstOrDefault();
            if (_product != null)
                return true;
            else
                return false;
        }
        public async System.Threading.Tasks.Task<bool> Product_Exist_Or_Not_By_Name(string name)
        {
            var ProductList = await Get_Product_List();
            var _product = ProductList.AsQueryable().Where(x => x.Name == name).FirstOrDefault();
            if (_product != null)
                return true;
            else
                return false;
        }
    }
}