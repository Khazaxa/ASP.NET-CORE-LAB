using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab3zadanie.Models
{
    public class Album
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Artist/Band")]
        public string Artist { get; set; }

        public string ChartPosition { get; set; }

        [Range(1900, 2023)]
        [Display(Name = "Release Year")]
        public int? ReleaseYear { get; set; }

        public int Duration { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        public ICollection<SongList> SongList { get; set; }



    }
}
