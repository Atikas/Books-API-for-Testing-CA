using BooksApi.DTOs;
using BooksApi.Models;
using BooksApi.Services.Repositories;

namespace BooksApi.Services
{
    public interface IBookService
    {
        ResponseDto AddBook(Book book);
        Book GetBook(string title);
        void RemoveBook(Guid id);
    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IISBNValidator _isbnValidator;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public ResponseDto AddBook(Book book)
        {
            var existingBook = _repository.GetBook(book.Title);
            if (existingBook is not null)
                return new ResponseDto(false, "Book already exist");

            if (book.Authors.Count < 1)
                return new ResponseDto(false, "Authors should be at least 1");

            if (book.Authors.Count > 5)
                return new ResponseDto(false, "Authors should not be more than 5");

            var isbnValidation = _isbnValidator.Validate(book.ISBN);

            if (!isbnValidation.IsValid)
                return new ResponseDto(false, isbnValidation.Message);

            var id = _repository.AddBook(book);
            return new ResponseDto(true, id.ToString());
        }

        public Book GetBook(string title)
        {
            return _repository.GetBook(title);
        }

        public void RemoveBook(Guid id)
        {
            _repository.RemoveBook(id);
        }
    }
}
