using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    // https://localhost:44363/api/value
    // http://localhost:5000/api/Value

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly DataContext _context;

        public ValueController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);

        }
    }
}