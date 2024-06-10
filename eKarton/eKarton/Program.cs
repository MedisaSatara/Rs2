using eKarton.Model.Request;
using eKarton.Service.Database;
using eKarton.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using eKarton.Filters;
using eKarton;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
    });

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[]{}
    } });

});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eKartonContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IAdministratorService, AdministratorService>();
builder.Services.AddTransient<IBolnicaService, BolnicaService>();
builder.Services.AddTransient<IOdjelService, OdjelService>();
builder.Services.AddTransient<IDoktorService, DoktorService>();
builder.Services.AddTransient<IOsiguranjeService, OsiguranjeService>();
builder.Services.AddTransient<IPacijentService, PacijentService>();
builder.Services.AddTransient<IPregledService, PregledService>();
builder.Services.AddTransient<IMjereService, PreventivneMjereService>();
builder.Services.AddTransient<ITerminService, TerminService>();









builder.Services.AddAutoMapper(typeof(IKorisnikService));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
