using System;
using System.Threading.Tasks;
using IFExperiment.Domain.ExperimentContext.Commands.Handlers;
using IFExperiment.Domain.ExperimentContext.Commands.Input;
using IFExperiment.Domain.ExperimentContext.Filter;
using IFExperiment.Infra.Transacao;
using Microsoft.AspNetCore.Mvc;

namespace IFExperiment.Api.Controllers
{
    public class TratamentoController : BaseController
    {

        private readonly TratamentoHandler _tratamentoHandler;
        private readonly TratamentoOutputHandler _tratamentoOutputHandler;

        public TratamentoController(IUow uow, TratamentoHandler tratamentoHandler, TratamentoOutputHandler tratamentoOutputHandler)
        : base(uow)
        {
            _tratamentoOutputHandler = tratamentoOutputHandler;
            _tratamentoHandler = tratamentoHandler;
        }


        /// <summary>
        /// Filtro de Tratamento
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/tratamentos")]
        public async Task<IActionResult> Get([FromQuery] TratamentoFiltro filtro)
        {
            var result = _tratamentoOutputHandler.GetFiltro(filtro);
            return await GetResponse(result, _tratamentoOutputHandler.Notifications);
        }

        /// <summary>
        /// Busca Tratamento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/tratamentos/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _tratamentoOutputHandler.GetById(id);
            return await GetResponse(result, _tratamentoOutputHandler.Notifications);
        }

        /// <summary>
        /// Cria um novo tratamento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/tratamentos")]
        public async Task<IActionResult> Post([FromBody]TratamentoCommand command)
        {
            var result = _tratamentoHandler.HandlerCreate(command);
            return await Response(result, _tratamentoHandler.Notifications);
        }


        /// <summary>
        /// Atualiza um tratamento existente
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/tratamentos")]
        public async Task<IActionResult> Put([FromBody]TratamentoCommand command)
        {
            var result = _tratamentoHandler.HandlerUpdate(command);
            return await Response(result, _tratamentoHandler.Notifications);
        }


        /// <summary>
        /// Apaga um tratamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/tratamentos/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _tratamentoHandler.HandlerDelete(id);
            return await Response(result, _tratamentoHandler.Notifications);
        }

    }
}