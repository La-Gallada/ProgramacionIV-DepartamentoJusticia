using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DepartamentoJusticia.Controllers;

public class ControladorBase : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (HttpContext.Session.GetString("Username") == null)
        {
            context.Result = Redirect("/Login");
        }

        base.OnActionExecuting(context);
    }
}
