using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.BaseCommand.Outputs;
using IFExperiment.Domain.ExperimentContext.Filter;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Handlers
{
    public class TratamentoOutputHandler : Notifiable, ICommandResult
    {

        private readonly ITratamentoRepository _experimentoRepository;


        public TratamentoOutputHandler(ITratamentoRepository experimentoRepository)
        {
            _experimentoRepository = experimentoRepository;
        }

        public ICommandResult GetById(Guid id)
        {
            try
            {
                return new CommandResult(_experimentoRepository.GetByIdAsNoTracking(id));

            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e });
            }
        }


        public ICommandResult Get(TratamentoFiltro filtro)
        {
            try
            {
                return new CommandResult(_experimentoRepository.GetByRange(filtro.MountExpression(), x=> x.Nome.ToString(), true, filtro.Page, filtro.ItemPerPage));
            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e });
            }
        }




    }
}
