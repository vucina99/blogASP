using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Core;
using Api.Core.FakeActors;
using Api.Core.Jwt;
using Application;
using Application.Commands.CommentCommands;
using Application.Commands.HashTagCommands;
using Application.Commands.LikeCommands;
using Application.Commands.PostCommands;
using Application.Commands.UserCommands;
using Application.Email;
using Application.Logger;
using Application.Queries.CommentQueries;
using Application.Queries.HashTagQueries;
using Application.Queries.LikeQueries;
using Application.Queries.LogQueries;
using Application.Queries.PostQueries;
using DataAccess;
using Implementation.Commands.CommentCommands;
using Implementation.Commands.HashTagCommands;
using Implementation.Commands.LikeCommands;
using Implementation.Commands.PostCommands;
using Implementation.Commands.UserCommands;
using Implementation.Email;
using Implementation.Logger;
using Implementation.Queries.CommentQueries;
using Implementation.Queries.HashTagQueries;
using Implementation.Queries.LikeQueries;
using Implementation.Queries.LogQueries;
using Implementation.Queries.PostQueries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<Context>();
            services.AddAutoMapper(typeof(EFGetPostsQuery).Assembly);

            ///validator
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<CreateHashTagValidator>();
            services.AddTransient<UserLoginRequestValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<LikePostValidator>();
            services.AddTransient<UpdateHashTagValidator>();
            services.AddTransient<UpdateCommentValidator>();
            services.AddTransient<UpdatePostValidator>();

            ///users - login...
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<JwtManager>();
            services.AddTransient<IApplicationActor,FakeApiActor>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();


            ///post
            services.AddTransient<IGetPostsQuery, EFGetPostsQuery>();
            services.AddTransient<IGetPostQuery, EFGetPostQuery>();
            services.AddTransient<ICreatePostCommand, EFCreatePostCommand>();
            services.AddTransient<IDeletePostCommand, EFDeletePostCommand>();
            services.AddTransient<IUpdatePostCommand, EFUpdatePostCommand>();

            ///hashtag
            services.AddTransient<IGetHashTagsQuery, EFGetHashTagsQuery>();
            services.AddTransient<IGetHashTagQuery, EFGetHashTagQuery>();
            services.AddTransient<ICreateHashTagCommand, EFCreateHashTagCommand>();
            services.AddTransient<IDeleteHashTagCommand, EFDeleteHashTagCommand>();
            services.AddTransient<IUpdateHashTagCommand, EFUpdateHashTagCommand>();

            ///comment
            services.AddTransient<IGetCommentsQuery, EFGetCommentsQuery>();
            services.AddTransient<IGetCommentQuery, EFGetCommentQuery>();
            services.AddTransient<ICreateCommentCommand, EFCreateCommentCommandd>();
            services.AddTransient<IDeleteCommentCommand, EFDeleteCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, EFUpdateCommentCommand>();

            ///like
            services.AddTransient<ICreateLikeCommand, EFCreateLikeCommand>();
            services.AddTransient<IDeleteLikeCommand, EFDeleteLikeCommand>();
            services.AddTransient<IGetLikesQuery, EFGetLikesQuery>();
            services.AddTransient<IGetLikeQuery, EFGetLikeQuery>();

            ///user
            services.AddTransient<ICreateUserCommand, EFCreateUserCommand>();

            ///logs
            services.AddTransient<IGetLogsQuery, EFGetLogsQuery>();

            ///email
            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new UnauthorizedActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });



            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travel Blog", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
