using ExceptionHandling.Api;

namespace ExceptionHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Register exception handling middleware as a service
            builder.Services.AddTransient<ExceptionHandlingMiddleware>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
            //Configure the middleware in the request pipeline.
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.Run();
        }
    }
}