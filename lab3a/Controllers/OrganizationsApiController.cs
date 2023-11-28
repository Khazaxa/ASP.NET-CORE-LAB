using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3a.Controllers
{
    [Route("api/organizations]")]
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
                q is null ? _context.Organizations.ToList() :
                _context.Organizations
                .Where(o => o.Name.ToUpper().StartsWith(q.ToUpper()))
                .ToList()
            );
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOrganizationById(int id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization is null)
            {
                return NotFound();
            }
            return Ok(organization);
        }   
    }
}
