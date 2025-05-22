using AdminInterface.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;

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


        [HttpPost]
        public async Task<ActionResult<Utilisateur>> CreateUtilisateur(Utilisateur utilisateur)
        {
            // Clear tickets to avoid unnecessary nested validation
            utilisateur.Tickets = null;

            _context.Utilisateur.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.ID_Utilisateur }, utilisateur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, UpdateUtilisateurDTO dto)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null) return NotFound();

            utilisateur.Nom = dto.Nom;
            utilisateur.Prenom = dto.Prenom;
            utilisateur.Email = dto.Email;
            utilisateur.Type = dto.Type;
            utilisateur.Mot_de_pass = BCrypt.Net.BCrypt.HashPassword(dto.Mot_de_pass);

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
