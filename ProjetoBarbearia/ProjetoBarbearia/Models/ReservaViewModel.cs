namespace ProjetoBarbearia.Models
{
    public class ReservaViewModel
    {
        public int ReservaId { get; set; }

        public DateTime DataHora { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual BarbeiroViewModel Barbeiro { get; set; }
    }
}
