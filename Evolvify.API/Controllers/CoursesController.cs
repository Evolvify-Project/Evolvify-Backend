using Evolvify.Application.Assessment.Queries.RecommendedCourses;
using Evolvify.Application.Assessment.Queries.RecommendedCourses.DTOs;
using Evolvify.Application.CompleteMedule;
using Evolvify.Application.Courses.Queries.GetAll;
using Evolvify.Application.Courses.Queries.GetById;
using Evolvify.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProgressService _progressService;
        public CoursesController(IMediator mediator , IProgressService progressService)
        {
            _mediator = mediator;
            _progressService = progressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllCoursesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _mediator.Send(new GetCourseByIdQuery(id));
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommendedCourses()
        {
            var result = await _mediator.Send(new GetRecommendedCoursesQuery());
            return Ok(result);
        }
        [HttpPost("complete-module")]
        public async Task<IActionResult> CompleteModule([FromBody] CompleteModuleRequest request)
        {
            var result = await _progressService.CompleteModuleAsync(request.Module_Id, request.Course_Id);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("progress/{courseId}")]
        public async Task<IActionResult> GetCourseProgress(int courseId)
        {
            var result = await _progressService.GetCourseProgressAsync(courseId);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

    }
}
