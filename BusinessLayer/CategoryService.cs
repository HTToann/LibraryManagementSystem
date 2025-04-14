using DataLayer;
using DTOs;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class CategoryService
    {
        private CategoryRepository _repo;
        public CategoryService()
        {
            _repo = new CategoryRepository();
        }
        public List<CategoryDTO> GetAllCategories()
        {

            return _repo.GetAllCategories();
        }
        public bool InsertCategory(CategoryDTO category)
        {
            return _repo.InsertCategory(category);
        }
        public bool UpdateCategory(CategoryDTO category)
        {
            return _repo.UpdateCategory(category);
        }
        public bool DeleteCategory(int categoryId)
        {
            return _repo.DeleteCategory(categoryId);
        }
        public List<CategoryDTO> GetCategoryByName(string kw)
        {
            return _repo.SearchCategoryByName(kw);
        }
        public CategoryDTO GetCategoryById(int id)
        {
            return _repo.SearchCategoryById(id);
        }
    }
}
