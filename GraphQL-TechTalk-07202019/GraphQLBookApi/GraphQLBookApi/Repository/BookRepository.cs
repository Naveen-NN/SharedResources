using GraphQLBookApi.DAO;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLBookApi.Repository
{
    public class BookRepository
    {
        private static List<Book> _books;

        public BookRepository()
        {
            InitBooks();
        }
    
        private void InitBooks()
        {
            _books =  new List<Book>
            {
                new Book
                {
                    Id = 1,
                    BookName = "Book 1",
                    Price = 22, 
                    AuthorId = 2
                },
                new Book
                {
                    Id = 2,
                    BookName = "Book 2",
                    Price = 23,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    BookName = "Book 3",
                    Price = 23,
                    AuthorId = 2
                }
            };
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.Where( b => b.Id == id).SingleOrDefault();
        }

        public Book AddBook(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return book;
        }

        public Book DeleteBook(int id)
        {
            var book = _books.Where(b => b.Id == id).SingleOrDefault();
            if( book != null)
            {
                _books.Remove(book);
            }
            return book;
        }
    }
}
