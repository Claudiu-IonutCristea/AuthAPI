using AuthAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Data;

public class DataContextDevelopment : DataContext
{
	public DataContextDevelopment(IConfiguration config) : base(config) {}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
	}
}
