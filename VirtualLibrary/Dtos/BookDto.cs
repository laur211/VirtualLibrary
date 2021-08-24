using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VirtualLibrary.Models;

namespace VirtualLibrary.Dtos
{
    public class BookDto
    {
        public int id { get; set; }


        public String title { get; set; }

        public String resume { get; set; }

        public String content { get; set; }

        public int feedbackNote { get; set; }

        public string feedback { get; set; }

        public List<Author> authors { get; set; }
    }
}