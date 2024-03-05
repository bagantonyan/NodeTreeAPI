using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NodeTree.API.Handlers;
using NodeTree.API.Mappings;
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

            builder.Services.AddControllers();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateNodeRequestModelValidator>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller}.{action}/{id?}");

            app.Run();
        }
    }
}
