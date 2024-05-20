using BusinessObject.Models;
using Repositories.CategoryRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService()
        {
            if (_categoryRepo == null)
            {
                _categoryRepo = new CategoryRepo();
            }
        }
        public List<Category> GetCategories()
        {
            return _categoryRepo.GetCategories();
        }

        public void AddCategory(Category category)
        {
            _categoryRepo.AddCategory(category);
        }
        public void DeleteCategory(Category category)
        {
            _categoryRepo.DeleteCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            _categoryRepo.UpdateCategory(category);
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepo.GetCategoryById(id);
        }
    }
}
