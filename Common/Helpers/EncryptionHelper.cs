using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers
{


    public static class PasswordHelper
    {
        // Parameters (tweak if you know what you're doing)
        private const int SaltSize = 16;          // 128 bits
        private const int SubkeySize = 32;        // 256 bits
        private const int Iterations = 100_000;   // cost - modern recommended baseline

        // Format: {iterations}.{salt-base64}.{subkey-base64}
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            using (var rng = RandomNumberGenerator.Create())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    var subkey = pbkdf2.GetBytes(SubkeySize);

                    // store as: iterations.salt.subkey (all base64)
                    return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(subkey)}";
                }
            }
        }

        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null) throw new ArgumentNullException(nameof(hashedPassword));
            if (providedPassword == null) throw new ArgumentNullException(nameof(providedPassword));

            var parts = hashedPassword.Split('.');
            if (parts.Length != 3) return false; // invalid format

            if (!int.TryParse(parts[0], out var iterations)) return false;

            var salt = Convert.FromBase64String(parts[1]);
            var storedSubkey = Convert.FromBase64String(parts[2]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, iterations, HashAlgorithmName.SHA256))
            {
                var generatedSubkey = pbkdf2.GetBytes(storedSubkey.Length);
                return CryptographicOperations.FixedTimeEquals(generatedSubkey, storedSubkey);
            }
        }
    }
}


