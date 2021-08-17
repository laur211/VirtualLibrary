using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualLibrary.Models;

namespace VirtualLibrary.ViewModel
{
    public class Book
    {
        public IEnumerable<Book> books { get; set; }
    }
}