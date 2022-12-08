using ERMAN;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IGeneralInterface<FAQItem, FAQItemDto>, FaqRepository>();
builder.Services.AddTransient<IEmailServices, EmailService>();
builder.Services.AddTransient<ErmanApplicationService>();
builder.Services.AddTransient<MessagingService>();
builder.Services.AddTransient<TodoRepository>();
builder.Services.AddTransient<UserRepository>();

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

app.Use(async (context, next) =>
{
    var userIdClaim = context.User.Claims.FirstOrDefault((claim => claim.Type == "userID"));
    if (userIdClaim != null) {
        var userId = Convert.ToInt32(userIdClaim.Value);
        context.Items["userID"] = userId;
    }
    var userTypeClaim = context.User.Claims.FirstOrDefault((claim => claim.Type == ClaimTypes.Role));
    if (userTypeClaim != null) {
        var userType = userTypeClaim.Value;
        context.Items["userType"] =  userType;
    }

    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.MapControllers();

app.Run();
