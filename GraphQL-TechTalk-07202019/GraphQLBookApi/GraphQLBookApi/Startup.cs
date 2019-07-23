//#Step 1
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

//#Step 2
using GraphQLBookApi.GraphQL.Schemas;
using GraphQLBookApi.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLBookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //#Step 3: Configure repository services 
            services.AddSingleton<BookRepository>();
            services.AddSingleton<AuthorRepository>();

            //#Step 4: Configure graphql 
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<BookSchema>();
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true;
            })
           .AddGraphTypes(ServiceLifetime.Scoped)
           .AddUserContextBuilder(httpContext => httpContext.User)
           .AddDataLoader();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphQL<BookSchema>();
            //#Step 5
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
           /// app.UseMvc();
        }
    }
}
