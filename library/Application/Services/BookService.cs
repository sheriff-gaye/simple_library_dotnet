

using Library.Domain.Entities;
using Library.Application.Interfaces;

namespace Library.Application.Services
{

    public class BookService
    {

        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delet(id);
        }

        public List<Book> GetAvailableBooks()
        {
            return _bookRepository.GetAvailableBooks();
        }
    }

}