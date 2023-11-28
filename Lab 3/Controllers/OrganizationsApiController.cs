using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_3.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationsApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrganizationsByName(string? q)
        {
            return Ok(
                    q is null ?
                    _context.Organizations.ToList() 
                    :
                    _context.Organizations
                    .Where(x => x.Name.ToUpper().StartsWith(q.ToUpper()))
                    .Select(c => new {Name = c.Name, Id = c.Id})
                    .ToList()
                ); 
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id) 
        {
            var entity = _context.Organizations.Find(id);
            if (entity is null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
