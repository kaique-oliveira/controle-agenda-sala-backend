using AgendaSala.Auth.Configuracoes;
using AgendaSala.Database.Conexao;
using AgendaSala.Database.Interfaces;
using AgendaSala.Database.ServicosCrud;
using AgendaSala.Domain.Interfaces;
using AgendaSala.Domain.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IConexao, ConexaoDatabase>();
builder.Services.AddScoped<ICrudAgendamento, CrudAgendamento>();
builder.Services.AddScoped<ICrudSetor,  CrudSetor>();
builder.Services.AddScoped<ICrudSala,  CrudSala>();
builder.Services.AddScoped<ICrudUsuario,  CrudUsuario>();
builder.Services.AddScoped<IServicoValidarAgendamento, ServicoValidarAgendamento>();

builder.Services.ConfigurarToken();
builder.Services.ConfigurarAutorizacoes();
builder.Services.ConfigurarCors();
builder.Services.ConfigurarPoliticasGlobais();

builder.Services.AddControllers();

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
