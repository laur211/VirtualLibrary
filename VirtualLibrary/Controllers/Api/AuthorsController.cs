using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VirtualLibrary.Models;

namespace VirtualLibrary.Controllers.Api
{
    public class AuthorsController : ApiController
    {
        private ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetAuthors()
        {
            var authors = _context.Authors.ToList();
            return Ok(authors);
        }



    }
}
