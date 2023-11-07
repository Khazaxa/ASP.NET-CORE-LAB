using Data.Entities;

namespace lab3a.Models
{
    public class AlbumMapper
    {
        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Birth = model.Birth,
                Priority = (int)model.Priority,
            };
        }
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Birth = entity.Birth,
                Priority = (Priority)entity.Priority,
            };
        }
    }
}
