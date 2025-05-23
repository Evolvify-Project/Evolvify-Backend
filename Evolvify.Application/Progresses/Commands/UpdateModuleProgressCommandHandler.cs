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
    public class UpdateModuleProgressCommandHandler : IRequestHandler<UpdateModuleProgressCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModuleProgressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateModuleProgressCommand request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Modules.ModuleExistsAsync(request.ModuleId))
                throw new NotFoundException($"Module with ID {request.ModuleId} not found.");

            var module = await _unitOfWork.Modules.GetByIdAsync(request.ModuleId);
            await _unitOfWork.Progress.UpdateModuleProgressAsync(request.UserId, request.ModuleId, request.IsCompleted);
            await _unitOfWork.Progress.UpdateCourseProgressAsync(request.UserId, module.CourseId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
