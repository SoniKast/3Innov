using AdminInterface.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;

namespace AdminInterface.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetUtilisateurs()
        {var utilisateurs = await _context.Utilisateur
                .Include(u => u.Tickets) // Include tickets for the user
                .Select(u => new
                {
                    u.ID_Utilisateur,
                    u.Nom,
                    u.Prenom,
                    u.Email,
                    u.Type,
                    Tickets = u.Tickets.Select(t => new
                    {
                        t.ID_Ticket,
                        t.Nom_Ticket,
                        t.Description_Ticket,
                        t.Etat_Ticket
                    }).ToList()
                })
                .ToListAsync();

            return utilisateurs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateur
                .Where(u => u.ID_Utilisateur == id)
                .Include(u => u.Tickets)
                .Select(u => new
                {
                    u.ID_Utilisateur,
                    u.Nom,
                    u.Prenom,
                    u.Email,
                    u.Type,
                    Tickets = u.Tickets.Select(t => new
                    {
                        t.ID_Ticket,
                        t.Nom_Ticket,
                        t.Description_Ticket,
                        t.Etat_Ticket
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (utilisateur == null)
                return NotFound();

            return utilisateur;
        }


        [HttpPost("create")]
        public IActionResult CreateUtilisateur([FromBody] Utilisateur utilisateur)
        {
            _context.Utilisateur.Add(utilisateur);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.ID_Utilisateur }, utilisateur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.ID_Utilisateur) return BadRequest();
            _context.Entry(utilisateur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null) return NotFound();
            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
