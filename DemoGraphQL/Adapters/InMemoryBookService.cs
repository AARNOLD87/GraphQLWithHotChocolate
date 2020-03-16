using DemoGraphQL.Core;
using DemoGraphQL.Core.CustomException;
using DemoGraphQL.GraphQL;
using System.Collections.Generic;
using System.Linq;

namespace DemoGraphQL.Adapters
{
    public class InMemoryBookService : IBookService
    {
        private IList<Book> _books;

        public InMemoryBookService()
        {
            _books = new List<Book>()
            {
                new Book() { Id = 1, Title = "First Book", Price = 10, AuthorId = 1},
                new Book() { Id = 2, Title = "Second Book", Price = 11, AuthorId = 2},
                new Book() { Id = 3, Title = "Third Book", Price = 12, AuthorId = 3},
                new Book() { Id = 4, Title = "Fourth Book", Price = 15, AuthorId = 1},
            };
        }

        public Book Create(CreateBookInput inputBook)
        {
            var newBook = new Book()
            {
                Id = _books.Max(x => x.Id) + 1,
                Title = inputBook.Title,
                Price = inputBook.Price,
                AuthorId = inputBook.AuthorId,
            };

            _books.Add(newBook);

            return newBook;
        }

        public Book Delete(DeleteBookInput inputBook)
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Id == inputBook.Id);
            if(bookToDelete == null)
                throw new BookNotFoundException() { BookId = inputBook.Id };
            _books.Remove(bookToDelete);
            return bookToDelete;
        }

        public IQueryable<Book> GetAll()
        {
            return _books.AsQueryable();
        }
    }
}
