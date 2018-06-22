using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidator;
using IFExperiment.Infra.Transacao;
using IFExperiment.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IFExperiment.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        sucess = true,
                        data = result
                    });
                }
                catch (Exception e)
                {
                    //Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        sucess = false,
                        errors = e
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    sucess = false,
                    errors = notifications
                });
            }
        }

        public async Task<IActionResult> GetResponse(ICommandResult result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    return Ok(new
                    {
                        sucess = true,
                        result
                    });
                }
                catch (Exception e)
                {
                    //Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        sucess = false,
                        errors = e
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    sucess = false,
                    errors = notifications
                });
            }
        }

        public async Task<IActionResult> Response(object result)
        {

            try
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }
            catch (Exception e)
            {
                //Logar o erro (Elmah)
                return BadRequest(new
                {
                    sucess = false,
                    errors = e
                });
            }
        }

    }
}
