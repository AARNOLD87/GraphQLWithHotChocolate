namespace DemoGraphQL.GraphQL
{
    public class CreateBookInput
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}