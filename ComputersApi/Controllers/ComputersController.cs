using System.Threading.Tasks;
using ComputersApi.Models;
using ComputersApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputersApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IRepository<Computer> _computerRepository;

        public ComputersController(ApiContext context, IRepository<Computer> computerRepository)
        {
            _context = context;
            _computerRepository = computerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var computers = await _context.Computers.ToArrayAsync();
            return Ok(computers);
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody]Computer computer)
        {
            var result = await _context.Computers.AddAsync(computer);
            return Ok();
        }
    }
}
