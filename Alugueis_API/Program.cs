using alugueis_api.Data;
using alugueis_api.Handlers;
using alugueis_api.Interfaces;
using alugueis_api.Models;
using alugueis_api.NovaPasta;
using alugueis_api.Repositories;
using alugueis_api.Security;
using alugueis_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using alugueis_api.Interfaces.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DespesaRepository>();
builder.Services.AddScoped<AptoRepository>();
builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAptoService, AptoService>();
builder.Services.AddScoped<IGerenciadorToken, GerenciadorToken>();
builder.Services.AddScoped<AddDespesaAptoHandler>();
builder.Services.AddScoped<UpdateDespesaAptoHandler>();
builder.Services.AddScoped<DeleteDespesaAptoHandler>();
builder.Services.AddScoped<GetDespesaAptoHandler>();
builder.Services.AddScoped<AuthConfig>();
builder.Services.AddControllers();

var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<AuthConfig>(jwtSection);
var AuthConfig = jwtSection.Get<AuthConfig>();

var key = Encoding.UTF8.GetBytes(AuthConfig.Secret);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<GerenciadorToken>();

//  pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");

//  registra o DbContext no DI
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

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

app.Run();
