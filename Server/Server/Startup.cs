using System;
using System.Buffers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.Data.Models;
using Server.Data.Seeding;
using Server.Infrastructure.Helpers;
using Server.Services.Answers;
using Server.Services.Common;
using Server.Services.Exams;
using Server.Services.Identity;
using Server.Services.NewFolder;
using Server.Services.Profile;
using Server.Services.Questions;
using Server.Services.Settings;
using Server.Services.User;

namespace Server
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
            services.AddHttpContextAccessor();
            services.AddSingleton(this.Configuration);

            services.AddDbContext<ApplicationDbContext>(
                options => { options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")); });
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                    x.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                var bytes = Encoding.ASCII.GetBytes("Token Expired");

                                context.Response.Headers.Add("Token-Expired", "true");
                                context.Response.BodyWriter.Write(bytes);
                            }
                            else
                            {
                                var bytes = Encoding.ASCII.GetBytes("Invalid token");
                                context.Response.BodyWriter.Write(bytes);
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "QuizSystem", Version = "v1"});
            });

            //Identity Services
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();

            // Data Services
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(db, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuizSystem v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //TODO: Change CORS Settings for prod
            app.UseCors(options =>
                options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}