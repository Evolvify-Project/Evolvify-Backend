using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Querys.GetSkillsById
{
    public record GetSkillsByIdQuery(int Id) : IRequest<SkillDto>;

}
