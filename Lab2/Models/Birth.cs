using System;

namespace Lab2.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Date < DateTime.Now;
        }

        public int BirthCalc()
        {
            return DateTime.Now.Year - Date.Year;
        }
    }
}
