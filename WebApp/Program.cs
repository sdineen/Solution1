using ClassLibrary.Repository.EF;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;
services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

ConfigurationManager configurationManager = builder.Configuration;

//add DbContext to service collection
services.AddDbContext<EcommerceContext>(
     options => options.UseSqlServer(
           configurationManager.GetConnectionString("EcommerceConnection")));


//specify implementation of IEcommerceService 
//services registered with AddTransient are disposed after the request
services.AddTransient<IEcommerceService, EcommerceService>(ctx =>
{
    EcommerceContext? context = ctx.GetService<EcommerceContext>();
    return new EcommerceService(new AccountRepository(context!),
                                new ProductRepository(context!),
                                new OrderRepository(context!));
});

//in production, CORS not required as api and react application are hosted by same server
if (builder.Environment.IsDevelopment())
{
    services.AddCors(opt =>
    {
        opt.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        });
    });
}


//Microsoft.AspNetCore.Authentication.JwtBearer package
//To verify JWT signature, get 256 bit (32 character) token key from keyvault secret named Settings--TokenKey if present, otherwise from Settings/TokenKey in appsettings 
string key = configurationManager["Settings:TokenKey"];

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

app.UseHttpsRedirection();
app.UseAuthentication();//must be before authorization
app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();
