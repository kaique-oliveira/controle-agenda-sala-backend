namespace AgendaSala.Api.Controllers.FormatosAPI
{
    internal class retornoUsuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public retornoUsuario(string nome, string email, string tipo)
        {
            Nome=nome;
            Email=email;
            Tipo=tipo;
        }
    }
}
