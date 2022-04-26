using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzSozluk.Infrastructure.Persistence.Context;
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

        return services;
    }
}
