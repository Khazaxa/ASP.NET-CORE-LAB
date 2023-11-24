using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3b.Models;

public class Album
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Proszę podać nazwę albumu!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Proszę podać nazwę zespołu!")]
    public string Band { get; set; }
    
    public Dictionary<int, string> SongList { get; set; } = new Dictionary<int, string>();

    [Required(ErrorMessage = "Proszę podać datę wydania albumu!")]
    public int ChartRanking { get; set; }

    [Required(ErrorMessage = "Proszę podać numer w notowaniu!")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Proszę podać czas trwania albumu!")]
    [RegularExpression(@"^\d{1,2}:\d{2}$", ErrorMessage = "Czas trwania musi być w formacie HH:MM.")]
    public string Duration { get; set; }
 
}