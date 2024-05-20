using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        public void AddCategory(Category category) => CategoryDAO.AddCategory(category);
        public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);
        public void UpdateCategory(Category category) => CategoryDAO.UpdateCategory(category);
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
        public Category GetCategoryById(int id) => CategoryDAO.GetCategoryById(id);
    }
}
