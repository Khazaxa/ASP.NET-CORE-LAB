namespace lab3a.Models
{
    public interface IDateTimeProvider
    { 
        DateTime date();
       
    }
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime date()
        {
            return DateTime.Now;
        }
    }
}
