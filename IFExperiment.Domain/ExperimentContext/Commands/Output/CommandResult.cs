using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Output
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
