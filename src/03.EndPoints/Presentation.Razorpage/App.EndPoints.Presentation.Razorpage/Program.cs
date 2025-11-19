using App.Domain.AppService.AdminAgg;
using App.Domain.AppService.CarAgg;
using App.Domain.AppService.InspectionAppointmentAgg;
using App.Domain.Core.AdminAgg.Contracts;
using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Services.AdminAgg;
using App.Domain.Services.CarAgg;
using App.Domain.Services.InspectionAppointmentAgg;
using App.Infrastructure.EfCore.Repositories.AdminAgg;
using App.Infrastructure.EfCore.Repositories.CarAgg;
using App.Infrastructure.EfCore.Repositories.InspectionAppointmentAgg;
using App.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=DESKTOP-I05OKD5\SQLEXPRESS;Database=TIAS_RazorPages;Integrated Security=true;TrustServerCertificate=true;"));


builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminAppService, AdminAppService>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarAppService, CarAppService>();

builder.Services.AddScoped<IInspectionAppointmentRepository, InspectionAppointmentRepository>();
builder.Services.AddScoped<IInspectionAppointmentService, InspectionAppointmentService>();
builder.Services.AddScoped<IInspectionAppointmentAppService, InspectionAppointmentAppService>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
