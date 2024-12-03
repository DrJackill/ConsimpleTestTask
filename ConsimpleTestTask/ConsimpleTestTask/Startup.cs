using ConsimpleTestTask.Kernel;
using ConsimpleTestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        private IWebHostEnvironment Environment { get; }

        private IConfiguration Configuration { get; }

        //Services configuration
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ConsimpleTestTaskContext>(
                    builder =>
                    {
                        if (Environment.IsDevelopment())
                            builder.EnableSensitiveDataLogging();

                        builder.UseNpgsql(
                            Configuration.GetConnectionString("DefaultConnection"));
                    });

            // Configure ours model services
            services.ConfigureModelServices();
        }

        public void ConfigureApp(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}