using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Entities.Models;
using InfraStructure.Utils;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitWork _unitWork;
        private CryptoKey _cryptoKey;
        public LoginController(IUnitWork unitWork, IOptions<CryptoKey> cryptoKey)
        {
            _unitWork = unitWork;
            _cryptoKey = cryptoKey.Value;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLogin info)
        {
            var user = _unitWork.login.AuthenticateUser(info);
            if (user != null)
            {
                var token = _unitWork.login.GenenrateToken(user);
                if (token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid Client Key");
                }
            }
            else
            {
                return NotFound("User not found!");
            }
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public IActionResult RefreshToken([FromBody] Tokens token, string reqestId)
        {
            var principal = _unitWork.login.GetPrincipalFromExpiredToken(token.AccessToken);
            var claims = principal.Claims.ToList();
            UserModel user = new UserModel()
            {
                UserName = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value
            };

            if (RefreshTokenInfo.key != Controller_TextEncryption.Decrypt(token.RefreshToken, _cryptoKey.Key))
            {
                return Unauthorized("Invalid attempt!");
            }

            var newJwtToken = _unitWork.login.GenenrateToken(user);

            if (newJwtToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }

            return Ok(newJwtToken);
        }

    }
}
