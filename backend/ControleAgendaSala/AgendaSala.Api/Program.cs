using AgendaSala.Database.Connection;
using AgendaSala.Database.Interface;
using AgendaSala.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<INpgSqlConnection, NpgSqlConnection>();
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IRoleRepository,  RoleRepository>();
builder.Services.AddSingleton<IRoomRepository,  RoomRepository>();
builder.Services.AddScoped<IUserRepository,  UserRepository>();



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
