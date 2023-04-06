using Microsoft.EntityFrameworkCore;
using Roulette.Entities;

namespace Roulette.Helpers
{
	public class DataContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public DataContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite(Configuration.GetConnectionString("RouletteDatabase"));
		}

		public DbSet<Bet> Bets { get; set; }
		public DbSet<PlaceTypeCombination> PlaceTypeCombinations { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Spin> Spins { get; set; }
	}
}
