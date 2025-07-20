# Evolvify: Soft Skills Development Platform

## Overview

Evolvify is a graduation project designed to create a robust platform for developing essential soft skills, such as communication, teamwork, time management, and problem-solving. By leveraging modern technologies, Evolvify offers an engaging, personalized learning experience to address the shortcomings of traditional soft skills training. The platform combines interactive content, AI-driven insights, and a collaborative community to foster professional growth in dynamic workplaces. Built with a modular, scalable backend , Evolvify ensures a seamless and impactful user journey.


## Key Features

- **Skill Assessment Quiz**: Diagnostic quiz to evaluate users’ skill levels and generate personalized learning plans.
- **Personalized Learning Path**: Tailored content recommendations based on individual needs and career goals.
- **Interactive Content Library**: Diverse resources including videos, articles, PDFs, and practical assignments for hands-on learning.
- **User Dashboard**: Tracks progress, recent activity, and learning goals for a clear, motivating experience.
- **AI-Powered Chatbot**: Provides real-time guidance, answers queries, and recommends relevant content.
- **Community Forum**: Enables users to share insights, discuss challenges, and collaborate, fostering peer-to-peer learning.
- **Course & Skill Management**: CRUD operations for courses, skills, modules, and quizzes, with personalized recommendations.
- **Payment Integration**: Stripe-powered subscription management for premium features.
- **Progress Tracking**: Monitors user progress across courses and modules with visual milestones and rewards.

## Solution Structure

- **Evolvify.API**: ASP.NET Core Web API exposing endpoints for frontend and external clients.
- **Evolvify.Application**: Business logic, application services, and CQRS with MediatR.
- **Evolvify.Domain**: Core domain models, entities, enums, and interfaces.
- **Evolvify.Infrastructure**: Data access, EF Core context, repositories, and integrations (e.g., Stripe, email).

## Detailed Features

### Backend Features

- **User Authentication & Authorization**: JWT-based auth, registration, password reset, and role-based access (Admin/User).
- **Course Management**: CRUD operations for courses with personalized recommendations.
- **Skill Management**: CRUD operations for skills linked to courses and user progress.
- **Module Management**: CRUD operations for course modules.
- **Quiz Management**: Create, update, and track quizzes, questions, and user attempts with result calculation.
- **Assessment System**: AI-integrated skill assessments with personalized course recommendations.
- **Community Features**: Posts, comments, replies, and likes for social interaction.
- **Payment & Subscription**: Stripe integration for subscriptions and webhook handling.
- **Email Notifications**: Registration, password reset, and user notifications via MailKit.
- **Background Jobs**: Hangfire for scheduled tasks and seeding.
- **API Documentation**: Swagger UI for interactive endpoint testing.

## API Endpoints (Examples)

### Accounts
- `POST /api/accounts/register` — Register a new user
- `POST /api/accounts/login` — User login
- `GET /api/accounts/userProfile` — Get user profile (JWT required)

### Courses
- `GET /api/courses` — List all courses
- `GET /api/courses/{id}` — Get course by ID
- `GET /api/courses/recommended` — Get recommended courses (JWT required)

### Skills
- `GET /api/skills` — List all skills
- `POST /api/skills` — Create a new skill (Admin only)

### Quizzes
- `GET /api/quiz` — List all quizzes
- `POST /api/quiz` — Create a new quiz (Admin only)

### Assessments
- `POST /api/assessments/submit-answers` — Submit assessment answers (JWT required)
- `GET /api/assessments/Result` — Get assessment results (JWT required)

### Community
- `POST /api/community/Post` — Create a post (JWT required)
- `POST /api/community/Post/{id}/Comment` — Add comment to a post (JWT required)

### Payments
- `POST /api/payment/create-subscription` — Create a Stripe subscription (JWT required)
- `GET /api/payment/subscription-status` — Get subscription status (JWT required)

## Technologies Used

- **Framework**: ASP.NET Core 8 (Web API)
- **ORM & Database**: Entity Framework Core with SQL Server
- **Authentication**: Microsoft Identity, JWT Bearer
- **CQRS**: MediatR for command/query separation
- **Validation**: FluentValidation for DTOs
- **Object Mapping**: AutoMapper
- **Payments**: Stripe.net
- **Background Jobs**: Hangfire
- **Email**: MailKit
- **API Docs**: Swagger

## Deployment

This API is hosted on **MonsterAPI**. You can access the live deployment here:
[Evolvify](https://evolvify.runasp.net/swagger/index.html)
---

