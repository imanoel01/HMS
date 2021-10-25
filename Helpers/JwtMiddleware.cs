using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using HMS.Services;
using System.Threading.Tasks;

namespace HMS.Helpers{

    public class JwtMiddleware{
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
           _next= next;
           _appSettings =appSettings.Value; 
        }

        public async Task Invoke (HttpContext context, IUserService userService){
            var token= context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token !=null)
            {
                attachUserToContext(context,userService,token);
            }

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenhandler.ValidateToken(token, new TokenValidationParameters{

                    ValidateIssuerSigningKey= true,
                    IssuerSigningKey= new SymmetricSecurityKey(key),
                    ValidateIssuer=false,
                    ValidateAudience=false,
                    //set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew= TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken= (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x=>x.Type == "id").Value;
                //attach user tp contesxt on successfuk jwt validation
                context.Items["User"] = userService.GetById(long.Parse(userId));
            }
            catch
            {
                
            //do nothing if jwt validation faiks
            //user is not attached to context so request won't have access to secure routes
            }
        }
    }
}