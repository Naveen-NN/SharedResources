using GraphQL.Types;
using GraphQLBookApi.GraphQL.Types;
using GraphQLBookApi.Repository;

namespace GraphQLBookApi.GraphQL.Queries
{
    public class AuthroQuery : ObjectGraphType
    {
        public AuthroQuery(AuthorRepository authorRepository)
        {
            Field<ListGraphType<AuthorType>>("authors", resolve: context =>
            {
                return authorRepository.GetAll();
            });

            Field<AuthorType>("author"
                , arguments: GetArguments()
                , resolve: context =>
                {
                    return authorRepository.GetById(context.GetArgument<int>("id"));
                });
        }
        private QueryArguments GetArguments()
        {
            var arguments = new QueryArguments
            {
                new QueryArgument<IdGraphType>
                {
                    Name = "id"
                }
            };
            return arguments;
        }
    }
}
