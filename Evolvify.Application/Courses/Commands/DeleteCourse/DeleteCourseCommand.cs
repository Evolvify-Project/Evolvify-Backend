﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
