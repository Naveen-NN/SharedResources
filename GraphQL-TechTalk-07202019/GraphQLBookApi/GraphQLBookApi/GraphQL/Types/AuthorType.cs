using GraphQL.Types;
using GraphQLBookApi.DAO;

namespace GraphQLBookApi.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(f => f.Id).Name("id");
            Field(f => f.Name).Name("name");
        }

    }
}
