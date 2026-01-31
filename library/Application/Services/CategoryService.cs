

using Library.Application.Interfaces;
using Library.Domain.Entities;
namespace Library.Application.Services
{
    public class CategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }
        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

    }

}