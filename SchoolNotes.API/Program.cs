using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories;
using SchoolNotes.API.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DBPostgreSQLSettings>(builder.Configuration.GetSection("DBPostgreSQLSettings"));

builder.Services.AddDbContext<DBPostgreSQL>((IServiceProvider services, DbContextOptionsBuilder options) =>
{
    DBPostgreSQLSettings dbSettings = services.GetRequiredService<IOptions<DBPostgreSQLSettings>>().Value;
    string connectionString = $"Host={dbSettings.Host};Username={dbSettings.Username};Password={dbSettings.Password};Database={dbSettings.Database}";
    options.UseNpgsql(connectionString);
});

// Repositories
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseSessionRepository>();
builder.Services.AddScoped<CourseSessionStudentRepository>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<ScoreRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<CourseSessionService>();
builder.Services.AddScoped<CourseSessionStudentService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<ScoreService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DBPostgreSQL dbContext = scope.ServiceProvider.GetRequiredService<DBPostgreSQL>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
