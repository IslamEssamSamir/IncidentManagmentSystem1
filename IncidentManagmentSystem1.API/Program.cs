using IncidentManagmentSystem1.API.Authentication;
using IncidentManagmentSystem1.API.Core.Mapping;
using IncidentManagmentSystem1.API.Core.Models;
using IncidentManagmentSystem1.API.Data;
using IncidentManagmentSystem1.API.Seeds;
using IncidentManagmentSystem1.API.Services.Implementations;
using IncidentManagmentSystem1.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ******************************************** Add services to the container. ********************************************

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Incidents Managment System",
        Description = "Web API Managing \"RASD\" Web Application for Incidents Managment.",
        Contact = new OpenApiContact
        {
            Name = "Islam Essam Samir",
            Email = "islamessam.92493@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/islamessamsamir/")
        },
        License = new OpenApiLicense
        {
            Name = "License: MOI ",
            Url = new Uri("https://moi.gov.eg/")
        }
    });

    // JWT Bearer Authentication
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token without the 'Bearer ' prefix."
    });

    // Apply the Bearer security scheme
    opt.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = []
        });

    // XML Documentation
    var xmlFileName =
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(
        AppContext.BaseDirectory,
        xmlFileName);

    if (File.Exists(xmlPath))
    {
        opt.IncludeXmlComments(xmlPath);
    }
});





builder.Services.AddCors();




var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));



builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));




var jwtSettings = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();





builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);





// Assign Services : 

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IAuthServices, AuthServices>();

builder.Services.AddScoped<IFileServices, FileServices>();



builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.SaveToken = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = jwtSettings!.Audience,
        ValidIssuer = jwtSettings!.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    };
});



builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.User.RequireUniqueEmail = true;

    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedPhoneNumber = false;

    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 8;
});




var app = builder.Build();



















//******************************************** Middlewares pipline. ********************************************


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseSwaggerUI(c =>
    //{
    //    c.DocumentTitle = "SurveyBasket.API";
    //    c.SwaggerEndpoint("/openapi/v1.json", "SurveyBasket.API v1");
    //});
}








using(var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();

    await DefaultRoles.SeedApplicationRoles(roleManager);
    await DefaultUsers.SeedApplicationUsers(userManager);
}









app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
