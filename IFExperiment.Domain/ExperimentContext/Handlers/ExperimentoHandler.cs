using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Commands.ExperimentoCommands.Input;
using IFExperiment.Domain.ExperimentContext.Commands.Outputs;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Handlers
{
    public class ExperimentoHandler : 
        Notifiable,
        ICommandHandler<CriarExperimentoCommand>
    {

        public ICommandResult Handler(CriarExperimentoCommand command)
        {

            try
            {
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
                    //busco no banco pelo tratamento
                    //experimento.AddTratamento(new ExperimentoTramento(experimento, tramento));
                }

                experimento.Gerar();

                //Validar entidades e VOs
                AddNotifications(experimento.Notifications);
                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija os campos abaixo", 400, Notifications);

                //Persistir experimento

                //Retornar o resultado para a tela
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                return new CommandResult(e);
            }
        }
    }
}
