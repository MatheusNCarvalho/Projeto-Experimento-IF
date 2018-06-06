using IFExperiment.Domain.ExperimentContext.Commands.ExperimentoCommands.Input;
using IFExperiment.Domain.ExperimentContext.Handlers;
using IFExperiment.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IFExperiment.Api.Controllers
{
    public class ExperimentoController : Controller
    {

        private readonly ExperimentoHandler _experimentoHandler;

        public ExperimentoController(ExperimentoHandler experimentoHandler)
        {
            _experimentoHandler = experimentoHandler;
        }

        /// <summary>
        /// Criando um Experimento
        /// </summary>
        /// <remarks>Descricao do campo Status 0 = Aberto, 1 = Em Adamento, 2 = Concluido, 3 = Cancelado </remarks>
        [HttpPost]
        [Route("v1/experimentos")]
        public ICommandResult Post([FromBody]CriarExperimentoCommand command)
        {
            var result = _experimentoHandler.HandlerCreate(command);
            return result;
        }
    }
}