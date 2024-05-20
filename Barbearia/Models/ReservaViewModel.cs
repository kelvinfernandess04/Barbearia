using System;

namespace Barbearia.Models
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public int BarbeiroId { get; set; }
        public string Barbeiro { get; set; } // Nome do barbeiro
        public int ClienteId { get; set; }
        public string Cliente { get; set; } // Nome do cliente
    }
}
