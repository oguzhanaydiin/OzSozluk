using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Infrastructure.Persistence.Context;
using OzSozluk.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzSozluk.Infrastructure.Persistence.Extensions;

public static class Registiration
{
    public static IServiceCollection AddInfrastructureRegistiration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OzSozlukContext>(conf =>
        {
            var connectionString = configuration["OzSozlukDbConnectionString"].ToString();
            conf.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
