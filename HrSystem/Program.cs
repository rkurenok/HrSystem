using HrSystem.Configurations;
using HrSystem.Data;
using HrSystem.Models;
using HrSystem.Repositories;
using HrSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<HrContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<HhApiSettings>(builder.Configuration.GetSection("HhApiSettings"));

builder.Services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));

builder.Services.AddTransient<ICandidateService, CandidateService>();
builder.Services.AddTransient<ICRUDService<Department>, DepartmentService>();
builder.Services.AddTransient<ICRUDService<Hr>, HrService>();
builder.Services.AddTransient<ICRUDService<Vacancy>, VacancyService>();

builder.Services.AddHttpClient<ICandidateService, CandidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();