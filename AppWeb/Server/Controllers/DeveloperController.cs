using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.Server.Data;
using AppWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DeveloperController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Developers.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Developers.FirstOrDefaultAsync(a => a.DeveloperId == id);
            return Ok(dev);
        }       

        //Take a number ECO
        [HttpGet("GenearteEcoById/{id}")]
        public async Task<ActionResult<Developer>> GenearteEcoById(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            if (developer.ECOYear == 0 && developer.ECOCount == 0 && developer.ECOSelected==true)
            {
                var values = await GenerateEcoByIdAsync(id);
                developer.ECOYear = values.Year;
                developer.ECOCount = values.Count;
                await _context.SaveChangesAsync();
            }
            else if(developer.ECOSelected == false)
            {
                developer.ECOYear = 0;
                developer.ECOCount = 0;
                await _context.SaveChangesAsync();

            }

            return developer;
        }
        
        private async Task<YearCount> GenerateEcoByIdAsync(int id)
        {
            if (!await _context.Developers.AnyAsync(d => d.ECOYear == DateTime.Now.Year))
            {
                return new YearCount() { Count = 1, Year = DateTime.Now.Year };
            }

            int max = await _context.Developers.Where(d => d.ECOYear == DateTime.Now.Year).MaxAsync(d => d.ECOCount) + 1;
            return new YearCount() { Count = max, Year = DateTime.Now.Year };
        }

        //Creates a new Developer with the passed developer object data AND take ECR Number
        [HttpPost]
        public async Task<IActionResult> Post(Developer developer)
        {
                   
            YearCount dev = await IncrementDeveloperIdAsync();

            developer.Year = dev.Year;
            developer.Count = dev.Count;

            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Ok(developer.DeveloperId);
           
        }     


        //Take the number ECR
        private async Task<YearCount> IncrementDeveloperIdAsync()
        {
            if (!await _context.Developers.AnyAsync(d => d.Year == DateTime.Now.Year))
            {
                return new YearCount() { Count = 1, Year = DateTime.Now.Year };
            }

            int max = await _context.Developers.Where(d => d.Year == DateTime.Now.Year).MaxAsync(d => d.Count) + 1;
            return new YearCount() { Count = max, Year = DateTime.Now.Year };
        }

        //Modifies an existing developer record.
        [HttpPut]
        public async Task<IActionResult> Put(Developer developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new Developer { DeveloperId = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }






    }
}