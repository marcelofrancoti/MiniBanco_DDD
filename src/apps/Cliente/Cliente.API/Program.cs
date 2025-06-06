using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using  Cliente.Aplication;
using  Cliente.Aplication.Cessionario;
using  Cliente.Aplication.Cessionario.Handlers;
using  Cliente.Aplication.ContaCorrente;
using  Cliente.Aplication.Empresa;
using  Cliente.Aplication.ModalidadeOperacao;
using  Cliente.Aplication.Operacao;
using  Cliente.Aplication.Usuario;
using  Cliente.Aplication.Usuario.Handlers;
using  Cliente.Application.Usuario;
using  Cliente.Infrasctruture.Services;
using  Cliente.Intrastruture;
using  Cliente.Intrastruture.Services;
using  Cliente.Intrastruture.Services.InsegracaoService;
using  Cliente.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os controladores
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Registro do MediatR para as handlers de Alter
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AlterCessionarioHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AlterContaCorrenteHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AlterEmpresaHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AlterUsuarioHandler).Assembly));

// Registro do MediatR para as handlers de Insert
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InsertCessionarioHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InsertContaCorrenteHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InsertEmpresaHandler).Assembly));

// Registro do MediatR para as handlers de DELETE
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteUsuarioHandler).Assembly));

// Registro do MediatR para as handlers de Query
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetEmpresaByIdHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListContaCorrentesHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListEmpresaHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListTiposEmpresaHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListUsuariosHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetIdUsuarioHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetIdCessionariosHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetIdContaCorrentesHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListModalidadesOperacaoHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListOperacaoHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InserirOperacaoHandler).Assembly));


// Configuração do banco de dados (PostgreSQL)
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("vHubDB")));

// Registro de IDbConnection com Npgsql
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("vHubDB");
    return new NpgsqlConnection(connectionString);
});

// Adicionando o HttpClient para fazer requisições HTTP
builder.Services.AddHttpClient();

// Registro dos CommandStore e QueryStore necessários
builder.Services.AddScoped<EmpresaCommandStore>();
builder.Services.AddScoped<EmpresaQueryStore>();
builder.Services.AddScoped<ContaCorrenteCommandStore>();
builder.Services.AddScoped<ContaCorrenteQueryStore>();
builder.Services.AddScoped<CessionarioCommandStore>();
builder.Services.AddScoped<CessionarioQueryStore>();
builder.Services.AddScoped<UsuarioCommandStore>();
builder.Services.AddScoped<UsuarioQueryStore>();
builder.Services.AddScoped<UsuarioEmpresaCommandStore>();
builder.Services.AddScoped<UsuarioEmpresaQueryStore>();
builder.Services.AddScoped<OperacaoQueryStore>();

builder.Services.AddScoped<OperacaoCommandStore>();
// Registro dos serviços de integração
builder.Services.AddScoped<KeyCloakService>();
builder.Services.AddScoped<TokenKeyCloack>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VHub API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor, insira o token JWT no formato Bearer {token}",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Adiciona o HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Configurações adicionais de API
builder.Services.AddAuthorization();

// Configuração para aplicar migrações do banco de dados automaticamente
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
    dbContext.Database.Migrate();
}

// Configuração do Swagger em modo de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware padrão da aplicação
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento dos controladores
app.MapControllers();

// Executa a aplicação
app.Run();
