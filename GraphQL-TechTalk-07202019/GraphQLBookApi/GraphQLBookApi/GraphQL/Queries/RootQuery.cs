using GraphQL.Types;

namespace GraphQLBookApi.GraphQL.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            FieldSubscribe<BookQuery>("bookQuery");
        }
    }
}
