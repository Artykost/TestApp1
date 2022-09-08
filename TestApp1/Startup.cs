using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestApp1.Domain;
using TestApp1.Domain.Repository.Abstract;
using TestApp1.Domain.Repository.EntityFramework;
using TestApp1.Service;

namespace TestApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsetting.json
            Configuration.Bind("Project", new Config());
            //подключаем нужный функционал приложения в качестве сервисов
            services.AddTransient<IUserStatisticRepository, EFUserStatisticRepository>();
            services.AddTransient<DataManager>();
            //подключаем контекст БД
            services.AddDbContext<UserManagmentDbContext>(x => x.UseSqlServer(Config.ConnectionString));
            //подключаем сессию
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
