using System.IO;
using System.Reflection;
using System.Text;
using Application.Behaviours;
using Application.Certifications.Queries.IssueCertificate;
using Application.Factors.Commands;
using Application.Positions.Commands;
using Application.Surveys.Commands.AddSurvey;
using Application.Surveys.Commands.UpdateSurvey;
using DinkToPdf;
using DinkToPdf.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RazorLight;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IRazorLightEngine>(sp =>
            {
                var engine = new RazorLightEngineBuilder()
                    .UseFilesystemProject(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .UseMemoryCachingProvider()
                    .Build();
                return engine;
            });

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddTransient<IValidator<UpdatePositionCommand>, UpdatePositionCommandValidator>();
            services.AddTransient<IValidator<AddPositionCommand>, AddPositionCommandValidator>();

            services.AddTransient<IValidator<UpdateFactorCommand>, UpdateFactorCommandValidator>();
            services.AddTransient<IValidator<AddFactorCommand>, AddFactorCommandValidator>();

            services.AddTransient<IValidator<UpdateSurveyCommand>, UpdateSurveyCommandValidator>();
            services.AddTransient<IValidator<AddSurveyCommand>, AddSurveyCommandValidator>();

            services.AddTransient<IValidator<IssueCertificateQuery>, IssueCertificateQueryValidator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    var secretBytes = Encoding.UTF8.GetBytes(configuration.GetSection("Jwt").GetSection("Secret").Value);
                    var key = new SymmetricSecurityKey(secretBytes);

                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = configuration.GetSection("Jwt").GetSection("Issuer").Value,
                        ValidAudience = configuration.GetSection("Jwt").GetSection("Audience").Value,
                        IssuerSigningKey = key,
                        ValidateLifetime = false
                    };
                });
        }
    }
}
