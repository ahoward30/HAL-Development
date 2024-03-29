using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ITMatching.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using ITMatching.Services;
using ITMatching.Models;
using ITMatching.Models.Abstract;
using ITMatching.Models.Concrete;
using ITMatching.Hubs;
using ITMatching.Services.Abstract;
using ITMatching.Services.Concrete;
using GoogleReCaptcha.V3.Interface;
using GoogleReCaptcha.V3;

namespace ITMatching
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AuthenticationConnection")));

            services.AddDbContext<ITMatchingAppContext>(options =>
                options.UseSqlServer(
                     Configuration.GetConnectionString("ITMatchingConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            services.AddScoped<IItmuserRepository, ItmuserRepository>();
            services.AddScoped<IExpertRepository, ExpertRepository>();
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddScoped<IHelpRequestRepository, HelpRequestRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IPhotoService, PhotoService>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()                          //Enable Roles
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            // Added to enable runtime compilation
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            //Adds EmailSender as a transient service
            services.AddTransient<IEmailSender, EmailSender>();

            //Register the AuthMessageSenderOptions configuration instance
            services.Configure<AuthMessageSenderOptions>(Configuration);

            //Change email and activity timeout to 2 days
            services.ConfigureApplicationCookie(o => {
                o.ExpireTimeSpan = TimeSpan.FromDays(2);
                o.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(route => { route.MapHub<ChatHub>("/ChatHub"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
