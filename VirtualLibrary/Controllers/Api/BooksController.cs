using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VirtualLibrary.Models;
using System.Data.Entity;
using AutoMapper;
using VirtualLibrary.Dtos;


namespace VirtualLibrary.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();

        }


        [Route("api/books")]
        public IHttpActionResult GetBooks()
        {
            var booksDto = _context.Books.Select(Mapper.Map<Book, BookDto>).ToList();
            var bookAuthors = _context.BookAuthors.Include(a => a.author).Include(b => b.book).ToList();
            foreach (var bookDto in booksDto)
            {
                bookDto.authors = bookAuthors.Where(b => b.bookId == bookDto.id).Select(a => a.author).ToList();
            }
            return Ok(booksDto);
        }


        [Route("api/books/{bookId}")]
        public IHttpActionResult GetBook(int bookId)
        {
            var book = _context.Books.SingleOrDefault(b => b.id == bookId);
            if (book == null)
            {
                return NotFound();
            }

            var bookDto = Mapper.Map<Book, BookDto>(book);
            var bookAuthor = _context.BookAuthors.Where(b => b.bookId == bookId).ToList();
            bookDto.authors = bookAuthor.Select(a => a.author).ToList();
            return Ok(bookDto);
        }




        [HttpPost]
        [Route("api/books")]
        public IHttpActionResult AddBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            var book = Mapper.Map<BookDto, Book>(bookDto);
            foreach(var author in bookDto.authors)
            {
                var bookAuthor = new BookAuthors {authorId = author.id, bookId = book.id };
                _context.BookAuthors.Add(bookAuthor);
            }
            book.feedbackNote = 0;
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);
            
        }

        [HttpPut]
        [Route("api/books/{bookId}")]
        public IHttpActionResult UpdateBook(int bookId, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var currentBook = _context.Books.SingleOrDefault(b => b.id == bookId);
            if (currentBook == null)
            {
                return NotFound();
            }

            var bookAuthors = _context.BookAuthors.Where(ba => ba.bookId == bookId);

            foreach(var bookAuthor in bookAuthors)
            {
                _context.BookAuthors.Remove(bookAuthor);
            }
            foreach (var author in bookDto.authors)
            {
                var bookAuthor = new BookAuthors { bookId = bookId, authorId = author.id };
                _context.BookAuthors.Add(bookAuthor);
            }

            bookDto.id = currentBook.id;
            Mapper.Map<BookDto, Book>(bookDto);
            _context.SaveChanges();
            return Ok(bookDto);
            
        }

        [HttpPatch]
        [Route("api/books/{bookId}")]
        public IHttpActionResult PatchBook(int bookId, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var currentBook = _context.Books.SingleOrDefault(b => b.id == bookId);
            if (currentBook == null)
            {
                return NotFound();
            }

            var bookAuthors = _context.BookAuthors.Where(ba => ba.bookId == bookId).ToList();
            var bookAuthorIds = bookAuthors.Select(aid => aid.authorId);
            var bookDtoAuthorIds = bookDto.authors.Select(aid => aid.id).ToList();

            if (!bookDtoAuthorIds.Intersect(bookAuthorIds).Any())
            {
                foreach (var bookAuthor in bookAuthors)
                {
                    _context.BookAuthors.Remove(bookAuthor);
                }
                foreach (var author in bookDto.authors)
                {
                    var bookAuthor = new BookAuthors { bookId = bookId, authorId = author.id };
                    _context.BookAuthors.Add(bookAuthor);
                }
            }
            if(bookDto.title != null)
            {
                currentBook.title = bookDto.title;
            }
            if(bookDto.resume != null)
            {
                currentBook.resume = bookDto.resume;
            }
            if(bookDto.content != null)
            {
                currentBook.content = bookDto.content;
            }
            if(bookDto.feedbackNote != 0 || bookDto.feedbackNote != currentBook.feedbackNote)
            {
                currentBook.feedbackNote = bookDto.feedbackNote;
            }
            if(bookDto.feedback != null)
            {
                currentBook.feedback = bookDto.feedback;
            }
            bookDto.id = currentBook.id;
            _context.SaveChanges();
            return Ok(bookDto);
        }

        [HttpDelete]
        [Route("api/books/{bookId}")]
        public IHttpActionResult DeleteBook(int bookId)
        {
            var book = _context.Books.SingleOrDefault(b => b.id == bookId);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            var bookAuthorsTbDeleted = _context.BookAuthors.Where(b => b.bookId == bookId).ToList();
            foreach(var bookAuthor in bookAuthorsTbDeleted)
            {
                _context.BookAuthors.Remove(bookAuthor);
            }
            _context.SaveChanges();
            return Ok();
            
        }

    }
}
