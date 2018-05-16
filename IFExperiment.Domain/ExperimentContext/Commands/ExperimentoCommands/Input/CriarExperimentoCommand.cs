using System.Collections.Generic;
using IFExperiment.Domain.ExperimentContext.Commands.Input;
using IFExperiment.Domain.ExperimentContext.Commands.PlantaCommands.Input;

namespace IFExperiment.Domain.ExperimentContext.Commands.ExperimentoCommands.Input
{
    public class CriarExperimentoCommand : Command
    {
        public CriarExperimentoCommand()
        {
            Plantas = new List<PlantaCommand>();
        }

        public string Nome { get; set; }
        public int QtdRepeticao { get; set; }
        public IList<PlantaCommand> Plantas { get; set; }
       // public AreaExperimento AreaExperimento { get; protected set; }

        public override bool Validated()
        {
            return Valid;
        }
    }
}
