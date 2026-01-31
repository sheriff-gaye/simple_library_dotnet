
using Library.Application.Interfaces;
using Library.Domain.Entities;

public class CategoryRepository : ICategoryRepository
{
      private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Technology", Description = "Books about programming and technology" },
            new Category { Id = 2, Name = "Fiction", Description = "Fictional novels and stories" },
            new Category { Id = 3, Name = "Science", Description = "Scientific books and research" }
        };
        private static int _nextId = 4;

        public List<Category> GetAll()
        {
            return _categories;
        }
        public Category GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Category category)
        {
            category.Id = _nextId++;
            _categories.Add(category);
        }
        public void Update(Category category)
        {
            var existingCategory = GetCategoryById(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                
            }
        }
        public void Delete(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

    
}


