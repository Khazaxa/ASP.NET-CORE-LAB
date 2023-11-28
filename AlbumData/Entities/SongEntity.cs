using AlbumData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumData.Entities
{
    [Table("Song List")]
    public class SongEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        [ForeignKey("AlbumEntity")]

        public int TrackNumber { get; set; }
        public int AlbumId { get; set; }

        // Relacja z AlbumEntity
        public virtual AlbumEntity Album { get; set; }
    }
}
