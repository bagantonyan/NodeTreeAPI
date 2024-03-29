using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodeTree.API.Extensions;
using NodeTree.API.Handlers;
using NodeTree.API.Mappings;
using NodeTree.API.Models.ApiModels;
using NodeTree.API.ModelValidations.TreeNode;
using NodeTree.BLL.Mappings;
using NodeTree.BLL.Services;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Contexts;
using NodeTree.DAL.UnitOfWork;

namespace NodeTree.API
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateNodeRequestModelValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsBuilder => corsBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            builder.Services.AddSwagger();

            builder.Services.AddFluentValidationRulesToSwagger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.AddSwagger();
            }

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            await app.MigrateDatabaseAsync();

            app.MapControllers();

            app.Run();
        }
    }
}