using System;
using System.Threading.Tasks;
using IFExperiment.Domain.ExperimentContext.Commands.Handlers;
using IFExperiment.Domain.ExperimentContext.Commands.Input;
using IFExperiment.Domain.ExperimentContext.Filter;
using IFExperiment.Infra.Transacao;
using Microsoft.AspNetCore.Mvc;

namespace IFExperiment.Api.Controllers
{

    public class ExperimentoController : BaseController
    {

        private readonly ExperimentoHandler _experimentoHandler;
        private readonly ExperimentoOutputHandler _experimentoOutputHandler;

        public ExperimentoController(IUow uow, ExperimentoHandler experimentoHandler, ExperimentoOutputHandler experimentoOutputHandler) : base(uow)
        {
            _experimentoHandler = experimentoHandler;
            _experimentoOutputHandler = experimentoOutputHandler;
        }



        [HttpGet]
        [Route("v1/experimentos/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _experimentoOutputHandler.GetById(id);
            return await GetResponse(result, _experimentoOutputHandler.Notifications);
        }

        [HttpGet]
        [Route("v1/experimentos")]
        public async Task<IActionResult> Get([FromQuery] ExperimentoFiltro filtro)
        {
            var result = _experimentoOutputHandler.Get(filtro);
            return await GetResponse(result, _experimentoOutputHandler.Notifications);
        }

        /// <summary>
        /// Criando um Experimento
        /// </summary>
        /// <remarks>Descricao do campo Status 0 = Aberto, 1 = Em Adamento, 2 = Concluido, 3 = Cancelado </remarks>
        /// 
        [HttpPost]
        [Route("v1/experimentos")]
        public async Task<IActionResult> Post(CriarExperimentoCommand command)
        {
            var result = _experimentoHandler.HandlerCreate(command);
            return await Response(result, _experimentoHandler.Notifications);
        }


    }
}