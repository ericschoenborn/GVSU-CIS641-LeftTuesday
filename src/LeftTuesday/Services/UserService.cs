using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Security.Cryptography;
using System.Text;

namespace LeftTuesday.Services
{
    public class UserService
    {
        private UserRepository _userRepo;

        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public (Exception, long) CreateUser(User user)
        {
            user.Secret = ExtraCrypt.Crypt(user.Secret);
            return _userRepo.AddUser(user);
        }

        private (Exception, User) LogIn((Exception error, User user) result, string secret)
        {
            if(result.error != null || result.user == null)
            {
                return (result.error == null? new Exception("Log in failed") : result.error, null);
            }

            var pass = ExtraCrypt.Decrypt(result.user.Secret);
            if (secret == pass)
            {
                return (null, result.user);
            }

            return (new Exception("Log in failed"), null);
        }

        public (Exception, User) GetUser(string userName, string secret)
        {
            return LogIn(_userRepo.GetUser(userName), secret);
        }

        public (Exception, User) UpdateUser(User user, string ogName, string ogSecret)
        {
            var (error, original) = LogIn(_userRepo.GetUser(ogName), ogSecret);

            if (error != null)
            {
                return (error, null);
            }

            if (original == null)
            {
                return (new Exception($"Validation failed for user {user.Name}"), null);
            }

            if (!string.IsNullOrWhiteSpace(user.Name))
            {
                original.Name = user.Name;
            }

            if (!string.IsNullOrWhiteSpace(user.Secret))
            {
                original.Secret = ExtraCrypt.Crypt(user.Secret);
            }

            return _userRepo.UpdateUser(original);
        }

        public (Exception, bool) DeleteUser(string userName, string secret)
        {
            var (error, user) = LogIn(_userRepo.GetUser(userName), secret);
            
            if(error != null)
            {
                return (error, false);
            }

            return _userRepo.DeleteUser(user.Id);
        }
    }

    public static class ExtraCrypt
    {
        private static readonly byte[] _salt = Encoding.ASCII.GetBytes("some salt");

        public static string Crypt(this string text)
        {
            return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(text), _salt, DataProtectionScope.CurrentUser));
        }

        public static string Decrypt(this string text)
        {
            return Encoding.Unicode.GetString(
                ProtectedData.Unprotect(
                     Convert.FromBase64String(text), _salt, DataProtectionScope.CurrentUser));
        }
    }
}
