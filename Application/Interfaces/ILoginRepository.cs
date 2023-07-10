using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.Interfaces
{
    public interface ILoginRepository
    {
        Tokens GenenrateToken(UserModel info);
        UserModel AuthenticateUser(UserLogin userLogin);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
