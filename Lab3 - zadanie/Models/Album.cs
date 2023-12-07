using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lab3zadanie.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        [HiddenInput]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Band")]
        public string Band { get; set; }

        public string? ChartPosition { get; set; }

        [Display(Name = "Release Year")]
        public int? ReleaseYear { get; set; }

        public int? Duration { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
