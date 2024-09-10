using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Repositories;
using SchoolNotes.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBPostgreSQL>((IServiceProvider services, DbContextOptionsBuilder options) =>
{
    string connectionString = "Host=localhost:5432;Username=postgres;Password=admin;Database=SchoolNotes";
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<DbContext, DBPostgreSQL>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
