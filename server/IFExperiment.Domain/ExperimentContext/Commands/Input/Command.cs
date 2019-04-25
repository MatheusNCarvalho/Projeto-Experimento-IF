using FluentValidator;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Input
{
    public  class Command : Notifiable, ICommand
    {
        public virtual bool Validated()
        {
            return Valid;
        }
    }
}
