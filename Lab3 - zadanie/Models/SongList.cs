using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3zadanie.Models
{
    public class SongList
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Duration { get; set; }
        public object AlbumId { get; internal set; }
    }
}
