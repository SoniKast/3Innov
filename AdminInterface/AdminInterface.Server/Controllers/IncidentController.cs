using AdminInterface.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminInterface.Server.Controllers
{
    [Route("api/incidents")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IncidentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents()
        {
            return await _context.Incident.Include(i => i.Equipement).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(int id)
        {
            var incident = await _context.Incident.Include(i => i.Equipement).FirstOrDefaultAsync(i => i.ID_Incident == id);
            if (incident == null)
                return NotFound();
            return incident;
        }
    }

}
