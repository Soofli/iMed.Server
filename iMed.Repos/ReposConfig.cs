global using iMed.Common.Models;
global using iMed.Repos.Interfaces;
global using iMed.Common.Models.Entity;
global using iMed.Repos.BaseRepositories.Contracts;
global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using iMed.Domain.Entities;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.Extensions.DependencyInjection;
global using Pluralize.NET;
global using iMed.Repos.Extensions;
global using iMed.Common.Extensions;
global using iMed.Repos.Models;
global using System.Linq.Expressions;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.AspNetCore.Builder;
global using iMed.Repos.Services.Contracts;
global using iMed.Repos.BaseRepositories;
global using iMed.Repos.Repositories.Contracts;
global using System.Threading;
global using iMed.Common.Models.Api;
global using iMed.Common.Models.Exception;
global using iMed.Domain.Dtos.SmalDtos;
global using iMed.Domain.Mappers;












namespace iMed.Repos;

public static class ReposConfig
{
    public static async Task ReposInit(this IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var identityDbInitialize = scope.ServiceProvider.GetService<IDbInitializerService>();
            if (identityDbInitialize != null)
            {
                identityDbInitialize.Initialize();
                await identityDbInitialize.SeedDate();
            }
        }
    }
}