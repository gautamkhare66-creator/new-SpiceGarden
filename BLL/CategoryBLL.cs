using System;
using System.Collections.Generic;
using SpiceGardenWebForms.DAL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.BLL
{
    public class CategoryBLL
    {
        private readonly CategoryDAL categoryDal;
        public CategoryBLL() { categoryDal = new CategoryDAL(); }
        public List<Category> GetCategories(string search = null) { return categoryDal.GetCategories(search); }
        public int AddCategory(Category category) { if (string.IsNullOrWhiteSpace(category.CategoryName)) throw new ArgumentException("Category name is required."); return categoryDal.Insert(category); }
        public void UpdateCategory(Category category) { if (string.IsNullOrWhiteSpace(category.CategoryName)) throw new ArgumentException("Category name is required."); categoryDal.Update(category); }
        public void DeleteCategory(int categoryId) { categoryDal.Delete(categoryId); }
        public int GetCategoryCount() { return categoryDal.GetCategoryCount(); }
    }
}
