using Newtonsoft.Json;

namespace Rule4.CustomMiddleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Обработка исключения и формирование пользовательского сообщения об ошибке
                string errorMessage = $"{ex.Message}";

                // Формирование ответа с пользовательским сообщением об ошибке
                context.Response.StatusCode = 500; // Установка соответствующего статуса ошибки (например, 500 Internal Server Error)
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = errorMessage }));
            }
        }
    }
}
