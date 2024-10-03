using FormulaAirline.API.Services;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IMessageProducer, MessageProducer>();
builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();


app.Run();
