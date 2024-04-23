using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<UpdatesService>();
builder.Services
    .AddCors(options
        => options.AddPolicy(
            name: "cors",
            configurePolicy: policyBuilder =>
            {
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyOrigin();
            }));

await using var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.MapGet(
    pattern: "/sse",
    handler: async (UpdatesService service, HttpContext context) =>
    {
        context.Response.Headers.Add("Content-Type", "text/event-stream");
        context.Response.Headers.Add("Cache-Control", "no-cache");
        context.Response.Headers.Add("Connection", "keep-alive");

        while (!context.RequestAborted.IsCancellationRequested)
        {
            var update = await service.WaitForNewItem();
            await context.Response.WriteAsync($"update: ");
            await JsonSerializer.SerializeAsync(context.Response.Body, update);
            await context.Response.WriteAsync($"\n\n");
            await context.Response.Body.FlushAsync();
            service.Reset();
        }
    });

await app.RunAsync();