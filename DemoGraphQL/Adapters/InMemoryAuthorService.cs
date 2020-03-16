using DemoGraphQL.Core;
using System.Collections.Generic;
using System.Linq;

namespace DemoGraphQL.Adapters
{
    public class InMemoryAuthorService : IAuthorService
    {
        private IList<Author> _authors;

        public InMemoryAuthorService()
        {
            _authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Fabio", Surname = "Rossi"},
                new Author() { Id = 2, Name = "Paolo", Surname = "Verdi"},
                new Author() { Id = 3, Name = "Carlo", Surname = "Bianchi"}
            };
        }

        public IQueryable<Author> GetAll()
        {
            return _authors.AsQueryable();
        }
    }
}
