using EnemApp.API.Models;
using EnemApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Interfaces.ServicesInterfaces;
using EnemApp.API.Validators;
using FluentValidation;
using AutoMapper;
using EnemApp.API.ViewModels;

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
                var candidatosVM = _candidatoService.GetCandidatos();
                return Ok(candidatosVM);
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
                var candidatoVM = _candidatoService.GetCandidato(idCandidato);
                return Ok(candidatoVM);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult RegisterCandidato([FromBody] CandidatoViewModel candidatoVM)
        {
            try
            {
                _candidatoService.AddCandidato(candidatoVM);
                return Created("candidatos", candidatoVM);
            }
            catch (Exception ex)
            {
               return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult EditCandidato([FromBody] CandidatoViewModel candidatoVM)
        {
            try
            {
                _candidatoService.UpdateCandidato(candidatoVM);
                return Ok(candidatoVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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

        [HttpPut("realizarConcurso/{numVagas}")]
        public IActionResult RealizarConcurso(int numVagas)
        {
            try
            {
                _candidatoService.RealizarConcurso(numVagas);
                return Ok(new { Sucess = true, Message = "Concurso Realizado com Sucesso!" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("getConcursosCandidato/{idCandidato}")]
        public IActionResult GetConcursosCandidato(int idCandidato)
        {
            try
            {
                var concursosVM = _candidatoService.GetConcursosCandidato(idCandidato);
                return Ok(concursosVM);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
