using PetShelter.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PetShelter.CustomTokenAuthProvider;


namespace PetShelter
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<PetShelterContext>(opt =>
          opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddSwaggerGen(c =>
        {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pet Shelter API", Version = "v1", Description = "A simple API created to test backend API understanding for Epicodus' C#/.Net course." });
        });
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.Audience = "{Configuration.GetSection('TokenAuthentication:Audience')}";
        options. = "{Configuration.GetSection('TokenAuthentication:Issuer')}";

      })
    }
    public void ConfigureAuth(IApplicationBuilder app)
    {
      var signingkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));
      var tokenProviderOptions = new TokenProviderOptions
      {
        Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
        Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
        Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
        SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
        IdentityResolver = GetIdentity
      }
    
}
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseSwagger();
      app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Shelter API V1");
          c.RoutePrefix = string.Empty;
        });
      // app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}