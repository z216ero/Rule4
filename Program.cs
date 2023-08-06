using Microsoft.EntityFrameworkCore;
using Rule4.CustomMiddleware;
using Rule4.Data;
using Rule4.ServicesExtension;

namespace Rule4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("connection")));
            builder.Services.ConfigureServices();
            builder.Services.AddCors();

            var app = builder.Build();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(c => c.AllowAnyOrigin());
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}