using System;
using System.Security.Cryptography;

namespace T3ACS.Util
{
    /// <summary>
    /// Tiện ích băm mật khẩu bằng PBKDF2 (dùng API có sẵn của .NET, không cần thêm package).
    /// Định dạng lưu trữ: PBKDF2$&lt;iterations&gt;$&lt;saltBase64&gt;$&lt;hashBase64&gt;
    /// </summary>
    public static class PasswordHasher
    {
        private const string Prefix = "PBKDF2";
        private const int SaltSize = 16;      // 128-bit salt
        private const int HashSize = 32;      // 256-bit hash
        private const int Iterations = 100_000;

        /// <summary>
        /// Băm mật khẩu thô thành chuỗi lưu trong DB.
        /// </summary>
        public static string Hash(string password)
        {
            if (password == null) password = string.Empty;

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

            return string.Format("{0}${1}${2}${3}",
                Prefix, Iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        /// <summary>
        /// Kiểm tra một chuỗi đã ở định dạng hash của hệ thống hay chưa.
        /// Dùng để tránh băm lại (double-hash) và để nhận biết mật khẩu cũ dạng plaintext.
        /// </summary>
        public static bool IsHashed(string stored)
        {
            return !string.IsNullOrEmpty(stored) && stored.StartsWith(Prefix + "$", StringComparison.Ordinal);
        }

        /// <summary>
        /// Xác thực mật khẩu người dùng nhập với giá trị đã lưu.
        /// Hỗ trợ migration mềm: nếu giá trị lưu là plaintext (chưa hash) thì so sánh trực tiếp,
        /// để tài khoản cũ vẫn đăng nhập được (sau đó nơi gọi nên hash lại).
        /// </summary>
        public static bool Verify(string input, string stored)
        {
            if (input == null) input = string.Empty;
            if (string.IsNullOrEmpty(stored)) return false;

            if (!IsHashed(stored))
            {
                // Mật khẩu cũ dạng plaintext: so sánh trực tiếp (migration mềm).
                return input == stored;
            }

            var parts = stored.Split('$');
            if (parts.Length != 4) return false;

            if (!int.TryParse(parts[1], out int iterations)) return false;
            byte[] salt;
            byte[] expected;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expected = Convert.FromBase64String(parts[3]);
            }
            catch
            {
                return false;
            }

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                input, salt, iterations, HashAlgorithmName.SHA256, expected.Length);

            // So sánh theo thời gian cố định để tránh timing attack.
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
    }
}
