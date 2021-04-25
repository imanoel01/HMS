using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using HMS.Data;
using HMS.Dtos;
using HMS.Model;
using HMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHMSRepo _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        // private IUserService _userService;

        public UserController(IUserService userService, IHMSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model, ipAddress());
            if (response == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });

            }
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _userService.RefreshToken(refreshToken, ipAddress());

            if (response == null)
            {
                return Unauthorized(new { message = "Invalid token" });
            }

            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        {

            //accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { message = "Token is required" });
            }
            var response = _userService.RevokeToken(token, ipAddress());
            if (!response)
            {
                return NotFound(new { message = "Token not found" });
            }

            return Ok(new { message = "Token revoked" });
        }


        [Authorize]
        [HttpGet("{username}")]
        public ActionResult<User> Get(string username)
        {
            var user = _repository.getUserByUsername(username);

            if (user == null)
            {
                return NotFound();

            }

            return user;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<ReadUserDto> Post(CreateUserDto createUser)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ReadUserDto readUser = new ReadUserDto();
            try
            {
                _repository.BeginTransaction();

                Guid genUserId = Guid.NewGuid();
                var userModel = _mapper.Map<User>(createUser);
                userModel.DateCreated = DateTime.Now;
                userModel.UserId = Guid.NewGuid().ToString("N");
                _repository.createUser(userModel);
                _repository.saveChanges();

                readUser = _mapper.Map<ReadUserDto>(userModel);

                // throw new Exception("Something Went Wrong");
                _repository.CommitTransaction();
            }
            catch (Exception ex)
            {
                _repository.RollBackTransaction();
                throw new ApiException(ex.Message);
            }

            return readUser;
        }



        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var users = _repository.getUser();
            return Ok(users);
        }


        [HttpGet("{id}/refresh-tokens")]
        public IActionResult GetRefreshToken(string userId)
        {
            var user = _userService.GetById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.RefreshTokens);
        }

        //helper methods

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                //using five minutes to test
                Expires = DateTime.UtcNow.AddMinutes(5)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }


        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }

            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }




    }
}