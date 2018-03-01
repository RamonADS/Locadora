namespace VideoLocadora.Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aluguel")]
    public partial class Aluguel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aluguel()
        {
            Aluguel_Midia = new HashSet<Aluguel_Midia>();
        }

        public int ID { get; set; }

        public int ID_Cliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime Retirada { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Devolucao { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluguel_Midia> Aluguel_Midia { get; set; }
    }
}
