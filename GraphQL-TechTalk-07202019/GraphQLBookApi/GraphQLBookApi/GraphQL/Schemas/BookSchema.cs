

using GraphQL;
using GraphQL.Types;
using GraphQLBookApi.GraphQL.Mutations;
using GraphQLBookApi.GraphQL.Queries;

namespace GraphQLBookApi.GraphQL.Schemas
{
    public class BookSchema : Schema
    {
        public BookSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BookQuery>();
            Mutation = resolver.Resolve<BooksMutation>();
        }
    }
}
