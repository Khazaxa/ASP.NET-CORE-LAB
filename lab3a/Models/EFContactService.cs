using Data;
using Data.Entities;

namespace lab3a.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;
        private object __ctx;

        public EFContactService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public int Add(Contact contact)
        {
            contact.OrganizationId = FindOrganizationIdByName(contact.OrganizationName) ?? 0;
            if (contact.OrganizationId == 0)
            {
                throw new InvalidOperationException("Valid OrganizationId is required");
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
            contact.OrganizationId = FindOrganizationIdByName(contact.OrganizationName) ?? 0;
            if (contact.OrganizationId == 0)
            {
                throw new InvalidOperationException("Valid OrganizationId is required");
            }

            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Update(entity);
            _context.SaveChanges();
        }
        public int? FindOrganizationIdByName(string name)
        {
            var organization = _context.Organizations.FirstOrDefault(o => o.Name == name);
            return organization?.Id;
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            __ctx.Contacts
                .OrderBy(o => o.Name)
                .Skip((page-1)*size)
                .Take(size)
                .Select(ContactMapper.FromEntity)
                .ToList();
        }
    }
}
