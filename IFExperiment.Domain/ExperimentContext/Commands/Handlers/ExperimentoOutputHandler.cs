using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.Output;
using IFExperiment.Domain.ExperimentContext.Filter;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Handlers
{
    public class ExperimentoOutputHandler : Notifiable, ICommandResult
    {
        private readonly IExperimentoRepository _repository;

        public ExperimentoOutputHandler(IExperimentoRepository repository)
        {
            _repository = repository;
        }


        public ICommandResult GetById(Guid id)
        {
            try
            {
                var result = _repository.GetByIdAsNoTracking(id);
                return new CommandResult(result);
            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e });
            }
        }



        public ICommandResult Get(ExperimentoFiltro filtro)
        {
            try
            {
                return new CommandResult(_repository.GetByRange(filtro.MountExpression(), x => x.Nome.ToString(), true, filtro.Page, filtro.ItemPerPage));
            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e });
            }
        }
    }
}
