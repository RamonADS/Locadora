namespace VideoLocadora.Models
{
    public partial class Aluguel_Midia
    {
        public int ID { get; set; }

        public int ID_Aluguel { get; set; }

        public int ID_Midia { get; set; }

        public  Aluguel Aluguel { get; set; }

        public  Midia Midia { get; set; }
    }
}
