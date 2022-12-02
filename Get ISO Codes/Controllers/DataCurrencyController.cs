using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Get_ISO_Codes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataCurrencyController : ControllerBase
    {
        private readonly ICurrencyService _services;

        public DataCurrencyController(ICurrencyService services)
        {
           _services = services;
        }

        [HttpGet("/all")] public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }

        [HttpGet("/GetById/{id}")] public IActionResult Get([FromRoute] int id) 
        {
            return Ok(_services.Get(id));
        }

        [HttpPost] public IActionResult Create([FromBody] CurrencyDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _services.Create(dto);
            return Ok();
        }

        [HttpPut] public IActionResult Edit([FromBody] CurrencyDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _services.Edit(dto);
            return Ok();
        }

        [HttpDelete("/Delete/{id}")] public IActionResult Delete([FromRoute] int id)
        {
            _services.Delete(id);
            return Ok();
        }
    }
}
