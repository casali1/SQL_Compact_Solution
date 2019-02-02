﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_Compact_Solution.Models
{
    public class FilmGenere
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }
    }
}