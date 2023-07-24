namespace HospitalPharmacyManagementSystem.Web
{
    using Microsoft.EntityFrameworkCore;

    using HospitalPharmacyManagementSystem.Data.Models;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.Infrastructure.Extentions;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.ModelBinders;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<HospitalPharmacyManagementSystemDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = 
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                     builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                     builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                     builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                     builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddEntityFrameworkStores<HospitalPharmacyManagementSystemDbContext>();

            builder.Services.AddAppServices(typeof(IDrugService));

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}