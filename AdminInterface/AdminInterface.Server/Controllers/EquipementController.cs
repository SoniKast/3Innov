using AdminInterface.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminInterface.Server.Controllers
{
    [Route("api/equipements")]
    [ApiController]
    public class EquipementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EquipementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEquipements()
        {
            var equipements = await _context.Equipement
            .Include(e => e.Groupe)
            .Select(e => new
            {
                e.ID_Equipement,
                e.Type_equipement,
                e.Description_equipement,
                e.Marque,
                e.Modele,
                e.Commentaire,
                e.Adresse_IP,
                Groupe = e.Groupe != null ? new
                {
                    e.Groupe.ID_Groupe,
                    e.Groupe.Nom_GroupeM
                } : null
            })
            .ToListAsync();

            return Ok(equipements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipement>> GetEquipement(int id)
        {
            var equipement = await _context.Equipement
            .Include(e => e.Groupe)
            .Where(e => e.ID_Equipement == id)
            .Select(e => new
            {
                e.ID_Equipement,
                e.Type_equipement,
                e.Description_equipement,
                e.Marque,
                e.Modele,
                e.Commentaire,
                e.Adresse_IP,
                Groupe = e.Groupe != null ? new
                {
                    e.Groupe.ID_Groupe,
                    e.Groupe.Nom_GroupeM, 
                } : null
            })
            .FirstOrDefaultAsync();

            if (equipement == null)
                return NotFound();

            return Ok(equipement);
        }

        [HttpPost]
        public async Task<ActionResult<Equipement>> CreateEquipement(EquipementDTO dto)
        {
            var groupe = await _context.GroupeMonitoring.FindAsync(dto.Groupe);
            if (groupe == null)
                return BadRequest("Groupe invalide");

            var equipement = new Equipement
            {
                Type_equipement = dto.Type_equipement,
                Description_equipement = dto.Description_equipement,
                Marque = dto.Marque,
                Modele = dto.Modele,
                Commentaire = dto.Commentaire,
                Adresse_IP = dto.Adresse_IP,
                Groupe = groupe
            };

            _context.Equipement.Add(equipement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipement), new { id = equipement.ID_Equipement }, equipement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipement(int id, EquipementDTO dto)
        {
            var equipement = await _context.Equipement.Include(e => e.Groupe).FirstOrDefaultAsync(e => e.ID_Equipement == id);
            if (equipement == null)
                return NotFound();

            var groupe = await _context.GroupeMonitoring.FindAsync(dto.Groupe);
            if (groupe == null)
                return BadRequest("Groupe invalide");

            equipement.Type_equipement = dto.Type_equipement;
            equipement.Description_equipement = dto.Description_equipement;
            equipement.Marque = dto.Marque;
            equipement.Modele = dto.Modele;
            equipement.Commentaire = dto.Commentaire;
            equipement.Adresse_IP = dto.Adresse_IP;
            equipement.Groupe = groupe;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipement(int id)
        {
            var equipement = await _context.Equipement.FindAsync(id);
            if (equipement == null)
                return NotFound();

            _context.Equipement.Remove(equipement);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
