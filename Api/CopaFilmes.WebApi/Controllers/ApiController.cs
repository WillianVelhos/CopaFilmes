using CopaFilmes.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected List<Notification> Notifications = new List<Notification>();

        protected new IActionResult Response(object response = null)
        {
            if (!Notifications.Any())
            {
                return Ok(new
                {
                    success = true,
                    data = response
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = Notifications.Select(x => x.Message)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(erroMsg);
            }
        }

        protected void NotifyError(string message)
        {
            Notifications.Add(new Notification(message));
        }
    }
}
