using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Models;
using FluentValidation;

namespace EnemApp.API.Validators
{
    public class CandidatoValidator : AbstractValidator<Candidato>
    {
        public CandidatoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                });

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O nome da cidade é obrigatório");

            RuleFor(c => c.Nota)
                .LessThanOrEqualTo(100).WithMessage("A nota não pode ser maior que 100")
                .GreaterThanOrEqualTo(0).WithMessage("A nota não pode ser menor que 0");
        }
    }
}
