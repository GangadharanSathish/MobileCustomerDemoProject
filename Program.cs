using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mobile.Domain1.Data;
using Mobile.Domain1.Interface;
using Mobile.Domain1.jwt;
using Mobile.Domain1.Repository;
using Mobile.Service1.AutoMapper;
//using Mobile.Service1.AutoMapper;
using Mobile.Service1.Interface;
using Mobile.Service1.Service;
//using MobileADO.Repository;
using MobileDemoProject.Auto_Mapping;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;
public class Program
{
    [ExcludeFromCodeCoverage]
    private static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MobileDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MobileApiConnectionString")));

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IMobileRepository, MobileRepository>();
        builder.Services.AddScoped<IMobileService, MobileService>();

        //builder.Services.AddScoped<IAccessoriesRepository, AccessoriesRepository>();

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.
                   Add(new JsonStringEnumConverter());

            options.JsonSerializerOptions.DefaultIgnoreCondition =
                     JsonIgnoreCondition.WhenWritingNull;
        });

        builder.Services.AddHttpClient();


        builder.Services.AddAutoMapper(typeof(CustomerServiceMapping));
        builder.Services.AddAutoMapper(typeof(CustomerMapper));

        var _jwtsetting = builder.Configuration.GetSection("CustomerJwt");
        builder.Services.Configure<CustomerJwt>(_jwtsetting);

        builder.Services.AddEndpointsApiExplorer();




        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MobileDemoProject",
                Version = "v1"
            });
        });
        //    builder.Services.AddSwaggerGen(c =>
        //{
        //    c.SwaggerDoc("v3", new OpenApiInfo { Title = "MobileDemoProject", Version = "v3" });
        //});



        var authkey = builder.Configuration.GetValue<string>("CustomerJwt:SecretKey");
        builder.Services.AddAuthentication(item =>
        {
            item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(item =>
        {
            item.RequireHttpsMetadata = true;
            item.RequireHttpsMetadata = true;
            item.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });


        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
          {
          new OpenApiSecurityScheme {
          Reference = new OpenApiReference {
          Type = ReferenceType.SecurityScheme,
          Id = "Bearer"
          }
          },
          new string[] {}
          }
          });
        });
        var app = builder.Build();




        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();


    }
}