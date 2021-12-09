using API;
using API.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.ConfigureWebHostDefaults(builder =>
{
    builder.UseStartup<Startup>();
});

var host = hostBuilder.Build();

host.Seed();

host.Run();