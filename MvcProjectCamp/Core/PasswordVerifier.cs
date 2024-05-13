using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectCamp.Core
{
    public class PasswordVerifier
    {
        public static bool VerifyPassword(string userInputPassword, string storedHashedPassword)
        {
            string userInputHashedPassword = PasswordHasher.HashPassword(userInputPassword);
            return userInputHashedPassword == storedHashedPassword;
        }
    }
}