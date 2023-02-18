global using Autofac.Extensions.DependencyInjection;
global using iMed.Server.WebFramework.Configurations;
global using Serilog;
global using iMed.Common.Extensions;
global using iMed.Common.Models.Api;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using Microsoft.AspNetCore.Mvc.Filters;
global using iMed.Server.WebFramework.MiddleWares;
global using System.Linq.Expressions;
global using iMed.Common.Models.Entity;
global using iMed.Common.Models.Mapper;
global using iMed.Repos.BaseRepositories.Contracts;
global using iMed.Server.WebFramework.Bases;
global using Mapster;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using iMed.Infrastructure.Models;
global using Serilog.Events;
global using Serilog.Sinks.ElmahIo;
global using Serilog.Sinks.SystemConsole.Themes;
global using Microsoft.AspNetCore.Identity;
global using System.Text;
global using iMed.Domain.Entities;
global using iMed.Repos.Extensions;
global using iMed.Repos.Models;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Mvc.Authorization;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using iMed.Common.Models.Exception;
global using Newtonsoft.Json.Serialization;
global using iMed.Domain.Dtos.SmalDtos;
global using Autofac;
global using iMed.Common.Models;
global using iMed.Core;
global using iMed.Infrastructure;
global using iMed.Repos;
global using iMed.Repos.Interfaces;
global using iMed.Domain.Dtos.LargDtos;
global using iMed.Core.Services.Contracts;
global using System.Security.Claims;
global using iMed.Domain.Dtos.RequestDto;
global using iMed.Infrastructure.Models.RestApi;
global using iMed.Domain.Mappers;
global using System.Diagnostics;
global using iMed.Repos.Repositories.Contracts;





namespace iMed.Server;

public class ServerConfig
{
    
}