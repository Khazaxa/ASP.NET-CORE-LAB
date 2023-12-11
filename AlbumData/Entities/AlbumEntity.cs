using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___zadanieContextConnection.Entities
{
    [Table("Albums")]
    public class AlbumEntity
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Band { get; set; }

        [Required]
        public string Genre { get; set; } 

        public virtual List<SongEntity> Songs { get; set; }

        public string? ChartPosition { get; set; }

        public int? ReleaseYear { get; set; }

        [Display(Name = "Duration in minutes")]
        public int? Duration { get; set; }
    }

}
