using DemoGraphQL.Adapters;
using DemoGraphQL.Core;
using DemoGraphQL.GraphQL;
using DemoGraphQL.GraphQL.Filters;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, InMemoryAuthorService>();
            services.AddSingleton<IBookService, InMemoryBookService>();

            services.AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddType<AuthorType>()
                .AddType<BookType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .Create());

            services.AddErrorFilter<BookNotFoundExceptionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UsePlayground();
            }

            app.UseGraphQL("/api");
        }
    }
}
