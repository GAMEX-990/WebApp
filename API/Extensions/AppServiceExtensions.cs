﻿using api;
using API.Data;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class AppServiceExtensions
{
  public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration conf)
  {
    services.AddDbContext<DataContext>(opt =>
    {
      opt.UseSqlite(conf.GetConnectionString("SqliteConnection"));
    });
    services.AddCors();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IlikesRepository, LikesRepository>();
    services.AddScoped<IImageService, ImageService>();
    services.AddScoped<LogUserActivity>();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.Configure<CloudinarySettings>(conf.GetSection("CloudinarySettings"));

    return services;
  }
}