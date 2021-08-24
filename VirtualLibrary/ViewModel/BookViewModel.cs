using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualLibrary.Models;
using VirtualLibrary.Dtos;

namespace VirtualLibrary.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<BookDto> books { get; set; }
        public BookDto book { get; set; }
    }
}