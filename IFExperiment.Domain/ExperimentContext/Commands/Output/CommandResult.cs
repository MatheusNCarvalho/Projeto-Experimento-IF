using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.BaseCommand.Outputs
{
    public class CommandResult : ICommandResult
    {
        
        public CommandResult(object data)
        {
            Data = data;
        }

      
        public object Data { get; set; }
    }
}
