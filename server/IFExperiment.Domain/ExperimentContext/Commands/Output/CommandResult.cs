using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Output
{
    public class CommandResult : ICommandResult
    {

        public CommandResult(object data, int count)
        {
            Data = data;
            Count = count;
        }

        public CommandResult(object data)
        {
            Data = data;
        }

        public object Data { get; set; }

        public int Count { get; set; }
    }
}
