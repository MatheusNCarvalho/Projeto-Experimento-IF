using FluentValidator.Validation;
using IFExperiment.Domain.ExperimentContext.Commands.Input;

namespace IFExperiment.Domain.ExperimentContext.Commands.TratamentoCommands.Input
{
    public class TratamentoCommand : Command
    {
        public string Nome { get;  set; }

        public override bool Validated()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Nome, 3, "Valor", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 40, "Valor", "O nome deve conter no maximo 40 caracteres")
            );
            return Valid;
        }
    }
}
