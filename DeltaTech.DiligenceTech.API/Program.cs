using DeltaTech.DiligenceTech.API.IAM.Application.Internal.CommandServices;
using DeltaTech.DiligenceTech.API.IAM.Application.Internal.OutboundServices;
using DeltaTech.DiligenceTech.API.IAM.Application.Internal.QueryServices;
using DeltaTech.DiligenceTech.API.IAM.Domain.Repositories;
using DeltaTech.DiligenceTech.API.IAM.Domain.Services;
using DeltaTech.DiligenceTech.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using DeltaTech.DiligenceTech.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using DeltaTech.DiligenceTech.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using DeltaTech.DiligenceTech.API.IAM.Infrastructure.Tokens.JWT.Services;
using DeltaTech.DiligenceTech.API.IAM.Interfaces.ACL;
using DeltaTech.DiligenceTech.API.IAM.Interfaces.ACL.Services;
using DeltaTech.DiligenceTech.API.Communication.Application.Internal.CommandServices;
using DeltaTech.DiligenceTech.API.Communication.Application.Internal.QueriesServices;
using DeltaTech.DiligenceTech.API.Communication.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Communication.Domain.Services;
using DeltaTech.DiligenceTech.API.Communication.Infraestructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Application.Internal.CommandServices;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Application.Internal.QueryServices;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Application.CommandServices;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Application.QueryServices;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.Profiles.Application.Internal.CommandServices;
using DeltaTech.DiligenceTech.API.Profiles.Application.Internal.QueryServices;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Services;
using DeltaTech.DiligenceTech.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Application.CommandServices;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Application.QueryServices;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Application.Internal.CommandServices;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Application.Internal.QueryServices;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.Profiles.Interfaces.ACL;
using DeltaTech.DiligenceTech.API.Profiles.Interfaces.ACL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Configuration for Routing

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedAllPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo()
            {
                Title   = "DeltaTech.DiligenceTech.API",
                Version = "v1",
                Description = "DiligenceTech Platform API",
                TermsOfService = new Uri("https://diligencetech.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "DeltaTech's DiligenceTech",
                    Email = "contact@deltaTech.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                },
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "JoaquinRivadeneyraLuisHerrerAyuwoki+123",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            } 
        });
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Communications Bounded Context Injection Configuration
builder.Services.AddScoped<IQARepository, QARepository>();
builder.Services.AddScoped<IQACommandService, QACommandService>();
builder.Services.AddScoped<IQAQueryService, QAQueryService>();

// Projects Bounded Context Injection Configuration
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectCommandService, ProjectCommandService>();
builder.Services.AddScoped<IProjectQueryService, ProjectQueryService>();

// File Management Bounded Context Injection Configuration
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<IFolderCommandService, FolderCommandService>();
builder.Services.AddScoped<IFolderQueryService, FolderQueryService>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAgentCommandService, AgentCommandService>();
builder.Services.AddScoped<IAgentQueryService, AgentQueryService>();
builder.Services.AddScoped<IAgentsContextFacade, AgentsContextFacade>();

// Projects Bounded Context Injection Configuration
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectCommandService, ProjectCommandService>();
builder.Services.AddScoped<IProjectQueryService, ProjectQueryService>();

// Folder/Files Bounded Context Injection Configuration
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<IFolderCommandService, FolderCommandService>();
builder.Services.AddScoped<IFolderQueryService, FolderQueryService>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();


// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowedAllPolicy");

// Add Authorization Middleware to the Request Pipeline

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
