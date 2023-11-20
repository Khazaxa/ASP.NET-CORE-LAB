using Data;
using Data.Entities;

namespace lab3a.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;
        public EFContactService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public int Add(Contact contact)
        {
            if (contact.OrganizationId == 0) // Zakładając, że 0 nie jest prawidłowym ID
            {
                throw new InvalidOperationException("OrganizationId is required");
            }

            var entity = ContactMapper.ToEntity(contact);
            var e = _context.Contacts.Add(entity);
            _context.SaveChanges();
            return e.Entity.ContactId;
        }


        public void Delete(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.ToModel(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public Contact? FindById(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            return find != null ? ContactMapper.ToModel(find) : null;
        }

        public void Update(Contact contact)
        {
            if (contact.OrganizationId == 0)
            {
                throw new InvalidOperationException("OrganizationId is required");
            }

            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Update(entity);
            _context.SaveChanges();
        }

    }
}
