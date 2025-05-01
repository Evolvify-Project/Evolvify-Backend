using Evolvify.Domain.Entities.Assessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces.AssessmentResultInterface
{
    public interface IAssessmentResultRepository
    {
        Task AddRangeAsync(IEnumerable<AssessmentResult> assessmentResults);
        Task<IEnumerable<AssessmentResult>> GetAllByUserId(string userId);
        
    }
}
