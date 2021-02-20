using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using HMS.Data;
using HMS.Helpers;
using HMS.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HMS.Services{
    public interface IUserService{
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        User GetById(string userId);

        AuthenticateResponse RefreshToken(string token,string ipAddress);
        bool RevokeToken(string token, string ipAddress);
    }

    public class UserService : IUserService
    {
        private IHMSRepo _repository;
        private readonly AppSettings _appSettings;

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var user = _repository.getUserbyUsernameAndPassword(model.Username,model.Password);

            //return null if user not found

            if (user == null)
            {
                return null;
            }

            // authenticate successful so generate jwt and refresh tokens
            var token= generateJwtToken(user);
            var refreshToken = generateRefreshToken(ipAddress);

            //save refresh token
            user.RefreshTokens.Add(refreshToken);
            _repository.UpdateUser(user);
            _repository.saveChanges();

            return new AuthenticateResponse(user, token, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress){
            var user = _repository.getUserByToken(token);

            //return null if no user found with token

            if (user == null)
            {
                return null;
            }

            // var refreshToken = user.RefreshTokens.Find(ut =>ut.Token ==token);

            var refreshToken  =_repository.getUserRefreshToken(user, token);

            // retun null if token is no longer active

            if (!refreshToken.IsActive)   
            {
                return null;
            }

            //replace oldrefreshtoken with a new one and  save

            var newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked= DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken= newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);
            _repository.UpdateUser(user);
            _repository.saveChanges();

            //generate new jwt

            var jwtToken = generateJwtToken(user);
            return new AuthenticateResponse(user, jwtToken,newRefreshToken.Token);
        }

        public bool RevokeToken(string token, string ipAddress){
            var user = _repository.getUserByToken(token);

            //return false if no user found with token
            if(user ==null) 
            {
                return false;
            }

            var refreshToken = _repository.getUserRefreshToken(user,token);

            //return false if token is not active
            if (!refreshToken.IsActive)
            {
                return false;
            }

            //revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;

            _repository.UpdateUser(user);
            _repository.saveChanges();
            return true;
        }

        private string generateJwtToken(User user)
        {
          // generate token that is valid for  x number of days

          var tokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject= new ClaimsIdentity(new[] {new Claim ("id", user.UserId.ToString())}),
            Expires= DateTime.UtcNow.AddDays(1),
            SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
        
        }

        public UserService(IOptions<AppSettings> appsettings, IHMSRepo repository)
        {
            _repository = repository;
            _appSettings= appsettings.Value;
        }

        public User GetById(string userId)
        {
          return   _repository.getUserByUserId(userId);
        }

        private RefreshToken generateRefreshToken(string ipAddress){
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];

                rngCryptoServiceProvider.GetBytes(randomBytes);

                return new RefreshToken{
                    Token= Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddHours(2),
                    Created= DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }
    }
}