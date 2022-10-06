using YG.API.Configurations;
using YG.API.Providers;
using YG.Common.Models;
using YG.Data.Models;

using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;
using YG.Service.MonterService;
using YG.Repo.MonterRepo;
using YG.Service.Battle;
using YG.Repo.Battle;
using YG.Repo.SkillRepo;
using YG.Repo.SkillService;

namespace YG.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            //services.AddHttpClient();
            //services.AddHttpClient("myclient", client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:1234");
            //});
            services.AddHttpClient<MyTypedClient>();

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YG.API", Version = "v1" });
            });
            services.AddCommonServices();
            services.AddHttpContextAccessor();
            // //service
            services.AddScoped<IMonterService, MonterService>();
            services.AddScoped<IBattleService, BattleService>();
            services.AddScoped<ISkillService, SkillService>();



            // //repo
            services.AddScoped<IMonterRepository, MonterRepository>();
            services.AddScoped<IBattleRepository, BattleRepository>();
            services.AddScoped<ISkillRepo, SkillRepo>();


            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


            string connectionString = Configuration.GetConnectionString("YGDataContext");
            services.AddDbContext<YGDataContext>(options =>
           options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StaticServiceProvider.Provider = app.ApplicationServices;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YG.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
