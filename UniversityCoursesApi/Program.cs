// 1 - Using para Entity framework
using Microsoft.EntityFrameworkCore;
using UniversityCoursesApi.DataAccess;
using UniversityCoursesApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 2 - Connection with DB
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);


// 3 - Add context to Service of Builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 4 - Add services to the container.
builder.Services.AddScoped<IStudentsService, StudentsService>();


// TODO: Add the rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5- CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
}); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 6 - Tell app to use Cors
app.UseCors("CorsPolicy");

app.Run();
