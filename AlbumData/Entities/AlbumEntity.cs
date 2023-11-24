using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlbumData.Entities;

[Table("albums")]
public class AlbumEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [MaxLength(50)]
    [Required]
    public string Band { get; set; }

    public ICollection<SongEntity> Songs { get; set; }

    [Required]
    public int ChartRanking { get; set; }

    [Required]
    [Column("birth_date")]
    public DateTime ReleaseDate { get; set; }

    [MaxLength(5)]
    [Required]
    public string Duration { get; set; }
}