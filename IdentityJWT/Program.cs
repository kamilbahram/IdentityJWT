using IdentityJWT.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppIdentityDbContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContex>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
       .AddJwtBearer(options => {
           options.SaveToken = true;
           options.RequireHttpsMetadata = true;
           options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
           {
               ValidateIssuer = true,
               ValidIssuer = "https://localhost:44312",
               ValidateAudience = true,
               ValidAudience = "https://localhost:44312",
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreEgitim"))

           };
       });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

SeedData.Initialize(app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
