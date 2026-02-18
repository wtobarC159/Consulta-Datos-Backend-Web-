using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_Rest_Para_Consulta_de_Datos.Data;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Mapeador;
using API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion;
using Microsoft.AspNetCore.Authorization;

namespace API_Rest_Para_Consulta_de_Datos.Controllers
{
    [Route("apicrud/contribucion")]
    [ApiController]
    public class ContribController : ControllerBase
    {
        private readonly Contexto _contexto;
        private readonly IContribucion _ContModel;

        public ContribController(Contexto contexto, IContribucion ContModel)
        {
            _contexto = contexto;
            _ContModel = ContModel;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryCont Object)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Contribuciones = await _ContModel.GetAllContribucion(Object);
            var ContDTO = Contribuciones.Select(m => m.ToContrDTO()).ToList();
            return Ok(ContDTO);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Contribucion = await _ContModel.GetbyIdCont(id);

            if (Contribucion == null)
            {
                return NotFound();
            }

            return Ok(Contribucion.ToContrDTO());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ContribucionCreateDTO CreateCont)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Contribucion = await _ContModel.CreateCont(CreateCont.ToContribucion());

            return CreatedAtAction(nameof(GetById), new { id = Contribucion.Id }, Contribucion.ToContrDTO());
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            var Contribucion = await _ContModel.DeleteCont(id);

            if (Contribucion == null) 
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ContribucionUpdateDTO ContUpdate) 
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            var Contribucion = await _ContModel.UpdateCont(id,ContUpdate);

            if (Contribucion == null) 
            {
                return NotFound();
            }

            return Ok(Contribucion.ToContrDTO());
        }
    }
}
