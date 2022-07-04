using Medic.Services.Exceptions;
using Newtonsoft.Json;

namespace Medic.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _request;

    public ExceptionMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
    {
        try
        {
            await _request(context);
        }
        catch (HttpException ex)
        {
            await HandleException(context, ex, env);
        }
    }

    private async Task HandleException(HttpContext context, HttpException ex, IWebHostEnvironment env)
    {
        context.Response.StatusCode = ex.StatusCode;

        if (env.IsDevelopment())
        {
            await context.Response.WriteAsJsonAsync(new
            {
                error = ex.Message,
                stack = ex.StackTrace,
                innerException = ex.InnerException,
            });

            return;
        }
        
        await context.Response.WriteAsJsonAsync(new
        {
            error = ex.Message,
        });
    }
}