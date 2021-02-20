using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HMS.Model
{
    public class AuthenticateResponse
    {

         public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        [JsonIgnore] // refresh token is returned in http only ccookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse(User user, string token,string refreshToken){
            UserId=user.UserId;
            Firstname=user.Firstname;
            Middlename=user.Middlename;
            Lastname=user.Lastname;
            Username= user.Username;
            Token= token;
            RefreshToken =refreshToken;

            

        }   
    }
}