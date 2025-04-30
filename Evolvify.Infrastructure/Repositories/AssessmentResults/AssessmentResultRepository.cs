using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Interfaces.AssessmentResultInterface;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Repositories.AssessmentResultRepository
{
    internal class AssessmentResultRepository : IAssessmentResultRepository
    {
        private readonly EvolvifyDbContext _context;
        
        public AssessmentResultRepository(EvolvifyDbContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(IEnumerable<AssessmentResult> assessmentResults)
        {
            await _context.AssessmentResults.AddRangeAsync(assessmentResults);            
        }
        
        public async Task<IEnumerable<AssessmentResult>> GetAllByUserId(string userId)
        {
            return await _context.AssessmentResults
                .Where(x => x.UserId == userId).ToListAsync();
                
        }

    }
    
}
