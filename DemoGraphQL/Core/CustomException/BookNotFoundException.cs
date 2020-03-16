using System;

namespace DemoGraphQL.Core.CustomException
{
    public class BookNotFoundException : Exception
    {
        public int BookId { get; internal set; }
    }
}
