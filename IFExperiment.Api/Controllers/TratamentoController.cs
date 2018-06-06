using System;
using IFExperiment.Domain.ExperimentContext.Commands.TratamentoCommands.Input;
using IFExperiment.Domain.ExperimentContext.Handlers;
using IFExperiment.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IFExperiment.Api.Controllers
{
    public class TratamentoController : Controller
    {

        private readonly TratamentoHandler _tratamentoHandler;
        private readonly TratamentoOutputHandler _tratamentoOutputHandler;

        public TratamentoController(TratamentoHandler tratamentoHandler, TratamentoOutputHandler tratamentoOutputHandler)
        {
            _tratamentoOutputHandler = tratamentoOutputHandler;
            _tratamentoHandler = tratamentoHandler;
        }


        [HttpGet]
        [Route("v1/tratamentos")]
        public ICommandResult Get()
        {
            return _tratamentoOutputHandler.Get();
        }

        [HttpGet]
        [Route("v1/tratamentos/{id}")]
        public ICommandResult Get(Guid id)
        {
            return _tratamentoOutputHandler.GetById(id);
        }


        [HttpPost]
        [Route("v1/tratamentos")]
        public ICommandResult Post([FromBody]TratamentoCommand command)
        {
            var result = _tratamentoHandler.HandlerCreate(command);
            return result;
        }


        [HttpPut]
        [Route("v1/tratamentos")]
        public ICommandResult Put([FromBody]TratamentoCommand command)
        {
            var result = _tratamentoHandler.HandlerUpdate(command);
            return result;
        }


        [HttpDelete]
        [Route("v1/tratamentos/{id}")]
        public ICommandResult Delete(Guid id)
        {
            return _tratamentoHandler.HandlerDelete(id);
        }


    }
}