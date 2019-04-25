using System.Collections.Generic;
using IFExperiment.Domain.ExperimentContext.Enums;

namespace IFExperiment.Domain.ExperimentContext.Commands.Input
{
    public class CriarExperimentoCommand : Command
    {
        public CriarExperimentoCommand()
        {
            Tratamento = new List<TratamentoCommand>();
        }

        public string Nome { get; set; }
        public int QtdRepeticao { get; set; }
        public IList<TratamentoCommand> Tratamento { get; set; }
        public ECommandStatus Status { get; set; }

        public override bool Validated()
        {
            foreach (var tratamentoCommand in Tratamento)
            {
                AddNotifications(tratamentoCommand.Notifications);
            }
            return Valid;
        }
    }
}
