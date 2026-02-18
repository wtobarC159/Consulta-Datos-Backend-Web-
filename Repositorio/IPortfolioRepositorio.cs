using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API_Rest_Para_Consulta_de_Datos.Repositorio
{
    public class IPortfolioRepositorio : IPortfolio
    {
        private readonly Contexto _contexto;
        public IPortfolioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Portfolio?> AddPortfolio(int idMiembro, string Departamento)
        {
            var Dept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Nombre.ToLower() == Departamento.ToLower());
            var Miem = await _contexto.Miembros.FirstOrDefaultAsync(m => m.Id == idMiembro);

            if (Dept == null || Miem == null) return null;

            var PortfolioMiemb = await GetPortfolio(Miem.Id);
            if (PortfolioMiemb.Any(n => n.Nombre.ToLower() == Departamento)) return null;

            var NewPortfolio = new Portfolio { MiembroID = Miem.Id, DepartamentoID = Dept.Id };
            await _contexto.AddAsync(NewPortfolio);
            await _contexto.SaveChangesAsync();
            return NewPortfolio;
        }

        public async Task CreatePortfolio(Miembro MiemPortfolio)
        {
            if (!string.IsNullOrWhiteSpace(MiemPortfolio.Departamentos)) 
            {
                if ((MiemPortfolio.Departamentos).ToLower().Contains("musica")) 
                {
                    var Dept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Nombre.ToLower() == "musica");
                    var Portfolio = new Portfolio { MiembroID = MiemPortfolio.Id, DepartamentoID = Dept.Id};
                    await _contexto.Portfolios.AddAsync(Portfolio);
                }

                if ((MiemPortfolio.Departamentos).ToLower().Contains("evangelismo"))
                {
                    var Dept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Nombre.ToLower() == "evangelismo");
                    var Portfolio = new Portfolio { MiembroID = MiemPortfolio.Id, DepartamentoID = Dept.Id };
                    await _contexto.Portfolios.AddAsync(Portfolio);
                }

                if ((MiemPortfolio.Departamentos).ToLower().Contains("adolescentes"))
                {
                    var Dept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Nombre.ToLower() == "adolescentes");
                    var Portfolio = new Portfolio { MiembroID = MiemPortfolio.Id, DepartamentoID = Dept.Id };
                    await _contexto.Portfolios.AddAsync(Portfolio);
                }

                if ((MiemPortfolio.Departamentos).ToLower().Contains("escuela dominical"))
                {
                    var Dept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Nombre.ToLower() == "escuela dominical");
                    var Portfolio = new Portfolio { MiembroID = MiemPortfolio.Id, DepartamentoID = Dept.Id };
                    await _contexto.Portfolios.AddAsync(Portfolio);
                }

                if ((MiemPortfolio.Departamentos).ToLower().Contains("damas"))
                {
                    var Dept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Nombre.ToLower() == "damas");
                    var Portfolio = new Portfolio { MiembroID = MiemPortfolio.Id, DepartamentoID = Dept.Id };
                    await _contexto.Portfolios.AddAsync(Portfolio);
                }

                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<Portfolio?> DeletePortfolio(int id, string Departamento)
        {
            var Miem = await _contexto.Miembros.FirstOrDefaultAsync(m => m.Id == id);
            if(Miem==null) return null;
            var Portfolio = await GetPortfolio(Miem.Id);
            if(Portfolio==null) return null;

            var GetDept = Portfolio.Where(n => n.Nombre.ToLower() == Departamento.ToLower()).ToList();

            if (GetDept.Count() == 1)
            {
                var RemovPortfolio = await _contexto.Portfolios.FirstOrDefaultAsync(x => x.MiembroID == id && x.Departamento.Nombre.ToLower() == Departamento.ToLower());
                if (RemovPortfolio == null) return null;
                _contexto.Portfolios.Remove(RemovPortfolio);
                await _contexto.SaveChangesAsync();
                return RemovPortfolio;
            }
            else 
            {
                return null;
            }
        }

       /* public async Task<List<Portfolio>> GetdepPortfolio()
        {
            var Portfolio = await _contexto.Portfolios.ToListAsync();
            return Portfolio;
        }*/

        public async Task<List<Departamento>> GetPortfolio(int idMiembro)
        {
            var MiembroExist = await _contexto.Miembros.FirstOrDefaultAsync(m => m.Id == idMiembro);
            if (MiembroExist==null) return null;
            var DepartList = await _contexto.Portfolios.Where(m => m.MiembroID == idMiembro).Select(Depart => new Departamento
            { 
                Id = Depart.DepartamentoID,
                Nombre = Depart.Departamento.Nombre,
                Lider = Depart.Departamento.Lider,
                Colider = Depart.Departamento.Colider,
                CantidadMiembros = Depart.Departamento.CantidadMiembros,
                Descripcion = Depart.Departamento.Descripcion,
                TiempoExistencia = Depart.Departamento.TiempoExistencia
            }).ToListAsync();
            return DepartList;
        }
    }
}
