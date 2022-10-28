using LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using LibraryServices.Data.Models;
using LibraryServices.Data.Interfaces;
using System.Web.Http;

namespace LibraryService.Controllers
{
    public class BooksController : ApiController
    {
        private IBookRepository books;
        public BooksController(IBookRepository _book) {
            this.books = _book;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult PostBook(Book book) {
            bool result = books.AddNewBook(book);
            if (result)
            { 
                return Ok(book);
            }
            return BadRequest();
        }
    }
}
