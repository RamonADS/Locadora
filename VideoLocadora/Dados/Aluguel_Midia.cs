namespace VideoLocadora.Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aluguel_Midia
    {
        public int ID { get; set; }

        public int ID_Aluguel { get; set; }

        public int ID_Midia { get; set; }

        public virtual Aluguel Aluguel { get; set; }

        public virtual Midia Midia { get; set; }
    }
}
