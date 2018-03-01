namespace VideoLocadora.Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aluguel_Config
    {
        public int ID { get; set; }

        public double Valor { get; set; }
    }
}
