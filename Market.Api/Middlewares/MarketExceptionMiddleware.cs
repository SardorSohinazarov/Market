using Market.Service.Exceptions;

namespace Market.Api.Middlewares
{
    public class MarketExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public MarketExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (MarketException ex)
            {
                await HandleExceptionAsync(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, 500, ex.Message);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, int code , string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(
                new
                {
                    code = code,
                    message = message
                });
        }
    }
}
