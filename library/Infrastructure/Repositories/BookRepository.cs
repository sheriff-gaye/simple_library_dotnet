
using Library.Domain.Entities;
using Library.Application.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", ISBN = "978-0132350884", CategoryId = 1, IsAvailable = true, PublishedDate = new DateTime(2008, 8, 1) },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", ISBN = "978-0201616224", CategoryId = 1, IsAvailable = true, PublishedDate = new DateTime(1999, 10, 20) },
            new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "978-0061120084", CategoryId = 2, IsAvailable = true, PublishedDate = new DateTime(1960, 7, 11) }
        };
        private static int _nextId = 4;

        public List<Book> GetAllBooks()
        {
            return _books;

        }
        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }
        public void Update(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.CategoryId = book.CategoryId;
                existingBook.IsAvailable = book.IsAvailable;
                existingBook.PublishedDate = book.PublishedDate;
            }
        }

        public void Delet(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public List<Book> GetAvailableBooks()
        {
            return _books.Where(b => b.IsAvailable).ToList();
        }



    }
}