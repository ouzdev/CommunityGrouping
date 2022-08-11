using CommunityGrouping.API.Extension.StartupExtension;
using CommunityGrouping.API.Middleware;
using CommunityGrouping.Business;
using CommunityGrouping.Core;
using CommunityGrouping.Data;
using CommunityGrouping.WebAPI.Extension.StartupExtension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCustomizeController();
builder.Services.AddPagination();
builder.Services.AddRedisDependecyInjection(builder.Configuration);
builder.Host.UseSerilogExtension();
builder.Services.AddDbContextDependencyInjection(builder);
builder.Services.AddAutoMapperDependecyInjection(builder);
builder.Services.AddJwtConfigurationService(builder);
builder.Services.AddCustomSwagger();
builder.Services.AddBusinessLayerServiceRegistration();
builder.Services.AddDataLayerServiceRegistration();
builder.Services.AddCoreLayerServiceRegistration();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        //Hide Schemas
        opt.DefaultModelsExpandDepth(-1);
    });
}
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<HeartbeatMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
