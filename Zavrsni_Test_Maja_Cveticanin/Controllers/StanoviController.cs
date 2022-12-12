using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zavrsni_Test_Maja_Cveticanin.IRepository;
using Zavrsni_Test_Maja_Cveticanin.Repository;
using Zavrsni_Test_Maja_Cveticanin.Models.DTO;
using Zavrsni_Test_Maja_Cveticanin.Models;
using static System.Net.WebRequestMethods;
using Zavrsni_Test_Maja_Cveticanin.Models.filters;

namespace Zavrsni_Test_Maja_Cveticanin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StanoviController : ControllerBase
    {
        private readonly IStanRepository _stanRepository;

        private readonly IMapper _mapper;

        public StanoviController(IStanRepository stanRepository, IMapper mapper)
        {
            _stanRepository = stanRepository;
            _mapper = mapper;
        }
        // GET: api/Stans
        [HttpGet]
        public IActionResult GetStans()
        {
            return Ok(_stanRepository.GetAll().ProjectTo<StanDetailsDTO>(_mapper.ConfigurationProvider).ToList());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GET: api/Stans/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetStan(int id)
        {
            var stan = _stanRepository.GetById(id);
            if (stan == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StanDetailsDTO>(stan));
        }

        // PUT: api/Stans/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutStan(int id, Stan stan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stan.Id)
            {
                return BadRequest();
            }

            try
            {
                _stanRepository.Update(stan);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<StanDetailsDTO>(stan));
        }

        // POST: api/Stans
        [Authorize]
        [HttpPost]
        public IActionResult PostStan(Stan stan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _stanRepository.Add(stan);
            return CreatedAtAction("GetStan", new { id = stan.Id }, _mapper.Map<StanDetailsDTO>(stan));
        }

        // DELETE: api/Stans/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteStan(int id)
        {
            var Stan = _stanRepository.GetById(id);
            if (Stan == null)
            {
                return NotFound();
            }

            _stanRepository.Delete(Stan);
            return NoContent();
        }

        [Route("/api/pretraga")]
        [HttpPost]
        public IActionResult PostMinMaxPrice(StanFilter stanFilterl)
        {
            IQueryable<Stan> stans = _stanRepository.Filter(stanFilterl);

            return Ok(stans.ProjectTo<StanDetailsDTO>(_mapper.ConfigurationProvider).ToList());
        }
    }
}

