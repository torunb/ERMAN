using ERMAN;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ERMAN.Dtos;
using ERMAN.Models;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IGeneralInterface<FAQItem, FAQItemDto>, FaqRepository>();

builder.Services.AddDbContext<ErmanDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ErmanDb"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowLocalhost",
                      builder =>
                      {
                          builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
                      });
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Student", policy => policy.RequireClaim(""));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    Secure = CookieSecurePolicy.None,
};
app.UseCookiePolicy(cookiePolicyOptions);
app.UseCors("allowLocalhost");

app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets();

app.MapControllers();

app.Run();
