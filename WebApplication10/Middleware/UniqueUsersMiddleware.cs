using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class UniqueUsersMiddleware
{
    private readonly RequestDelegate _next;
    private static HashSet<string> uniqueUsers = new HashSet<string>();

    public UniqueUsersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string ipAddress = context.Connection.RemoteIpAddress.ToString();

        if (!uniqueUsers.Contains(ipAddress))
        {
            uniqueUsers.Add(ipAddress);
            await WriteToLogFile($"[{DateTime.UtcNow.ToString()}] New user from {ipAddress}\n");
        }

        await _next(context);
    }

    private async Task WriteToLogFile(string logMessage)
    {
        string filePath = "unique_users_log.txt";
        await File.AppendAllTextAsync(filePath, logMessage);
    }
}
