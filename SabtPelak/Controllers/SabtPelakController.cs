using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SabtPelak.Models.Dto;
using SabtPelak.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SabtPelak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SabtPelakController : ControllerBase
    {
        ICarService _carService = null;
        public SabtPelakController(ICarService carService)
        {

            _carService = carService;

        }

        // GET: api/<SabtPelakController>
        [HttpGet]
        public async Task<IEnumerable<CarDto>> GetACars()
        {
            return await _carService.GetAll();
        }

        // GET api/<SabtPelakController>/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<CarDto> GetBy(int id)
        {
            return await _carService.GetById(id);
        }

        // POST api/<SabtPelakController>
        [HttpPost]
        public async Task SaveOrUpdate([FromForm] CarDto car)
        {
            if (car.Id == 0) await _carService.Save(car);
            else await _carService.Update(car);

        }

        // DELETE api/<SabtPelakController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        { 
            await _carService.Delete(id);
        }
    }
}
