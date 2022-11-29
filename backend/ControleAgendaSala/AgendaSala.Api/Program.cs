using AgendaSala.Database.Connection;
using AgendaSala.Database.Interface;
using AgendaSala.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<INpgSqlConnection, NpgSqlConnection>();
builder.Services.AddScoped<IEventCrud, EventRepository>();
builder.Services.AddScoped<IRoleCrud,  RoleRepository>();
builder.Services.AddScoped<IRoomCrud,  RoomRepository>();
builder.Services.AddScoped<IUserCrud,  UserRepository>();



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
