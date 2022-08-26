using Microsoft.EntityFrameworkCore;

namespace Hawaso.Models.Candidates
{
    public class CandidateAppDbContext : DbContext
    {
        public CandidateAppDbContext() : base()
        {
            // Empty
        }

        public CandidateAppDbContext(DbContextOptions<CandidateAppDbContext> options) 
            : base(options)
        {
            // Empty
        }
    }
}
