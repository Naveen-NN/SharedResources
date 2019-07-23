using GraphQL;
using GraphQL.Types;
using GraphQLBookApi.GraphQL.Types;
using GraphQLBookApi.Repository;


namespace GraphQLBookApi.GraphQL.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(BookRepository bookRepository, AuthorRepository authorRepository)
        {
            Field<ListGraphType<BookType>>("books",  resolve: context =>
            {
                return bookRepository.GetAll();
            });

            Field<BookType>("book"
                , arguments: GetArguments()
                , resolve: context =>
            {
                return bookRepository.GetById(context.GetArgument<int>("id"));
            });

            Field<ListGraphType<AuthorType>>("authors", resolve: context =>
            {
                return authorRepository.GetAll();
            });

            Field<AuthorType>("author"
                , arguments: GetArguments()
                , resolve: context =>
                {
                context.Errors.Add(new ExecutionError("There was an error while processing request..."));
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
