using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.Output;
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
                return new CommandResult(new { causa = e.Message });
            }
        }


        public ICommandResult GetFiltro(TratamentoFiltro filtro)
        {
            try
            {
                var filtros = _experimentoRepository.Filtro(filtro.MountExpression(),
                    x => x.Nome.ToString(),
                    true,
                    out int totalRegistros,
                    string.Empty,
                    filtro.Offset,
                    filtro.Limit);

                return new CommandResult(filtros, totalRegistros);
            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e.Message });
            }
        }




    }
}
