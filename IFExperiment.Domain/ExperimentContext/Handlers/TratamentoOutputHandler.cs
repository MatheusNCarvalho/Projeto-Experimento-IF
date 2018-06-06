using System;
using System.Collections.Generic;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.Outputs;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Queries;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Handlers
{
    public class TratamentoOutputHandler : Notifiable
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
                var tratamento = _experimentoRepository.GetByIdAsNoTracking(id);


                return new CommandResult(true, "", 200,
                    tratamento != null ? new GetTratamentoQueryResult(tratamento.Id, tratamento.Nome.ToString(), tratamento.Status) : null);

            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e });
            }
        }


        public ICommandResult Get()
        {
            try
            {
                ICollection<Tratamento> listTratamentos = _experimentoRepository.GetByRange();
                List<GetTratamentoQueryResult> getTratamentoQuery = new List<GetTratamentoQueryResult>();
                foreach (var listTratamento in listTratamentos)
                {
                    getTratamentoQuery.Add(new GetTratamentoQueryResult(listTratamento.Id, listTratamento.Nome.ToString(), listTratamento.Status));
                }
                return new CommandResult(true, "", 200, getTratamentoQuery);
            }
            catch (Exception e)
            {
                return new CommandResult(new { causa = e });
            }
        }




    }
}
