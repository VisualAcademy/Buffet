using Hawaso.Models.Candidates.CandidatesIncomes;
using Hawaso.Models.Candidates.CandidatesNames;
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

        // DbSet of T 형태의 컬렉션 속성을 사용하여 모델(도메인)에 해당하는 테이블 생성
        public DbSet<Candidate> Candidates { get; set; } = null!;

        public DbSet<CandidateName> CandidatesNames { get; set; } = null!;
        
        public DbSet<CandidateIncome> CandidatesIncomes { get; set; } = null!;
    }
}
