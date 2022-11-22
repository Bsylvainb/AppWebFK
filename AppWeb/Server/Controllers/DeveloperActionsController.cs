using AppWeb.Server.Data;
using AppWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperActionsController : ControllerBase
    {
        private readonly ApplicationDBContext _contexts;

        public DeveloperActionsController(ApplicationDBContext contexts)
        {
            this._contexts= contexts;
        }

        // GET: api/<DeveloperActionController>
        [HttpGet]
        public IEnumerable<Developer> GetDevelopersWithActions()
        {
            return _contexts.Developers.Include(a => a.ActionItems).ToList();
        }

        // GET api/<DeveloperActionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloperActions(int id)
        {
            Developer? developer = await _contexts.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        // POST api/<DeveloperActionController>
        [HttpPost]
        public async Task<ActionResult<Developer>> PostAsync([FromBody] Developer developer)
        {
            _contexts.Developers.Add(developer);
            await _contexts.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperActions), new { id = developer.DeveloperId }, developer);
        }

        // PUT api/<DeveloperActionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Developer>> Put(int id, [FromBody] ActionItem actionItem)
        {
            Developer? developer = await _contexts.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            developer.ActionItems.Add(actionItem);
            await _contexts.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperActions), new { id = developer.DeveloperId }, developer);

        }

        // DELETE api/<DeveloperActionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Developer? developer = await _contexts.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            _contexts.Remove(developer);

            await _contexts.SaveChangesAsync();

            return NoContent();
        }

    }
}
