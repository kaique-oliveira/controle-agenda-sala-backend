
namespace AgendaSala.Auth.Servicos
{
    public static class AuthSenha
    {
        public static string CriarHashSenha(string senha)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(
                senha, BCrypt.Net.BCrypt.GenerateSalt(10));

            return hash;
        }

        public static bool CompararSenha(string hash, string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}