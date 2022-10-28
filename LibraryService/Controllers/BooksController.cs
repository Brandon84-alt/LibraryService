using LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using LibraryServices.Data.Models;
using LibraryServices.Data.Interfaces;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryService.Controllers
{
    [EnableCors(origins:"*",headers:"*", methods:"*")]
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

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id) {
            if(books.Remove(id)) {
                return Ok(books.GetAllBooks());
            }
            return NotFound();
        }
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            var ubook = books.UpdateBook(id, book);
            if (ubook != null)
            {
                return Ok(ubook);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/books/author/{id}")]
        [Route("api/books/{id}/author")]
        public IHttpActionResult GetAuthorById(int id) 
        {
            var authorName = books.GetAuthorById(id);
            if (authorName == null)
            {
                return NotFound();

            }
            return Ok(authorName);
                
        }
    }
}
