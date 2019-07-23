using GraphQL.Types;

namespace GraphQLBookApi.GraphQL.Types
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "BookInput";
            Field<NonNullGraphType<StringGraphType>>("bookname");
            Field<DecimalGraphType>("price");  
            Field<NonNullGraphType<IntGraphType>>("authorid");
        }
    }
}
