﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.viewModels
{
    public class MovieGenreVM
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieGenreVM()
        {
            Id = 0;
        }

        public MovieGenreVM(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}