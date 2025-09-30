using Microsoft.AspNetCore.Identity;
using Project_API_Note.Model;

namespace Project_API_Note.Service
{
    public class UserLoginService
    {
        private readonly PasswordHasher<LSUSER_LOGIN> _passwordHasher = new PasswordHasher<LSUSER_LOGIN>();

        public string HashPassword(LSUSER_LOGIN user, string plainPassword)
        {
            return _passwordHasher.HashPassword(user, plainPassword);
        }

        public bool VerifyPassword(LSUSER_LOGIN user, string hashedPassword, string inputPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
