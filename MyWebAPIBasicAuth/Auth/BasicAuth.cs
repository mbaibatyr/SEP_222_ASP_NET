using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace MyWebAPIBasicAuth.Auth
{
    public class BasicAuth : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuth(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No section Authorization");
            try
            {
                // "user1;password"
                var value = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credValue = Convert.FromBase64String(value.Parameter);
                var credArray = Encoding.UTF8.GetString(credValue).Split(':');
                var login = credArray[0];
                var psw = credArray[1];

                /*
                    проверка в БД            
                */

                string cred = "user1;1234";


                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login),
                    new Claim("psw", psw)
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            catch (Exception err)
            {
                return AuthenticateResult.Fail(err.Message);
            }
        }
    }
}
