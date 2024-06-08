using DeltaTech.DiligenceTech.API.Communication.Application.Internal.CommandServices;
using DeltaTech.DiligenceTech.API.Communication.Application.Internal.QueriesServices;
using DeltaTech.DiligenceTech.API.Communication.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Communication.Domain.Services;
using DeltaTech.DiligenceTech.API.Communication.Infraestructure.Persistence.EFC.Repositories;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Configuration for Routing

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

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
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Communications Bounded Context Injection Configuration
builder.Services.AddScoped<IQARepository, QARepository>();
builder.Services.AddScoped<IQACommandService, QACommandService>();
builder.Services.AddScoped<IQAQueryService, QAQueryService>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAgentCommandService, AgentCommandService>();
builder.Services.AddScoped<IAgentQueryService, AgentQueryService>();

// Projects Bounded Context Injection Configuration
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectCommandService, ProjectCommandService>();
builder.Services.AddScoped<IProjectQueryService, ProjectQueryService>();

// Folder/Files Bounded Context Injection Configuration
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<IFolderCommandService, FolderCommandService>();
builder.Services.AddScoped<IFolderQueryService, FolderQueryService>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
