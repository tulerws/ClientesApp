namespace ClientesApp.API.Configurations
{
    public class CORSConfiguration
    {
        public static string PolicyName => "DefaultPolicy";

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cfg => cfg.AddPolicy(PolicyName, builder =>
            {
                builder.WithOrigins("http://localhost:5077/")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));
        }
    }
}
