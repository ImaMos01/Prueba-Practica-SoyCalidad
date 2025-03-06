using PruebaASP.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using PruebaASP.DTOs;

namespace PruebaASP.Repository
{
    public class ProgramaRepository : IRepository<ProgramaDto, ProgAsigDto>
    {
        //no requerimos de la capa modelo porque se usa los dto para acceder a los campos más importantes  
        private readonly IDbConnection _bd;
        public ProgramaRepository(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
      
        public async Task<IEnumerable<ProgramaDto>> GetCampo()
        {
            /*
             Retorna los datos correspondientes de la tabla TProgramas
             */
            var sqlQuery = "SELECT IdPrograma, Programa FROM [dbo].[TProgramas]";
            var queryData = await _bd.QueryAsync<ProgramaDto>(sqlQuery);
            return queryData;
        }

        public async Task<IEnumerable<ProgAsigDto>> GetByIdCampo(int id)
        {
            /*
             Filtra los datos segun el id del programa
             */
            var sqlQuery = "Select A.Asignatura, P.Programa, PA.EsOpcional, PA.TieneDocencia, PA.FechaAlta from [dbo].[TProgramasAsignaturas] PA inner join [dbo].[TProgramas] P on PA.IdPrograma = P.IdPrograma inner join [dbo].[TAsignaturas] A on PA.IdAsignatura = A.IdAsignatura where PA.IdPrograma = @idPrograma";
            var queryData = await _bd.QueryAsync<ProgAsigDto>(sqlQuery, new { idPrograma = id });
            return queryData;
        }
    }
}
