#region CommunityController Usings
global using Evolvify.Application.Community.Comments.Commands;
global using Evolvify.Application.Community.Comments.Commands.CreateComment;
global using Evolvify.Application.Community.Comments.Commands.DeleteComment;
global using Evolvify.Application.Community.Comments.Commands.UpdateComment;
global using Evolvify.Application.Community.Comments.DTOs;
global using Evolvify.Application.Community.Comments.Queries.GetAllCommentForPost;
global using Evolvify.Application.Community.Likes.OnComment;
global using Evolvify.Application.Community.Likes.OnPost;
global using Evolvify.Application.Community.Posts.Commands.CreatePost;
global using Evolvify.Application.Community.Posts.Commands.DeletePost;
global using Evolvify.Application.Community.Posts.Commands.UpdatePost;
global using Evolvify.Application.Community.Posts.Queries.GetAllPosts;
global using Evolvify.Application.Community.Posts.Queries.GetPostQuery;
global using Evolvify.Application.Community.Replies.Commands.AddReply;
global using Evolvify.Application.Community.Replies.Queries;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
#endregion

#region AccountsController Usings
global using Evolvify.Application.Identity.ForgetPassword;
global using Evolvify.Application.Identity.Login;
global using Evolvify.Application.Identity.Register;
global using Evolvify.Application.Identity.ResetPassword;
global using Evolvify.Application.Identity.UserProfile.Commands.UpdateProfileImage;
global using Evolvify.Application.Identity.UserProfile.Queries.ProfileImage;
global using Evolvify.Application.Identity.UserProfile.Queries.UserProfile;
#endregion

#region AssessmentsController Usings
global using Evolvify.Application.Assessment.Commands;
global using Evolvify.Application.Assessment.Queries.AssessmentResult;
global using Evolvify.Application.Assessment.Queries.Questions;
global using Evolvify.Domain.Entities.Assessment;
#endregion

#region CoursesController Usings
global using Evolvify.Application.Assessment.Queries.RecommendedCourses;
global using Evolvify.Application.Courses.Queries.GetAll;
global using Evolvify.Application.Courses.Queries.GetById;
#endregion

#region ModulesController Usings
global using Evolvify.Application.Modules.Command.CreateModule;
global using Evolvify.Application.Modules.Command.DeleteModule;
global using Evolvify.Application.Modules.Command.UpdateModule;
global using Evolvify.Application.Modules.Queries.GetAll;
global using Evolvify.Application.Modules.Queries.GetById;
#endregion

#region PaymentsController Usings
global using Evolvify.Application.Services.AppSubscription;
global using Evolvify.Application.Services.Payment;
global using Evolvify.Application.Services.Payment.PaymentService;
global using Microsoft.Extensions.Options;
global using Stripe;

#endregion


