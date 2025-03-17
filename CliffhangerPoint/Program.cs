using System.Security.Claims;
using CliffhangerPoint.Database;
using CliffhangerPoint.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using MediatR;
using CliffhangerPoint;
using CliffhangerPoint.Models;
using CliffhangerPoint.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddMediatR(x => 
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
//     .AddBearerToken(IdentityConstants.BearerScheme);

// builder.Services.AddIdentityCore<User>()
//     .AddEntityFrameworkStores<ApplicationDbContext>()
//     .AddApiEndpoints();


var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi();
    // app.MapScalarApiReference(options => 
    // {
    //     options
    //         .WithTitle("CliffhangerPoint Api")
    //         .WithTheme(ScalarTheme.Saturn)
    //         .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    // });

    // app.ApplyMigrations();
}

// app.MapGet("users/me", async (ClaimsPrincipal claims, ApplicationDbContext context) =>
// {
//     string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

//     return await context.Users.FindAsync(userId);
// })
// .RequireAuthorization();

//app.UseHttpsRedirection();

////app.UseAuthorization();

//app.MapControllers();

//app.MapIdentityApi<User>();

app.Run();
