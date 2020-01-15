using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Interfaces.ServicesInterfaces;
using EnemApp.API.Models;
using EnemApp.API.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnemApp.API.Controllers
{
    [ApiController]
    [Route("concursos")]
    public class ConcursosController : ControllerBase
    {
        private readonly IConcursoService _concursoService;
        public ConcursosController(IConcursoService concursoService)
        {
            _concursoService = concursoService;
        }

        [HttpGet]
        public IActionResult GetConcursos()
        {
            try
            {
                return Ok(_concursoService.GetConcursos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{idConcurso}")]
        public IActionResult GetConcursos(int idConcurso)
        {
            try
            {
                return Ok(_concursoService.GetConcurso(idConcurso));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult RegisterConcurso([FromBody] Concurso concurso)
        {
            try
            {
                _concursoService.AddConcurso<ConcursoValidator>(concurso);
                return Created("concursos", concurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult EditConcurso([FromBody] Concurso concurso)
        {
            try
            {
                _concursoService.UpdateConcurso<ConcursoValidator>(concurso);
                return Ok(concurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{idConcurso}")]
        public IActionResult DeleteConcursos(int idConcurso)
        {
            try
            {
                _concursoService.DeleteConcurso(idConcurso);
                return Ok(new { Sucess = true, Message = "Deletado com sucesso!" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("getCandidatosConcurso/{idConcurso}")]
        public IActionResult GetCandidatosConcurso(int idConcurso)
        {
            try
            {
                return Ok(_concursoService.GetCandidatosConcurso(idConcurso));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("addCandidatosConcurso/{idConcurso}")]
        public IActionResult AddCandidatosConcurso(int idConcurso)
        {
            try
            {
                _concursoService.AddCandidatosConcurso(idConcurso);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
