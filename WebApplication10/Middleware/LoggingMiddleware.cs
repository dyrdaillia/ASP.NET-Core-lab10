using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string controllerName = context.Request.RouteValues["controller"].ToString();
        string actionName = context.Request.RouteValues["action"].ToString();
        string logMessage = $"[{DateTime.UtcNow.ToString()}] {controllerName}/{actionName} was called.\n";

        await WriteToLogFile(logMessage);

        await _next(context);
    }

    private async Task WriteToLogFile(string logMessage)
    {
        string filePath = "log.txt";
        await File.AppendAllTextAsync(filePath, logMessage);
    }
}