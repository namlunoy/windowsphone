using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannup.Model
{
    public class MyData
    {
        public static List<Category> ListCategory;
        public static void LoadData()
        {
            ListCategory = new List<Category>();
            ListCategory.Add(new Category() { name = "home", LinkString = "http://mannup.vn/" }); ;
            ListCategory.Add(new Category() { name = "lifestyle", LinkString = "http://mannup.vn/category/lifestyle/" }); ;
            ListCategory.Add(new Category() { name = "FASHION", LinkString = "http://mannup.vn/category/fashion/" }); ;
            ListCategory.Add(new Category() { name = "CULINARY", LinkString = "http://mannup.vn/category/culinary/" }); ;
            ListCategory.Add(new Category() { name = "Cinématographe", LinkString = "http://mannup.vn/category/cinematographe/" }); ;
            ListCategory.Add(new Category() { name = "scent", LinkString = "http://mannup.vn/category/scent/" }); ;
            ListCategory.Add(new Category() { name = "fitness", LinkString = "http://mannup.vn/category/fitness/" }); ;
            ListCategory.Add(new Category() { name = "wheels", LinkString = "http://mannup.vn/category/wheels/" }); ;
            ListCategory.Add(new Category() { name = "read", LinkString = "http://mannup.vn/category/read/" }); ;
            ListCategory.Add(new Category() { name = "community", LinkString = "http://mannup.vn/category/community/" }); ;
    
        }
    }
}
