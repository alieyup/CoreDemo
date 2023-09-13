using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=AB60013-1571;database=CoreBlogApiDb;integrated security=true;TrustServerCertificate=True");
			//  optionsBuilder.UseSqlServer("server=ALI\\SQLEXPRESS;database=CoreBlogDb;integrated security=true;TrustServerCertificate=True");
		}
        public DbSet<Employee> Employees { get; set; }
    }
}
