using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using PruebaASP.DTOs;
using PruebaASP.Models;
using PruebaASP.Repository;

namespace PruebaASP.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<ProgramaDto, ProgAsigDto> _api;

    public HomeController(IRepository<ProgramaDto, ProgAsigDto> api)
    {
        _api = api;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            //1 es el id de la asignatura: Grado en Enfermería
            //Al ingresar a la pagina inicial, muestre el query propuesto
            var asignaturas = await _api.GetByIdCampo(1);
            if (asignaturas == null)
            {
                return NotFound("Asignaturas no encontradas.");
            }

            return View(asignaturas);
        }
        catch (Exception error)
        {
            return StatusCode(500, $"Ocurrió un error inesperado.:\n{error.Message}");
        }
    }

    [HttpGet("Programas")]
    public async Task<IActionResult> GetProgramas()
    {
        //obtenemos la id y el nombre de todas las asignaturas
        try
        {
            var programas = await _api.GetCampo();
            if (programas == null)
            {
                return NotFound("programas no encontradas.");
            }

            return Ok(programas);
        }
        catch (Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpGet("Asignaturas")]
    public async Task<IActionResult> GetAsignaturas(int id)
    {
        try
        {
            //se accede mediante el tag select y busca segun el programa
            var asignaturas = await _api.GetByIdCampo(id);
            if (asignaturas == null)
            {
                return NotFound("Asignaturas no encontradas.");
            }

            return Ok(asignaturas);
        }
        catch (Exception error)
        {
            return BadRequest(error);
        }
    }

}
