using Microsoft.EntityFrameworkCore;

namespace XXXXX-ProjectName.Models
{
	public class XXXXX-ProjectNameContext : DbContext
	{
		//public virtual DbSet<XXXXX-ProjectName> XXXXX-ModelParentName { get; set; }
		//public virtual DbSet<XXXXX-ProjectName> XXXXX-ModelChildName { get; set; }

		public XXXXXContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}