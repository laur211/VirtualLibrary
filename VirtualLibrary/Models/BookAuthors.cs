using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VirtualLibrary.Models
{
    public class BookAuthors
    {
        [Key]
        [Column(Order=1)]
        public int bookId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int authorId { get; set; }


        public virtual Book book { get; set; }
        public virtual Author author { get; set; }
    }
}