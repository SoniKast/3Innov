using AdminInterface.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminInterface.Server.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetTickets()
        {
            var tickets = await _context.Ticket
                .Include(t => t.Utilisateur)
                .Include(t => t.Incident)
                .ToListAsync();

            // Map to TicketDTO to flatten the structure
            var ticketDtos = tickets.Select(t => new TicketDTO
            {
                ID_Ticket = t.ID_Ticket,
                Nom_Ticket = t.Nom_Ticket,
                Description_Ticket = t.Description_Ticket,
                Etat_Ticket = t.Etat_Ticket,
				Type_de_tickets = t.Type_de_tickets,
                UtilisateurName = $"{t.Utilisateur.Prenom} {t.Utilisateur.Nom}", // Assuming you want to show the full name
                IncidentRapport = t.Incident?.Rapport_Incident // Handle the null case if Incident is null
            }).ToList();

            return ticketDtos;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Ticket
                .Include(t => t.Utilisateur)
                .Include(t => t.Incident)
                .FirstOrDefaultAsync(t => t.ID_Ticket == id);

            if (ticket == null)
                return NotFound();
            return ticket;
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.ID_Ticket }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.ID_Ticket)
                return BadRequest();

            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
                return NotFound();

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
