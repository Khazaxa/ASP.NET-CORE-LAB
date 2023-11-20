namespace lab3a.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime date()
        {
            return DateTime.Now;
        }
    }
}
