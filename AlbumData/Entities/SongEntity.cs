using Lab3___zadanieContextConnection.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3___zadanieContextConnection.Entities
{
    [Table("Songs")]
    public class SongEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)] 
        public string Title { get; set; }

        public int Duration { get; set; }

        public int TrackNumber { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public virtual AlbumEntity Album { get; set; }
    }
}
