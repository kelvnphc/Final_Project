using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PPKBeverage.PAYPAL;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PPKBeverage
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
            // Cấu hình localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en-US", "vi-VN" }; // Ngôn ngữ hỗ trợ
                options.DefaultRequestCulture = new RequestCulture("en-US"); // Ngôn ngữ mặc định
                options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
                options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
            });
            services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:44396")  // Thay thế với URL của bạn
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
            services.AddSignalR();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian chờ của session
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews()
                 .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                 .AddDataAnnotationsLocalization();

            // Đăng ký IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Configuration);
            services.AddSingleton<IPayPalService, PayPalService>();
            services.AddLogging(); // Thêm dịch vụ logging
                                   //services.AddScoped<IOtpService, OtpService>();

            // Các dịch vụ khác
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });          

            // Thêm dịch vụ xác thực Cookie (nếu bạn muốn sử dụng Cookie Authentication)
         


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/KhachHang/DangNhap";
            })
            .AddGoogle(options =>
            {
                options.ClientId = "686665689017-52si8987a5p5rpn2nev9q5u21sf2k6ne.apps.googleusercontent.com";
                options.ClientSecret = "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";
            })
            .AddFacebook(options =>
             {
                 options.AppId = "887076549934643";
                 options.AppSecret = "e570beb1b1f76441f5abd266a0dc3311";
                 options.Scope.Add("email"); // Yêu cầu quyền truy cập email
                 options.Fields.Add("name");
                 options.Fields.Add("email");
             })
            .AddTwitter(options =>
            {
                options.ConsumerKey = "3NUbB92omCrnDtwenRRyZwKov"; 
                options.ConsumerSecret = "af2CyGZvd4wBjrcGcJoBaKxVXEtkXKJF4pmEkYogV12ZicYtdq"; 
                options.RetrieveUserDetails = true; // Đảm bảo rằng bạn đang yêu cầu chi tiết người dùng nếu cần
                options.CallbackPath = new PathString("/signin-twitter");
            });
        }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            };
            var supportedCultures = new[] { "en-US", "fr-FR", "vi-VN" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("en-US")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowAllOrigins");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                     name: "payment",
                     pattern: "GioHang/{action=PaymentCallback}/{id?}");
                endpoints.MapControllerRoute(
                    name: "google",
                    pattern: "GoogleResponse",
                    defaults: new { controller = "KhachHang", action = "GoogleResponse" });

            });
        }
    }
}
