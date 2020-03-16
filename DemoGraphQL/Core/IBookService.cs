using System.Linq;
using DemoGraphQL.GraphQL;

namespace DemoGraphQL.Core
{
    public interface IBookService
    {
        IQueryable<Book> GetAll();
        Book Create(CreateBookInput inputBook);
        Book Delete(DeleteBookInput inputBook);
    }
}
