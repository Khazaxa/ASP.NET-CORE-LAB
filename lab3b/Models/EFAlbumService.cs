using Data;
using Data.Entities;

namespace lab3a.Models
{
    public class EFAlbumService : IContactService
    {
        public readonly AppDbContext __ctx;

        public EFAlbumService(AppDbContext ctx)
        {
            __ctx = ctx;
        }

        public int Add(Contact contact)
        {
            var e = __ctx.Contacts.Add(AlbumMapper.ToEntity(contact));
            __ctx.SaveChanges();
            int id = e.Entity.Id;
            return id;
        }

        public void Delete(int id)
        {
            ContactEntity? find = __ctx.Contacts.Find(id);
            if (find != null)
            {
                __ctx.Contacts.Remove(find);
                __ctx.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return __ctx.Contacts.Select(e => AlbumMapper.FromEntity(e)).ToList();
        }

        public Contact? FindById(int id)
        {
            ContactEntity? find = __ctx.Contacts.Find(id);
            return find != null ? AlbumMapper.FromEntity(find) : null;
        }

        public void Update(Contact contact)
        {
            __ctx.Contacts.Update(AlbumMapper.ToEntity(contact));
            __ctx.SaveChanges();
        }
    }
}
