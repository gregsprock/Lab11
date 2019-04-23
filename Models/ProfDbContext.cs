using Microsoft.EntityFrameworkCore;

namespace Lab11.Models
{
	public class ProfDbContext : DbContext
	{
		public ProfDbContext (DbContextOptions<ProfDbContext> options)
			: base(options)
		{
		}
		public DbSet<Professor> Professor {get; set;}
	}
}