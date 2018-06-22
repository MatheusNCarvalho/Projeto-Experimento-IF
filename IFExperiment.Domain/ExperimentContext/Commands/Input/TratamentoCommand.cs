using FluentValidator.Validation;

namespace IFExperiment.Domain.ExperimentContext.Commands.Input
{
    public class TratamentoCommand : Command
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public override bool Validated()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                AddNotifications(new ValidationContract()
                    .IsNotNull(Id, "Id", "Obrigatorio informar pelo menos um Tratamento!")
                );
            }

            if (!string.IsNullOrEmpty(Nome))
            {
                AddNotifications(new ValidationContract()
                    .HasMaxLen(Nome, 255, "", "Nome deve conter no maximo 255 caracteres!")
                    .HasMinLen(Nome, 3, "Nome", "Nome deve conter no minimo 3 caracteres!")
                );
            }
            return Valid;
        }
    }
}
