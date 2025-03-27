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
        public async Task<ActionResult<Equipement>> CreateEquipement(Equipement equipement)
        {
            _context.Equipement.Add(equipement);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEquipement), new { id = equipement.ID_Equipement }, equipement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipement(int id, Equipement equipement)
        {
            if (id != equipement.ID_Equipement)
                return BadRequest();

            _context.Entry(equipement).State = EntityState.Modified;
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
