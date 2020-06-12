using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace PetShelter.CustomTokenAuthProvider
{
  public class TokenProviderOptions
  {
    public string Path { get; set; } = "/token";
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(120);
    public SigningCredentials SigningCredentials { get; set; }
    public Func<string, string, Task<ClaimsIdentity>> IdentityResolver { get; set; }
    public string NonceGenerator(string extra = "")
    {
      string result = "";
      SHA1 sha1 = SHA1.Create();

      Random rand = new Random();

      while (result.Length < 32)
      {
        string[] generatedRandoms = new string[4];

        for (int i = 0; i < 4; i++)
        {
          generatedRandoms[i] = rand.Next().ToString();
        }

        result += Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(string.Join("", generatedRandoms) + "|" + extra))).Replace("=", "").Replace("/", "").Replace("+", "");
      }

      return result.Substring(0, 32);
    }
  }
}