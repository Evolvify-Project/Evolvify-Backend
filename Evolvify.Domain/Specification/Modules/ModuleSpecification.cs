using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Modules
{
    public class ModuleSpecification:BaseSpecification<Module,int>
    {
        public ModuleSpecification()
        {
            ApplyInclude();
        }

        public ModuleSpecification(int id):base(M=>M.Id==id)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(M => M.Contents);
            
        }

    }
}
