using BookManagerApp.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using BookManagerApp.Models;




var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    );


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
opts.ResolveConflictingActions(apiDesc => apiDesc.First())
);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo { Title = "BookManager", Version = "v1.0" });
    options.SwaggerDoc(
        "v2",
        new OpenApiInfo { Title = "BookManager", Version = "v2.0" });
});


var allowedOrigin = builder.Configuration["Cors:AllowedOrigin"];
if (string.IsNullOrEmpty(allowedOrigin))
{
    throw new InvalidOperationException("Cors:AllowedOrigin is not configured.");
}

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cfg =>
    {
        cfg.WithOrigins(allowedOrigin)
           .AllowAnyHeader()
           .AllowAnyMethod();
    });

    options.AddPolicy("AnyOrigin", cfg =>
    {
        cfg.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();
var intList = new List <int> ();
var stringintList = new List <string> ();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json",
            $"BookManager v1.0");
        options.SwaggerEndpoint($"/swagger/v2/swagger.json",
            $"BookManager v2.0");
    });

    app.UseDeveloperExceptionPage();
}

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/Error");
}



app.MapGet("/v{version:ApiVersion}/error",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
        [EnableCors("AnyOrigin")]
        [ResponseCache(NoStore = true)] 
        () => Results.Problem());

app.MapGet("/v{version:ApiVersion} /error/test",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
        [EnableCors("AnyOrigin")]
        [ResponseCache(NoStore = true)] () => 
        { throw new Exception("test"); });

app.MapGet("/v{version:ApiVersion}/cod/test",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
        [EnableCors("AnyOrigin")]
        [ResponseCache(NoStore = true)] () =>
        Results.Text("<script>" +
        "window.alert('Your Client supports JavaScript!" + 
        "\\r\\n\\r\\n" +
        $"Server time(UTC): {DateTime.UtcNow.ToString("O")}" +
        "\\r\\n" +
        "Client time (UTC): + new Date().toISOString());" + 
        "</script>" + 
        "<noscript> Your client does not support JavaScript</noscript>",
        "text/html"));

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();


app.Run();
