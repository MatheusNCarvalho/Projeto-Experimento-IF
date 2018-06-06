using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.BaseCommand.Outputs;
using IFExperiment.Domain.ExperimentContext.Commands.ExperimentoCommands.Input;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Handlers
{
    public class ExperimentoHandler :
        Notifiable,
        ICommandHandler<CriarExperimentoCommand>
    {


        private readonly IExperimentoRepository _experimentoRepository;
        private readonly ITratamentoRepository _tratamentoRepository;

        public ExperimentoHandler(IExperimentoRepository experimentoRepository, ITratamentoRepository tratamentoRepository)
        {
            _experimentoRepository = experimentoRepository;
            _tratamentoRepository = tratamentoRepository;
        }

        public ICommandResult HandlerCreate(CriarExperimentoCommand command)
        {

            try
            {
                AddNotifications(command.Notifications);
                command.Validated();

                //Validar os commands
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                //Criar os VOs
                var nomeExperimento = new Nome(command.Nome);

                //Criar as entidades
                var experimento = new Experimento(nomeExperimento, command.QtdRepeticao);
                foreach (var tratamentoCommand in command.Tratamento)
                {
                    var tratamento = _tratamentoRepository.GetByIdTracking(Guid.Parse(tratamentoCommand.Id));
                    if(tratamento != null)
                    {
                        experimento.AddTratamento(new ExperimentoTramento(experimento, tratamento));
                    }
                   
                }

                if (command.Status.Equals(ECommandStatus.Aberto))
                {
                    experimento.Arquivar();
                }
                else if (command.Status.Equals(ECommandStatus.EmAdamento))
                {
                    experimento.Gerar();
                }


                //Validar entidades e VOs
                AddNotifications(experimento.Notifications);
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                //Persistir experimento
                _experimentoRepository.Save(experimento);
                //Retornar o resultado para a tela
                return new CommandResult(true, "Salvo com sucesso!", 200, new { Id = experimento.Id, Nome = experimento.Nome.ToString(), Status = experimento.Status });
            }
            catch (Exception e)
            {
                return new CommandResult(e);
            }
        }

        public ICommandResult HandlerUpdate(CriarExperimentoCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult HandlerDelete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
