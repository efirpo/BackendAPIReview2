
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Text;
public partial class Startup
{
  public SymmetricSecurityKey signingKey;
  private void ConfigureAuth(IApplicationBuilder app)
  {

    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));


    var tokenValidationParameters = new TokenValidationParameters
    {
      // The signing key must match!
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = signingKey,
      // Validate the JWT Issuer (iss) claim
      ValidateIssuer = true,
      ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
      // Validate the JWT Audience (aud) claim
      ValidateAudience = true,
      ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
      // Validate the token expiry
      ValidateLifetime = true,
      // If you want to allow a certain amount of clock drift, set that here:
      ClockSkew = TimeSpan.Zero
    };


    app.UseJwtBearerAuthentication(new JwtBearerOptions
    {
      AutomaticAuthenticate = true,
      AutomaticChallenge = true,
      TokenValidationParameters = tokenValidationParameters
    });

  }

}