namespace Alugueis_API.Utilities
{
    public class PasswordHelper
    {

        public PasswordHelper()
        {

        }
        public static void CriarSenhaHash(string senha, out byte[] hash, out byte[] salt)
        {
            if (string.IsNullOrEmpty(senha))
            {
                salt = null;
                hash = null;
                return;
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public static bool VerificarSenha(string senha, byte[] hashBanco, byte[] saltBanco)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(saltBanco))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return computedHash.SequenceEqual(hashBanco);
            }
        }
    }
}
