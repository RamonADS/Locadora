using System.Collections.Generic;

namespace VideoLocadora.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public ICollection<Aluguel> Aluguel { get; set; }
    }
}
