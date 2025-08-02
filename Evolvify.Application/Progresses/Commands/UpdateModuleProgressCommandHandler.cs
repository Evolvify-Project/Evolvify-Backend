using Evolvify.Application.Common.User;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Progresses.Commands
{
    public class UpdateModuleProgressCommandHandler : IRequestHandler<UpdateModuleProgressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        public UpdateModuleProgressCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task Handle(UpdateModuleProgressCommand request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Modules.ModuleExistsAsync(request.ModuleId))
                throw new NotFoundException($"Module with ID {request.ModuleId} not found.");
            var user = _userContext.GetCurrentUser().Id;


            var module = await _unitOfWork.Repository<Module,int >().GetByIdAsync(request.ModuleId);
            await _unitOfWork.Progress.UpdateModuleProgressAsync(user, request.ModuleId, request.IsCompleted);
            await _unitOfWork.Progress.UpdateCourseProgressAsync(user, module.CourseId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
