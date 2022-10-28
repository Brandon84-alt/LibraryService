using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Data.Repositories
{
    public class BookDatabase : IBookRepository
    {
        private LibraryContext db = new LibraryContext();

        public bool AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> GetAllBooks()
        {
           return db.Books.ToList();
        }

        public string GetAuthorById(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id).Author;
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBookByAuthor(string name)
        {
            return db.Books.Where(x => x.Author.Contains(name)).ToList();
        }

        public Book GetBookByAuthorAndYear(string author, int year)
        {
            return db.Books.FirstOrDefault(x=> x.PublicationYear == year && x.Author.Contains(author));
        }

        public bool Remove(int id)
        {
            var book = GetBook(id);
            if (book == null) 
            {
                return false;
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            if (this.Remove(id)) { 
                this.AddNewBook(book);
                db.SaveChanges();
                return db.Books.ToList();
            }
            return db.Books.ToList();
        }
    }
}
