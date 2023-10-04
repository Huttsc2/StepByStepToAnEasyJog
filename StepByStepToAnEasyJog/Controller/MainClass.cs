namespace StepByStepToAnEasyJog.Controller
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                        });
                });
                services.AddControllers();
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseCors("AllowAllOrigins");
                //app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/", context => {
                        context.Response.Redirect("/start.html");
                        return Task.CompletedTask;
                    });
                    endpoints.MapControllers();
                });
            }
        }
    }
}
