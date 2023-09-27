using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.OpenApi.Models;
using MVCGoogleAuth.Services;
using MVCGoogleAuth.Services.Interfaces;

namespace MVCGoogleAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();

            var clientId = System.Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
            var clientSecret = System.Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

            var builder = WebApplication.CreateBuilder(args);

            var googleOptions = builder.Configuration.GetSection("Authentication:Google").Get<GoogleOptions>();

            // Add services to the container.

            builder.Services.AddTransient<INewsService, NewsService>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = clientId!;
                options.ClientSecret = clientSecret!;
            });

            builder.Services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "MVCGoogleAuth.xml");
                c.IncludeXmlComments(filePath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "News Portal API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "News Portal API V1");
            });

            app.Run();
        }
    }
}