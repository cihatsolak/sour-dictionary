namespace SourDictionary.Api.WebApi.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder ConfigureExceptionHandling(this IApplicationBuilder app,
            bool includeExceptionDetails = false,
            bool useDefaultHandlingResponse = true,
            Func<HttpContext, Exception, Task> handleException = null)
        {
            app.Run(context =>
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (!useDefaultHandlingResponse && handleException is null)
                    throw new ArgumentNullException(nameof(handleException), $"{nameof(handleException)} cannot be null when {nameof(useDefaultHandlingResponse)} is false");

                if (!useDefaultHandlingResponse && handleException is not null)
                    return handleException(context, exceptionHandlerFeature.Error);

                return DefaultHandleExceptionAsync(context, exceptionHandlerFeature.Error, includeExceptionDetails);
            });

            return app;
        }

        private static async Task DefaultHandleExceptionAsync(HttpContext context, Exception exception, bool includeExceptionDetails)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = "Internal server error occured!";

            if (exception is UnauthorizedAccessException)
                statusCode = HttpStatusCode.Unauthorized;

            if (exception is DatabaseValidationException)
            {
                ValidationResponseModel validationResponse = new(exception.Message);
                await WriteResponse(context, statusCode, validationResponse);
                return;
            }

            var response = new
            {
                HttpStatusCode = (int)statusCode,
                Detail = includeExceptionDetails ? exception.ToString() : message
            };

            await WriteResponse(context, statusCode, response);
        }

        private static async Task WriteResponse(HttpContext context, HttpStatusCode statusCode, object responseObject)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(responseObject);
        }
    }
}
