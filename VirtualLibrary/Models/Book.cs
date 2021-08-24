using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualLibrary.Models
{
    public class Book
    {
        public int id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string title { get; set; }

        public string resume { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public int feedbackNote { get; set; }

        public string feedback { get; set; }
    }
}