using GraphQL.Types;
using GraphQLBookApi.DAO;
using GraphQLBookApi.Repository;

namespace GraphQLBookApi.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(AuthorRepository authorRepository)
        {
            Field(f => f.Id).Name("id");
            Field(f => f.BookName).Name("name");
            Field(f => f.Price).Name("price");
            Field<AuthorType>("author", resolve: context =>
            {
                return authorRepository.GetById(context.Source.AuthorId);
            });
        }

    }
}
