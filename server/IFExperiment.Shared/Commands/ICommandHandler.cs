using System;

namespace IFExperiment.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {

        ICommandResult HandlerCreate(T command);
        ICommandResult HandlerUpdate(T command);
        ICommandResult HandlerDelete(Guid id);
    }
}
