using Microsoft.EntityFrameworkCore;
using Note.Data.Database;
using Note.Data.Repository;
using Note.Domain;

namespace Note.App;

public static class Configuration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddScoped<IBookSync, BookSync>();
    }

    public static IServiceCollection AddData(this IServiceCollection services)
    {
        return services
            .AddScoped<IBookRepository, BookRepository>();
    }

    public static IServiceCollection AddDatabase(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("cant find db connection string");

        return builder
            .Services
            .AddDbContext<NoteDbContext>(opt => opt.UseSqlServer(connectionString));


    }
}
