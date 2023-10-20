using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3b.Models
{
    public class Album
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane.")]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Pole 'Zespół' jest wymagane.")]
        [Display(Name = "Zespół")]
        public string Zespol { get; set; }

        [Required(ErrorMessage = "Pole 'Spis piosenek' jest wymagane.")]
        [Display(Name = "Spis piosenek")]
        public string SpisPiosenek { get; set; }

        [Required(ErrorMessage = "Pole 'Notowanie' jest wymagane.")]
        [Display(Name = "Notowanie")]
        public int Notowanie { get; set; }

        [Required(ErrorMessage = "Pole 'Data wydania' jest wymagane.")]
        [Display(Name = "Data Wydania")]
        public DateTime DataWydania { get; set; }

        [Required(ErrorMessage = "Pole 'Czas trwania' jest wymagane.")]
        [Display(Name = "Czas Trwania (w sekundach)")]
        public int CzasTrwania { get; set; }

    }
}
