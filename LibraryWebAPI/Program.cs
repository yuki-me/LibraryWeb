using LibraryWebAPI;
using LibraryWebAPI.Data;
using LibraryWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<IssueBookRepository>();
builder.Services.AddTransient<ReturnBookRepository>();
builder.Services.AddTransient<StatusRepository>();
builder.Services.AddTransient<StudentRepository>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<Seed>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

Seed.SeedDataToDataBase(app);

app.Run();
