using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
	public class FactoryContext : DbContext
	{
		//public virtual DbSet<FactoryContext> XXXXX-Model1Name { get; set; }
		//public virtual DbSet<FactoryContext> XXXXX-Model2Name { get; set; }

		public FactoryContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}