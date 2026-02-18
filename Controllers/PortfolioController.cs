using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_Rest_Para_Consulta_de_Datos.Data;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Mapeador;
using Microsoft.AspNetCore.Authorization;

namespace API_Rest_Para_Consulta_de_Datos.Controllers
{
    [Route("apicrud/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly Contexto _contexto;
        private readonly IPortfolio _portfolio;

        public PortfolioController(Contexto contexto, IPortfolio portfolio) 
        {
            _contexto = contexto;
            _portfolio = portfolio;
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetPortfolios([FromRoute] int id) 
        { 
            var PortfolioModel = await _portfolio.GetPortfolio(id);
            if (PortfolioModel == null) return NotFound();
            var DepartDTO = PortfolioModel.Select(m => m.ToDeparDTOsim()).ToList();
            return Ok(DepartDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> AddPortfolios([FromRoute] int id, [FromBody] string Departamento) 
        {
            var PortfolioModel = await _portfolio.AddPortfolio(id, Departamento);
            if (PortfolioModel == null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePortfolios([FromRoute] int id, string Departamento)
        {
            var PortfolioModel = await _portfolio.DeletePortfolio(id, Departamento);
            if(PortfolioModel == null) return NotFound();

            return NoContent();
        }
    }
}
