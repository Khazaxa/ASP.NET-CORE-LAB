using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Birth
    {
        [Required(ErrorMessage = "Pole 'Name' jest wymagane.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Pole 'Name' powinno mieć od 2 do 50 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole 'Date' jest wymagane.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Data urodzenia powinna być między 1900-01-01 a 2100-12-31.")]
        public DateTime Date { get; set; }

        public int BirthCalc()
        {
            return DateTime.Now.Year - Date.Year;
        }
    }

}
