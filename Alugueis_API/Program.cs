using Alugueis_API.Data;
using Alugueis_API.Handlers;
using Alugueis_API.Handlers.AptoHandlers;
using Alugueis_API.Handlers.DespesaHandlers;
using Alugueis_API.Handlers.LocatarioHandlers;
using Alugueis_API.Handlers.PessoaHandlers;
using Alugueis_API.Handlers.UsuarioHandlers;
using Alugueis_API.Interfaces;
using Alugueis_API.Interfaces.Security;
using Alugueis_API.Mapping;
using Alugueis_API.Models;
using Alugueis_API.NovaPasta;
using Alugueis_API.Repositories;
using Alugueis_API.Security;
using Alugueis_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DespesaRepository>();
builder.Services.AddScoped<AptoRepository>();
builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IBaseRepository<Locatario>, LocatarioRepository>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAptoService, AptoService>();
builder.Services.AddScoped<IGerenciadorToken, GerenciadorToken>();
builder.Services.AddScoped<ILocatarioService, LocatarioService>();
builder.Services.AddScoped<AddDespesaAptoHandler>();
builder.Services.AddScoped<UpdateDespesaAptoHandler>();
builder.Services.AddScoped<DeleteDespesaAptoHandler>();
builder.Services.AddScoped<GetDespesaAptoHandler>();
builder.Services.AddScoped<DeleteAptoHandler>();
builder.Services.AddScoped<AuthHandler>();
builder.Services.AddScoped<AddPessoaHandler>();
builder.Services.AddScoped<GetPessoaHandler>();
builder.Services.AddScoped<UpdatePessoaHandler>();
builder.Services.AddScoped<DeletePessoaHandler>();
builder.Services.AddScoped<AddUsuarioHandler>();
builder.Services.AddScoped<GetUsuarioHandler>();
builder.Services.AddScoped<UpdateUsuarioHandler>();
builder.Services.AddScoped<DeleteUsuarioHandler>();
builder.Services.AddScoped<ExistsUsuarioHandler>();
builder.Services.AddScoped<GetLocatarioHandler>();
builder.Services.AddScoped<RegisterLoginHandler>();
builder.Services.AddScoped<AuthConfig>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(ModelToDTOMapping));

var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<AuthConfig>(jwtSection);
var AuthConfig = jwtSection.Get<AuthConfig>();

var key = Encoding.UTF8.GetBytes(AuthConfig.Secret);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
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
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "Alugueis API",
    Version = "v1"
});

c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Informe o token JWT no formato: Bearer {seu_token}"
});
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


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
