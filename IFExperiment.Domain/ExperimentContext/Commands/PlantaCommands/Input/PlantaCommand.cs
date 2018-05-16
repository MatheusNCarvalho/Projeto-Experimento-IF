using IFExperiment.Domain.ExperimentContext.Commands.Input;

namespace IFExperiment.Domain.ExperimentContext.Commands.PlantaCommands.Input
{
    public class PlantaCommand : Command
    {
        public string Nome { get;  set; }

        public override bool Validated()
        {
            throw new System.NotImplementedException();
        }
    }
}
