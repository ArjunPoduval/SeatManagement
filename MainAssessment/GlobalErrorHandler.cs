using MainAssessment.CustomException;
using MainAssessment.Exceptions;
using System.Net;
using System.Text.Json;


public class GlobalErrorHandler
{
    private readonly RequestDelegate _next;


    public GlobalErrorHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ObjectDoNotExist ex)
        {
            await ObjectDoNotExist(httpContext, ex);
        }

        catch (ObjectAlreadyExistException ex)
        {
            await ObjectAlreadyExistExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task ObjectDoNotExist(HttpContext httpContext, ObjectDoNotExist ex)
    {
        httpContext.Response.ContentType = "application/json";
        HttpResponse response = httpContext.Response;

        var errorResponse = new
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = ex.Message,
            Success = false
        };

        response.StatusCode = (int)HttpStatusCode.BadRequest;

        string result = JsonSerializer.Serialize(errorResponse);
        await httpContext.Response.WriteAsync(result);
    }

    private async Task ObjectAlreadyExistExceptionAsync(HttpContext httpContext, ObjectAlreadyExistException ex)
    {
        httpContext.Response.ContentType = "application/json";
        HttpResponse response = httpContext.Response;

        var errorResponse = new
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = ex.Message,
            Success = false
        };

        response.StatusCode = (int)HttpStatusCode.BadRequest;

        string result = JsonSerializer.Serialize(errorResponse);
        await httpContext.Response.WriteAsync(result);
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpResponse response = context.Response;

        var errorResponse = new
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
            Message = "Internal server error!*",
            Success = false
        };

        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        string result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }

}

