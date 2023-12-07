using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3zadanie.Models
{
    public class Song
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Duration { get; set; }

        public int AlbumId { get; set; }
    }
}
