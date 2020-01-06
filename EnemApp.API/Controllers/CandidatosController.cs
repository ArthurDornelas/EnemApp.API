using EnemApp.API.Models;
using EnemApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Controllers
{
    [ApiController]
    [Route("candidatos")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatosController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet]
        public IActionResult GetCandidatos()
        {
            try
            {
                return Ok(_candidatoService.GetCandidatos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{idCandidato}")]
        public IActionResult GetCandidatos(int idCandidato)
        {
            try
            {
                return Ok(_candidatoService.GetCandidato(idCandidato));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult RegisterCandidato([FromBody] Candidato candidato)
        {
            try
            {
                return Created("candidatos", _candidatoService.AddCandidato(candidato));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult EditCandidato([FromBody] Candidato candidato)
        {
            try
            {
                return Ok(_candidatoService.UpdateCandidato(candidato));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{idCandidato}")]
        public IActionResult DeleteCandidatos(int idCandidato)
        {
            try
            {
                _candidatoService.DeleteCandidato(idCandidato);
                return Ok(new { Sucess = true, Message = "Deletado com sucesso!" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
