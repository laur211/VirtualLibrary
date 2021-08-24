﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualLibrary.Dtos
{
    public class AuthorDto
    {

        public int id { get; set; }

        [Required]
        public String firstName { get; set; }

        [Required]
        public String lastName { get; set; }

        [Required]
        public DateTime birthDate { get; set; }
        public DateTime? deathDate { get; set; }

    }
}