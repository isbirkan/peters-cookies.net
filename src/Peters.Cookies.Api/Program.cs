using System.Reflection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Peters.Cookies.Api.Models.Examples;
using Peters.Cookies.Application.Interfaces;
using Peters.Cookies.Application.Managers;
using Peters.Cookies.Domain.Builders;
using Peters.Cookies.Domain.Interfaces;
using Peters.Cookies.Infrastructure.Commands;
using Peters.Cookies.Infrastructure.Interfaces;
using Peters.Cookies.Infrastructure.Queries;
using Peters.Cookies.Infrastructure.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<CookieSupplierServiceBase>(c =>
{
    c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Peter's Cookies Api", Version = "v1" });
    c.ExampleFilters();
    c.CustomSchemaIds(type => type.FullName);
    c.IncludeXmlComments($@"{AppContext.BaseDirectory}\Peters.Cookies.Api.xml");
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<GenerateQuotesModelExample>();

builder.Services.AddScoped<ICookieSupplierService, CookieSupplierAService>();
builder.Services.AddScoped<ICookieSupplierService, CookieSupplierBService>();
builder.Services.AddScoped<ICookieSupplierService, CookieSupplierCService>();
builder.Services.AddScoped<IOrderCommandHandler, OrderCommandHandler>();
builder.Services.AddScoped<IProductsQueryHandler, ProductsQueryHandler>();
builder.Services.AddScoped<IQuotesQueryHandler, QuotesQueryHandler>();
builder.Services.AddScoped<IQuoteBuilder, QuoteBuilder>();
builder.Services.AddScoped<IOrderBuilder, OrderBuilder>();
builder.Services.AddScoped<IQuoteManager, QuoteManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

JsonConvert.DefaultSettings = () =>
{
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false }
        }
    };

    settings.Converters.Add(new StringEnumConverter());
    return settings;
};

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
