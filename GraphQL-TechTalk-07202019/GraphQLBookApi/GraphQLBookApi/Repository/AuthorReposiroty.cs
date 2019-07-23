using GraphQLBookApi.DAO;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLBookApi.Repository
{
    public class AuthorRepository
    {
        private static List<Author> _authors;

        public AuthorRepository()
        {
            InitAuhtors();
        }

        private void InitAuhtors()
        {
            _authors =  new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Author 1",
                },
                new Author
                {
                    Id = 2,
                     Name = "Author 2",
                },
                new Author
                {
                    Id = 3,
                    Name = "Author 3",
                }
            };
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors;
        }

        public Author GetById(int id)
        {
            return _authors.Where( b => b.Id == id).SingleOrDefault();
        }
    }
}
