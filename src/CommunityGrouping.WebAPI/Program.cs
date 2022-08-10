using System.Reflection;
using System.Text.Json.Serialization;
using CommunityGrouping.API.Extension.StartupExtension;
using CommunityGrouping.API.Middleware;
using CommunityGrouping.Business;
using CommunityGrouping.Core;
using CommunityGrouping.Data;
using CommunityGrouping.WebAPI.Extension.StartupExtension;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())); builder.Services.AddEndpointsApiExplorer();

builder.Host.UseSerilogExtension();
builder.Services.AddDbContextDependencyInjection(builder);
builder.Services.AddAutoMapperDependecyInjection(builder);
builder.Services.AddJwtConfigurationService(builder);
builder.Services.AddCustomSwagger();
builder.Services.AddBusinessLayerServiceRegistration();
builder.Services.AddDataLayerServiceRegistration();
builder.Services.AddCoreLayerServiceRegistration();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<HeartbeatMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
