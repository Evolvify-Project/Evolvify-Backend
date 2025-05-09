using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Courses
{
    public class CourseSpecification:BaseSpecification<Course,int>
    {
        public CourseSpecification(string? sort)
        {
            ApplyInclude();
            ApplySort(sort?.ToLower());
        }
        public CourseSpecification(int id):base(C=>C.Id==id) 
        {
            ApplyInclude();
        }
        public CourseSpecification(int skillId, Level level) : base(C => C.SkillId == skillId && C.Level == level)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(C => C.Skill);
            AddInclude(C => C.Modules);
            AddInclude($"{nameof(Course.Modules)}.{nameof(Module.Contents)}");
        }

        private void ApplySort(string? sort)
        {
            if (!sort.IsNullOrEmpty())
            {
                switch (sort)
                {
                    case "newest":
                        AddOrderByDescending(x => x.CreatedAt);
                        break;
                    case "duration":
                        AddOrderByDescending(x=>x.Duration);
                        break;
                    default:
                        AddOrderBy(x=>x.Title);
                    break;
                }
            }
            else
            {
                AddOrderBy(x => x.Title);
            }
        }
    }
}
