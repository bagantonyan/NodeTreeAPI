using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NodeTree.API.Handlers;
using NodeTree.API.Mappings;
using NodeTree.API.Models.ApiModels;
using NodeTree.API.ModelValidations.TreeNode;
using NodeTree.BLL.Mappings;
using NodeTree.BLL.Services;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Contexts;
using NodeTree.DAL.UnitOfWork;
using System.Reflection;

namespace NodeTree.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<NodeTreeDBContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITreeNodeService, TreeNodeService>();
            builder.Services.AddScoped<IJournalRecordService, JournalRecordService>();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<ApiMappingProfile>();
                config.AddProfile<BLLMappingProfile>();
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError));
                options.Filters.Add(new ProducesAttribute("application/json"));
            });

            builder.Services.AddValidatorsFromAssemblyContaining<CreateNodeRequestModelValidator>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsBuilder => corsBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            builder.Services.AddSwaggerGen(configs =>
            {
                configs.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NodeTree API",
                    Version = "v1",
                    Description = "An API for working with tree of nodes and with journal of exceptions",
                    Contact = new OpenApiContact
                    {
                        Name = "Bagrat Antonyan - Github",
                        Url = new Uri("https://github.com/bagantonyan")
                    }
                });

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                configs.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);
            });

            builder.Services.AddFluentValidationRulesToSwagger();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(configs =>
                {
                    configs.SwaggerEndpoint("/swagger/v1/swagger.json", "NodeTree API V1");
                });
            }

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.MapControllers();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller}.{action}/{id?}");

            app.Run();
        }
    }
}
