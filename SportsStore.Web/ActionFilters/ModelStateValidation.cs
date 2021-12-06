using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SportsStore.LoggerService.Interfaces;
using System.Linq;

namespace SportsStore.Web.ActionFilters
{
    public class ModelStateValidation : IActionFilter
    {
        private readonly ILoggerMessage _logger;

        public ModelStateValidation(ILoggerMessage logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
            if (param == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller}, action: { action} ");
                context.Result = new BadRequestObjectResult($"Object is null. Controller: { controller }, action: { action} ");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller: { controller}, action: { action} ");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        //[ServiceFilter(typeof(ModelStateValidation))]

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
