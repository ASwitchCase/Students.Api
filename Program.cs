using MongoDB.Driver;
using Students.Api.Endpoints;
using Students.Api.Repositories;
using Students.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<MongoDbSettings>();
builder.Services.AddSingleton<IStudentsRepository,StudentsRepository>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapStudentsEndpoints();
app.Run();
