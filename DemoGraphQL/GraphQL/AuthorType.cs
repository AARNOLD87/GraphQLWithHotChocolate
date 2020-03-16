using DemoGraphQL.Core;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;

namespace DemoGraphQL.GraphQL
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.Surname).Type<StringType>();
            descriptor.Field<BookResolver>(t => t.GetBooks(default, default));
        }
    }

    public class BookResolver
    {
        private readonly IBookService _bookService;

        public BookResolver([Service]IBookService bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<Book> GetBooks(Author author, IResolverContext ctx)
        {
            return _bookService.GetAll().Where(b => b.AuthorId == author.Id);
        }
    }
}