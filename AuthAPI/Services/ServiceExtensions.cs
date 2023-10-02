using AuthAPI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Services;

public static class ServiceExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration config, IWebHostEnvironment env)
	{
		//service.AddScoped<IRefreshTokenService, RefreshTokenService>();
		//service.AddScoped<IAccessTokenService, AccessTokenService>();
		//service.AddScoped<IDeviceService, DeviceService>();

		//service.AddScoped<IAuthentificationService, AuthentificationService>();

		if(env.IsDevelopment())
		{
			service.AddDbContext<DataContext, DataContextDevelopment>();
		}
		else
		{
			service.AddDbContext<DataContext>();
		}

		return service;
	}
}
