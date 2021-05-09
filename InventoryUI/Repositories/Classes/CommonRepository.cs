using InventoryUI.Models;
using InventoryUI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web;
using System.Web.Helpers;
using Newtonsoft;
using Newtonsoft.Json;

namespace InventoryUI.Repositories.Classes
{
    public class CommonRepository : ICommonRepository
    {
        private  MemoryCache _cache = MemoryCache.Default;
       public async System.Threading.Tasks.Task<List<Category>> Get_Category_List()
        {
            if (!_cache.Contains("Category_List"))
            {
                using (var Client = CommonRepository.GetHttpClient())
                {
                    HttpResponseMessage response = await Client.GetAsync("api/Category/GetCategory");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        //List<Category> Category_List = await response.Content.ReadAsAsync<JsonConvert.DeserializeObject<List<Category>>>();
                        List<Category> Category_List = JsonConvert.DeserializeObject<List<Category>>(content);


                        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1);

                        _cache.Add("Category_List", Category_List, cacheItemPolicy);
                        return Category_List;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }                   
            }
            else
            {
                return _cache.Get("Category_List") as List<Category>;
            }
            

            
        }
        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44399/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;           
        }
    }
}