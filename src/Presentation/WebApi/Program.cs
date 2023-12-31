using Application;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Text.Json.Serialization;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

#region Custom Service Configuration
builder.Services
.AddApplication()
.AddPersistence(configuration);
#endregion

builder.Services.AddControllers().AddNewtonsoftJson().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddSwagger();

var app = builder.Build();

app.UseCors(q => q.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.ConfigureSwagger();
}

app.EnsureDatabaseCreated();

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
