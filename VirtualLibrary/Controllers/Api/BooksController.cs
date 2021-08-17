using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VirtualLibrary.Models;

namespace VirtualLibrary.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetBooks()
        {
            var lista = new List<Author>();
            var books = _context.Books.ToList();
            return Ok(books);

        }

        [Route("api/books/{bookId}")]
        public IHttpActionResult GetBook(int bookId)
        {
            var book = _context.Books.SingleOrDefault(b => b.id == bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book.authors);
        }

        public IHttpActionResult AddBooks(Book[] books)
        {
            if (books.Length <= 0)
            {
                return BadRequest("No books to add");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            foreach(var book in books)
            {
                _context.Books.Add(book);
                
            }
            _context.SaveChanges();
            return Ok(books);

        }
    }
}
