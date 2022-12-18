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
        [HttpGet]
        public async Task<IActionResult> GetDeveloperActions()
        {
            var devs = await _contexts.ActionItems.ToListAsync();
            return Ok(devs);
        }

        // GET: api/<DeveloperActionController>
        //    [HttpGet]
        //     public IEnumerable<Developer> GetDevelopersWithActions()
        //  {
        //      return _contexts.Developers.Include(a => a.ActionItems).ToList();
        // }

        // GET api/<DeveloperActionController>/5
      //  [HttpGet("{id}")]
      //  public async Task<ActionResult<Developer>> GetDeveloperActions(int id)
        // {
        //    Developer? developer = await _contexts.Developers
        //                          .Include(a => a.ActionItems)
        //                          .FirstOrDefaultAsync(d => d.DeveloperId == id);
       //
         //    if (developer == null)
         //   {
        //       return NotFound();
        //   }

       //     return Ok(developer);
       //  }

        [HttpPost("{id}")]
        public async Task<ActionResult<ActionItem>> Post(int id, [FromBody] ActionItem poco)
        {
            Developer? developer = await _contexts.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            ActionItem ac = new ActionItem()
            {
                ActionId = 0,
                DeveloperId = id,
                CloseDate = poco.CloseDate,
                DescriptionA = poco.DescriptionA,
                OpenDate = poco.OpenDate,
                PlanDate = poco.PlanDate,
                State = poco.State,
                Tilte = poco.Tilte
            };

            developer.ActionItems.Add(ac);
            await _contexts.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperActions), new { id = ac.ActionId }, poco);
        }


        // POST api/<DeveloperActionController>
        //  [HttpPost]
        //  public async Task<ActionResult<Developer>> PostAsync([FromBody] Developer test)
        //   {
        //     _contexts.Developers.Add(test);
        //    await _contexts.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetDeveloperActions), new { id = test.DeveloperId }, test);
        // }

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
            ActionItem ac = new ActionItem()
            {
                ActionId = 0,
                DeveloperId = id,
                CloseDate = actionItem.CloseDate,
                DescriptionA = actionItem.DescriptionA,
                OpenDate = actionItem.OpenDate,
                PlanDate = actionItem.PlanDate,
                State = actionItem.State,
                Tilte = actionItem.Tilte
            };

            developer.ActionItems.Add(actionItem);
              await _contexts.SaveChangesAsync();

              return CreatedAtAction(nameof(GetDeveloperActions), new { id = ac.ActionId }, actionItem);

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
