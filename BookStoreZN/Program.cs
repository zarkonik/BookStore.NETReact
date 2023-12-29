global using BookStoreZN.Models;
global using BookStoreZN.Data;
global using BookStoreZN.Services.BookService;
using BookStoreZN.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();//ovo mora dodamo da bi registrovali servis
builder.Services.AddScoped<IUserService, UserService>();// i ovo
builder.Services.AddDbContext<DataContext>();//i ovo

if (builder.Environment.IsDevelopment())//ovo se mora doda za Cors
{
    builder.Services.AddCors(options =>
    {

        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

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
app.UseCors();//ovo se isto mora doda za Cors..nzm dal bas na ovo mesto

app.Run();
