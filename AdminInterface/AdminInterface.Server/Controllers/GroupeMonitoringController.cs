using AdminInterface.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminInterface.Server.Controllers
{
    [Route("api/groupes")]
    [ApiController]
    public class GroupeMonitoringController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroupeMonitoringController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupeMonitoring>>> GetGroupes()
        {
            return await _context.GroupeMonitoring.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupeMonitoring>> GetGroupe(int id)
        {
            var groupe = await _context.GroupeMonitoring.FindAsync(id);
            if (groupe == null)
                return NotFound();
            return groupe;
        }

        [HttpPost]
        public async Task<ActionResult<GroupeMonitoring>> CreateGroupe(GroupeMonitoring groupe)
        {
            _context.GroupeMonitoring.Add(groupe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGroupe), new { id = groupe.ID_Groupe }, groupe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupe(int id, GroupeMonitoring groupe)
        {
            if (id != groupe.ID_Groupe)
                return BadRequest();

            _context.Entry(groupe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupe(int id)
        {
            var groupe = await _context.GroupeMonitoring.FindAsync(id);
            if (groupe == null)
                return NotFound();

            _context.GroupeMonitoring.Remove(groupe);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
