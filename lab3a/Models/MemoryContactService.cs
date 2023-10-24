namespace lab3a.Models
{
    public class MemoryContactService : IContactService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public MemoryContactService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();
        public int Add(Contact item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            item.Created = _dateTimeProvider.date();
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Contact item)
        {
            _items[item.Id] = item;
        }

    }
}
