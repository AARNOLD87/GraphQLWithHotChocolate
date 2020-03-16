using System.Linq;

namespace DemoGraphQL.Core
{
    public interface IAuthorService
    {
        IQueryable<Author> GetAll();
    }
}
