namespace SourDictionary.Api.WebApi.Controllers.Infrastructure.ActionFilters
{
    public class ValidateModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState.Values.SelectMany(modelStateEntry => modelStateEntry.Errors)
                                                        .Select(modelError => !string.IsNullOrEmpty(modelError.ErrorMessage) ?
                                                                modelError.ErrorMessage : modelError.Exception?.Message)
                                                        .Distinct().ToList();


                return;
            }

            await next();
        }
    }
}
