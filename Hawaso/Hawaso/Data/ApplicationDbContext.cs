using Hawaso.Models.Buffets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hawaso.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Broth> Broths { get; set; }

        public DbSet<Noodle> Noodles { get; set; }

        public DbSet<Garnish> Garnishes { get; set; }

        /// <summary>
        /// 모델(테이블)이 생성될 때 처음 실행 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Broth>().HasData(
                new Broth() { Id = 1, Name = "콩국물", IsVegan = true },
                new Broth() { Id = 2, Name = "멸치국물", IsVegan = false });

            builder.Entity<Noodle>().HasData(
                new Noodle { Id = 1, Name = "콩국수", BrothId = 1 },
                new Noodle { Id = 2, Name = "잔치국수", BrothId = 2 }); 
        }
    }
}
