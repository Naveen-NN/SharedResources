using GraphQL.Types;
using GraphQLBookApi.DAO;
using GraphQLBookApi.GraphQL.Types;
using GraphQLBookApi.Repository;
using System.Collections.Generic;

namespace GraphQLBookApi.GraphQL.Mutations
{
    public class BooksMutation : ObjectGraphType
    {
        public BooksMutation(BookRepository bookRepository)
        {
            Name = "mutation";
            ///<summary>
            /*
             * mutation{
                createBook(book:{bookname: "book 6", price: 22, authorid: 1}){
                        id
                        name
                    }
                }
             */
            ///</summary>
            Field<BookType>("createBook"
                , arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" })
                , resolve: context =>
                {
                    var book = context.GetArgument<Book>("book");
                    return bookRepository.AddBook(book);
                });

            Field<BookType>("deleteBook"
               , arguments: new QueryArguments(new List<QueryArgument>
               {
                   new QueryArgument<IdGraphType>{ Name = "id"}
               })
               , resolve: context =>
               {
                   var id = context.GetArgument<int>("id");
                   return bookRepository.DeleteBook(id);
               });
        }
    }
}
