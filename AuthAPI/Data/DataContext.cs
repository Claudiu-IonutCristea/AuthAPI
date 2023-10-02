using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Data;

public class DataContext : DbContext
{
	protected readonly IConfiguration _config;

	public DataContext(IConfiguration config) : base()
	{
		_config = config;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
	}
}
