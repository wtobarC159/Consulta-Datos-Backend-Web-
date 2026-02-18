using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_Rest_Para_Consulta_de_Datos.Data;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Mapeador;
using API_Rest_Para_Consulta_de_Datos.Dtos.Departamento;
using API_Rest_Para_Consulta_de_Datos.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace API_Rest_Para_Consulta_de_Datos.Controllers
{
    [Route("apicrud/departamento")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly Contexto _contexto;
        private readonly IDepartamento _DepartModel;
        private readonly RellenarRelacion rellenar;

        public DepartamentoController(Contexto contexto, IDepartamento DepartModel,RellenarRelacion rellenar)
        {
            _contexto = contexto;
            _DepartModel = DepartModel;
            this.rellenar = rellenar;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllAsync() 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var Departamentos = await _DepartModel.GetAllDept();
            var DepartDTO = Departamentos.Select(m => m.ToDeparDTO(rellenar)).ToList();
            return Ok(DepartDTO);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Departamento = await _DepartModel.GetbyIdDept(id);

            if (Departamento == null)
            {
                return NotFound();
            }

            return Ok(Departamento.ToDeparDTO(rellenar));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] DepartamentoCreateDTO CreateDept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Departamento = await _DepartModel.CreateDept(CreateDept.ToDepartamento());

            return CreatedAtAction(nameof(GetById), new { id = Departamento.Id }, Departamento.ToDeparDTO(rellenar));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var Departamento = await _DepartModel.DeleteDept(id);

            if (Departamento == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DepartamentoUpdateDTO UpdateDept) 
        { 
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var Departamento = await _DepartModel.UpdateDept(id, UpdateDept);

            if (Departamento == null) 
            {
                return NotFound();
            }
            
            return Ok(Departamento.ToDeparDTO(rellenar));
        }
    }
}
