namespace VideoLocadora.Models
{
    using System.Collections.Generic;

    public partial class Midia
    {
        public Midia()
        {
            Aluguel_Midia = new List<Aluguel_Midia>();
        }

        public int ID { get; set; }

        public string Titulo { get; set; }

        public int? Copias { get; set; }

        public List<Aluguel_Midia> Aluguel_Midia { get; set; }
    }
}
