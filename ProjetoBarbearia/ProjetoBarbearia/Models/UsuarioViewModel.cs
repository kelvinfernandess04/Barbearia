namespace ProjetoBarbearia.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }
    }
}
