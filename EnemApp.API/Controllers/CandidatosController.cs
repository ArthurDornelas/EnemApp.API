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
                _candidatoService.AddCandidato<CandidatoValidator>(candidato);
                return Created("candidatos", candidato);
            }
            catch (ValidationException ex)
            {
                CopyValidationErrorsToModelstate(ex);
                return this.ValidationProblem();
            }
            catch (Exception ex)
            {
               return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult EditCandidato([FromBody] Candidato candidato)
        {
            try
            {
                _candidatoService.UpdateCandidato<CandidatoValidator>(candidato);
                return Ok(candidato);
            }
            catch (ValidationException ex)
            {
                CopyValidationErrorsToModelstate(ex);
                return this.ValidationProblem();
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

        private void CopyValidationErrorsToModelstate(ValidationException validationException)
        {
            foreach (var error in validationException.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
