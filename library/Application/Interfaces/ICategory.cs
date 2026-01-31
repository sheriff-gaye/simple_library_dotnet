using Library.Domain.Entities;
namespace Library.Application.Interfaces
{

    public interface ICategoryRepository
    {

        List<Category> GetAll();
        Category GetCategoryById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);

    }
}