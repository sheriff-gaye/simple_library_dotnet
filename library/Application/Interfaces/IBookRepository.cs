

using Library.Domain.Entities;


namespace Library.Application.Interfaces
{


    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delet(int id);

        List<Book> GetAvailableBooks();

    }

}