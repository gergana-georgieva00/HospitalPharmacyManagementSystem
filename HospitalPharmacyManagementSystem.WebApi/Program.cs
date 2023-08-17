namespace HospitalPharmacyManagementSystem.WebApi
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Web.Infrastructure.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<HospitalPharmacyManagementSystemDbContext>
                (opt => opt.UseSqlServer(connectionString));

            builder.Services.AddAppServices(typeof(IDrugService));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("HospitalPharmacyManagementSystem", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7181/")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("HospitalPharmacyManagementSystem");

            app.Run();
        }
    }
}