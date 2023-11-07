using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("contacts")]
    public class AlbumEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nazwa { get; set; }
        [MaxLength(50)]
        [Required]
        public string Zespol { get; set; }
        public string? SpisPiosenek { get; set; }
        public int Notowanie { get; set; }
        public DateTime DataWydania { get; set; }
        public int CzasTrwania { get; set; }
    }
}
