using AgendaSala.Auth.Configuracoes;
using AgendaSala.Auth.Interfaces;
using AgendaSala.Auth.Servicos;
using AgendaSala.Database.Conexao;
using AgendaSala.Database.Interfaces;
using AgendaSala.Database.ServicosCrud;
using AgendaSala.Domain.Interfaces;
using AgendaSala.Domain.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConexao, ConexaoDatabase>();
builder.Services.AddSingleton<ICrudAgendamento, CrudAgendamento>();
builder.Services.AddSingleton<ICrudSetor, CrudSetor>();
builder.Services.AddSingleton<ICrudSala, CrudSala>();
builder.Services.AddSingleton<ICrudUsuario, CrudUsuario>();
builder.Services.AddSingleton<IServicoValidarAgendamento, ServicoValidarAgendamento>();
builder.Services.AddSingleton<IServicoCalcularHoraFinal, ServicoCalcularHoraFinal>();
builder.Services.AddSingleton<IAuthToken, AuthToken>();

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

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
