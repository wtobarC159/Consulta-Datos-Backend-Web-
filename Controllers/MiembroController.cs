using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_Rest_Para_Consulta_de_Datos.Data;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Mapeador;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;
using API_Rest_Para_Consulta_de_Datos.Servicios;

namespace API_Rest_Para_Consulta_de_Datos.Controllers
{
    [Route("apicrud/miembro")]
    [ApiController]
    public class MiembroController : ControllerBase
    {
        private readonly Contexto _contexto;
        private readonly IMiembro _MiembroModel;
        private readonly RellenarRelacion rellenar;

        public MiembroController(Contexto contexto, IMiembro MiembroModel,RellenarRelacion rellenar)
        {
            _contexto = contexto;
            _MiembroModel = MiembroModel;
            this.rellenar = rellenar;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryObject Query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Miembros = await _MiembroModel.GetAllMiembros(Query);
            var MiembrosDTO = Miembros.Select(m => m.ToMiembroDTO(rellenar)).ToList();
            return Ok(MiembrosDTO);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var Miembro = await _MiembroModel.GetbyIdMiembro(id);

            if (Miembro == null) 
            {
                return NotFound();
            }

            return Ok(Miembro.ToMiembroDTO(rellenar));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] MiembroCreateDTO MiembroCreate) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Miembro = await _MiembroModel.CreateMiembro(MiembroCreate.ToMiembro());

            return CreatedAtAction(nameof(GetById), new {id = Miembro.Id},Miembro.ToMiembroDTO(rellenar));
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

            var Miembro = await _MiembroModel.DeleteMiembro(id);

            if (Miembro == null) 
            {
                return NotFound();
            }
            else 
            {
                return NoContent();
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MiembroUpdateDTO MiembroUpdate) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var Miembro = await _MiembroModel.UpdateMiembro(id,MiembroUpdate);

            if (Miembro == null) 
            {
                return NotFound();
            }

            return Ok(Miembro.ToMiembroDTO(rellenar));
        }

    }
}
