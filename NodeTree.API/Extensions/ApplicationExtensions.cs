using Microsoft.EntityFrameworkCore;
using NodeTree.DAL.Contexts;

namespace NodeTree.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(configs =>
            {
                configs.SwaggerEndpoint("/swagger/v1/swagger.json", "NodeTree API V1");
            });
        }

        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<NodeTreeDBContext>())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }
        }
    }
}
