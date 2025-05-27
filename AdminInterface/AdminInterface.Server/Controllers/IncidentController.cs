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
        public async Task<ActionResult<IEnumerable<IncidentDTO>>> GetIncidents()
        {
            var incidents = await _context.Incident
                .Include(t => t.Equipement)
                .ToListAsync();

            // Map to incidentDTOs to flatten the structure
            var incidentDtos = incidents.Select(t => new IncidentDTO
            {
                ID_Incident = t.ID_Incident,
                ID_Equipement = t.ID_Equipement,
                Rapport_Incident = t.Rapport_Incident,
                EquipementType = t.Equipement.Type_equipement
            }).ToList();

            return incidentDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(int id)
        {
            var incident = await _context.Incident.Include(i => i.Equipement).FirstOrDefaultAsync(i => i.ID_Incident == id);
            if (incident == null)
                return NotFound();
            return incident;
        }

        [HttpPost]
        public async Task<ActionResult<Incident>> AddIncident(IncidentCreateDTO dto)
        {
            var incident = new Incident
            {
                ID_Equipement = dto.ID_Equipement,
                Rapport_Incident = dto.Rapport_Incident
            };

            _context.Incident.Add(incident);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncident), new { id = incident.ID_Incident }, incident);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncident(int id, IncidentUpdateDTO updatedIncident)
        {
            if (id != updatedIncident.ID_Incident)
                return BadRequest("L'identifiant ne correspond pas.");

            var existing = await _context.Incident.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.ID_Equipement = updatedIncident.ID_Equipement;
            existing.Rapport_Incident = updatedIncident.Rapport_Incident;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
