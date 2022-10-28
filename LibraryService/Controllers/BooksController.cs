using LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryServices.Data.Models;
using LibraryServices.Data.Interfaces;

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
    }
}
