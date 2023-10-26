using LearningBlazorCRUD.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazorCRUD.Services
{
    public class BookService : IBookService
    {

        private readonly BookContext _bookContext;
        private const int ZeroAsValue = 0;

        public BookService(BookContext bookContext) => _bookContext = bookContext;

        public async Task<bool> AddBook(Book book)
        {
            _bookContext.Books.Add(book);

            return await _bookContext.SaveChangesAsync() > ZeroAsValue;
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            var book = _bookContext.Books.FindAsync(bookId);
            _bookContext.Remove(book);

            return await _bookContext.SaveChangesAsync() > ZeroAsValue;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookContext.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int bookId)
        {
            var book = await _bookContext.Books.FindAsync(bookId);

            if(book != null)
            {
                return book;
            }

            return new Book();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            _bookContext.Entry(book).State = EntityState.Modified;

            return await _bookContext.SaveChangesAsync() > ZeroAsValue;
        }

        public async Task<bool> SaveBook(Book book)
        {
            if(book.BookId > ZeroAsValue)
            {
                return await UpdateBook(book);
            }

            return await AddBook(book);
        }
    }

    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(int bookId);
        Task<bool> AddBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int bookId);
        Task<bool> SaveBook(Book book);
    }
}
