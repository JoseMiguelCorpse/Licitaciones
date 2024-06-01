using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupabaseApi.Data;
using SupabaseApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicitacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LicitacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Licitacion>>> GetLicitaciones()
        {
            var licitaciones = await _context.Licitaciones
                .FromSqlRaw("SELECT * FROM \"licitaciones\"")
                .ToListAsync();

            return Ok(licitaciones);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<Licitacion>> GetLicitacion(string nombre)
        {
            var licitacion = await _context.Licitaciones
                .FromSqlRaw("SELECT * FROM \"licitaciones\" WHERE \"Nombre\" = {0}", nombre)
                .FirstOrDefaultAsync();

            if (licitacion == null)
            {
                return NotFound();
            }

            return Ok(licitacion);
        }
    }
}
