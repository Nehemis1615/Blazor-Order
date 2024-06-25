using System.Collections.Generic;
using System.Linq;
using order.Models;

namespace order.Mock
{
    public interface ICategoryService
    {
        void AddCategory(CategoryModel category);
        List<CategoryModel> GetCategories();
        CategoryModel? GetCategoryById(int id);
    }

    public class CategoryService : ICategoryService
    {
        private List<CategoryModel> _categories;

        public CategoryService()
        {
            _categories = new List<CategoryModel>
            {
                new() { CategoryID = 1, CategoryName = "主餐" },
                new() { CategoryID = 2, CategoryName = "點心" },
                new() { CategoryID = 3, CategoryName = "飲料" },
                new() { CategoryID = 4, CategoryName = "湯品" },
            };
        }

        public void AddCategory(CategoryModel category)
        {
            category.CategoryID = _categories.Count + 1;
            _categories.Add(category);
        }

        public List<CategoryModel> GetCategories()
        {
            return _categories;
        }

        public CategoryModel? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(o => o.CategoryID == id);
        }
    }
}
