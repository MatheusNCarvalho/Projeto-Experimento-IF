using IFExperiment.Domain.ExperimentContext.Commands.TratamentoCommands.Input;
using IFExperiment.Domain.ExperimentContext.Handlers;
using IFExperiment.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IFExperiment.Api.Controllers
{
    public class TratamentoController : Controller
    {

        private readonly TratamentoHandler _tratamentoHandler;

        public TratamentoController(TratamentoHandler tratamentoHandler)
        {

            _tratamentoHandler = tratamentoHandler;
        }

        [HttpPost]
        [Route("v1/tratamentos")]
        public ICommandResult Post([FromBody]TratamentoCommand command)
        {
            var result = _tratamentoHandler.Handler(command);
            return result;
        }


    }
}