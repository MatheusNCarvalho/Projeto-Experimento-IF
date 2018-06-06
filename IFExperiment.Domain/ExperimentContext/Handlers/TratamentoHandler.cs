using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.BaseCommand.Outputs;
using IFExperiment.Domain.ExperimentContext.Commands.TratamentoCommands.Input;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Handlers
{
    public class TratamentoHandler :
        Notifiable,
        ICommandHandler<TratamentoCommand>
    {
        private readonly ITratamentoRepository _tratamentoRepository;

        public TratamentoHandler(ITratamentoRepository tratamentoRepository)
        {
            _tratamentoRepository = tratamentoRepository;
        }

        public ICommandResult HandlerCreate(TratamentoCommand command)
        {

            try
            {
                command.Validated();
                AddNotifications(command.Notifications);
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                //Criar VOs
                var nome = new Nome(command.Nome);

                //criar entidades
                var tratamento = new Tratamento(nome);
                tratamento.Ativo();
                //validar entidades

                tratamento.Validated();
                AddNotifications(tratamento.Notifications);
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                _tratamentoRepository.Save(tratamento);

                return new CommandResult(true, "Salvo com sucesso!", 200, new { Id = tratamento.Id, Nome = tratamento.Nome.ToString(), Status = tratamento.Status });


            }
            catch (Exception e)
            {
                return new CommandResult(e);
            }

        }

        public ICommandResult HandlerUpdate(TratamentoCommand command)
        {
            try
            {
                command.Validated();
                AddNotifications(command.Notifications);
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                //Criar VOs
                var nome = new Nome(command.Nome);

                //criar entidades
                var tratamento = new Tratamento(nome);
                tratamento.Ativo();
                //validar entidades

                tratamento.Validated();
                tratamento.AddDataAlteracao(DateTime.Now);
                AddNotifications(tratamento.Notifications);
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                _tratamentoRepository.Update(tratamento);

                return new CommandResult(true, "Atualizado com sucesso!", 200, new { Id = tratamento.Id, Nome = tratamento.Nome.ToString(), Status = tratamento.Status });


            }
            catch (Exception e)
            {
                return new CommandResult(e);
            }
        }

        public ICommandResult HandlerDelete(Guid command)
        {
            try
            {
                _tratamentoRepository.Delete(command);

                return new CommandResult(true, "Apagado com sucesso", 200, null);

            }
            catch (Exception e)
            {
                return new CommandResult(e);
            }
        }
    }
}
