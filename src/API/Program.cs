using System.Reflection;
using API.Config.Extensions;
using API.Middleware;
using Application.Behaviours;
using Application.Features.Queries;
using Infrastructure;
using Infrastructure.Helpers;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
// Add services to the container.
{
    var services = builder.Services;

    services.AddCors(p => p.AddPolicy("CorsPolicy", builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

    services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetSection("EntityFramework:databaseName").Value));
    services.AddScoped<DbContext, DataContext>();

    services.AddControllers().AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
    services.AddAutoMapper(typeof(Program));

    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddSwaggerDocumentation();
    services.AddAuthorizationServices(builder.Configuration);
    services.AddApplicationServices();
    services.AddInfrastructureServices();

    services.AddMediatR(typeof(GetChatByMinQueryHandler).GetTypeInfo().Assembly);
    services.AddMediatR(typeof(GetChatByHourQueryHandler).GetTypeInfo().Assembly);

    services.AddMediatR(Assembly.GetExecutingAssembly());
    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
}

var app = builder.Build();

//Configure Database Seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    var logger = services.GetService<ILogger<DataContextSeed>>();

    DataContextSeed.Initialize(services,logger);
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CorsPolicy");

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
