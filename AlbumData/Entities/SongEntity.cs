using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumData.Entities;

public class SongEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    // Klucz obcy do AlbumEntity
    public int AlbumEntityId { get; set; }

    [ForeignKey("AlbumEntityId")]
    public AlbumEntity Album { get; set; }
}