﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Infrastructure.Persistence.Context;
using OzSozluk.Infrastructure.Persistence.Repositories;

namespace OzSozluk.Infrastructure.Persistence.Extensions;

public static class Registration
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
        services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();

        return services;
    }
}
