using System;
using System.Collections.Generic;

namespace VideoLocadora.Models
{
    public partial class Aluguel
    {
        public Aluguel()
        {
            Aluguel_Midia = new List<Aluguel_Midia>();
            CodigosMidias = new List<int>();
            Cliente = new Cliente();
            Midias = new List<Midia>();
        }

        public int ID { get; set; }

        public int ID_Cliente { get; set; }

        public DateTime Retirada { get; set; }

        public DateTime? Devolucao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public List<Aluguel_Midia> Aluguel_Midia { get; set; }

        public List<Midia> Midias { get; set; }

        public List<int> CodigosMidias { get; set; }

    }
}
