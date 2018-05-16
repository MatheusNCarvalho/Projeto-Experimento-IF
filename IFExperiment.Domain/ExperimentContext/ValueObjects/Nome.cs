

using FluentValidator.Validation;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.ValueObjects
{
    public class Nome : EntityBase
    {
        public Nome(string valor)
        {
            Valor = valor;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Valor, 3, "Valor", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Valor, 40, "Valor", "O nome deve conter no maximo 40 caracteres")
            );
        }

        public string Valor { get; protected set; }

        public override string ToString()
        {
            return Valor;
        }
    }
}
