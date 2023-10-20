using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3b.Models
{
    public class Album
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę albumu.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę zespołu.")]
        public string Band { get; set; }

        [Required(ErrorMessage = "Proszę podać spis piosenek.")]
        public string Tracklist { get; set; }

        [Required(ErrorMessage = "Proszę podać notowanie.")]
        public string ChartPosition { get; set; }

        [Required(ErrorMessage = "Proszę podać datę wydania.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Proszę podać czas trwania.")]
        public string Duration { get; set; }

    }
}
