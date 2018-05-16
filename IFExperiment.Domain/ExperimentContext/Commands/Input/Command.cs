using FluentValidator;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Input
{
    public abstract class Command : Notifiable, ICommand
    {
        public abstract bool Validated();

    }
}
