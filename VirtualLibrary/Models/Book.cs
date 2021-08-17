using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualLibrary.Models
{
    public class Book
    {
        public Book()
        {
            this.authors = new List<Author>();
        }
        public int id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public String title { get; set; }

        public String resume { get; set; }

        [Required]
        public String content { get; set; }

        [Required]
        public int feedbackNote { get; set; }

        public String feedback { get; set; }

        public ICollection<Author> authors { get; set; }


    }
}