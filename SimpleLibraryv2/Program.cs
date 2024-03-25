using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.DAL;
using SimpleLibraryv2.Repository;
using SimpleLibraryv2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbContextSimpleLibrary");
builder.Services.AddDbContext<DbContextSimpleLibrary>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<IBookService,BookService>();

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

app.Run();
