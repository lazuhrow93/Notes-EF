using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Note.Data.Database;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);


//db context
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<NoteDbContext>(options =>
    options.UseSqlServer(connectionString));



using IHost host = builder.Build();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
