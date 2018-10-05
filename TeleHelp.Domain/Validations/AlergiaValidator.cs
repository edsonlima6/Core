//using FluentValidation;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Validations
{
    public class AlergiaValidator //: AbstractValidator<Alergia>
    {

        //public AlergiaValidator()
        //{
        //    RuleFor(x => x.Nome)
        //        .NotEmpty().WithMessage("Informe o nome da alergia.")
        //        .Length(5, 100).WithMessage("O nome deve ter no mínimo 5 caracteres e no máximo 50 caracteres.");
        //
        //    RuleFor(c => c.TipoAlergia)
        //        .NotEmpty().WithMessage("Informe o tipo de alergia.");
        //
        //   /* RuleFor(c => c.DataNascimento)
        //        .NotEmpty().WithMessage("Informe a data de nascimento do Aluno")
        //        .Must(AlunoMaiorDeIdade).WithMessage("O aluno deve ser maior que 18 anos");*/
        //}
/*
        private static bool AlunoMaiorDeIdade(System.DateTime dataNascimento)
        {
            return dataNascimento<=System.DateTime.Now.AddYears(-18);
        }*/
    }
}
