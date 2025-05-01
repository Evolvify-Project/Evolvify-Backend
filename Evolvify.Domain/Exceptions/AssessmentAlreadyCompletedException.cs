using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Exceptions
{
    public class AssessmentAlreadyCompletedException:Exception
    {
        public object ExistingResult { get; set; }

        public AssessmentAlreadyCompletedException(object existingResult):base("Assessment already completed. You cannot retake the assessment.")
        {
            ExistingResult = existingResult;
        }
        
    }
}
