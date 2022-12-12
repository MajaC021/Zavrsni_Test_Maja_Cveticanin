using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zavrsni_Test_Maja_Cveticanin.IRepository;
using Zavrsni_Test_Maja_Cveticanin.Models;

namespace Zavrsni_Test_Maja_Cveticanin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZgradeController : ControllerBase
    {

        private readonly IZgradaRepository _zgradaRepository;

        private readonly ILogger<ZgradeController> _logger;

        public ZgradeController(IZgradaRepository ZgradaRepository, ILogger<ZgradeController> logger)
        {
            _zgradaRepository = ZgradaRepository;
            _logger = logger;
        }
        // GET: api/Zgrade
        [HttpGet]
        public IActionResult GetZgrade()
        {
            _logger.LogTrace("GetZgrade called!");
            _logger.LogWarning("GetZgrade called as warning!");
            return Ok(_zgradaRepository.GetAll().ToList());
        }
        // GET: api/Zgrade/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetZgrada(int id)
        {
            var shop = _zgradaRepository.GetById(id);

            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        //[Authorize]
        //[HttpGet]
        //[Route("find")]
        //public IActionResult GetZgradaPostCode([FromQuery] int code)
        //{

        //    return Ok(_zgradaRepository.Search(code).ToList());
        //}

        // PUT: api/Zgrade/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutZgrada(int id, Zgrada zgrada)
        {
            if (id != zgrada.Id)
            {
                return BadRequest();
            }

            try
            {
                _zgradaRepository.Update(zgrada);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(zgrada);
        }
        // POST: api/Zgrade
        [Authorize]
        [HttpPost]
        public IActionResult PostZgrada(Zgrada zgrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _zgradaRepository.Add(zgrada);
            return CreatedAtAction("GetZgrada", new { id = zgrada.Id }, zgrada);
        }

        // DELETE: api/Zgrade/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteZgrada(int id)
        {
            var shop = _zgradaRepository.GetById(id);
            if (shop == null)
            {
                return NotFound();
            }

            _zgradaRepository.Delete(shop);
            return NoContent();
        }
    }
}
