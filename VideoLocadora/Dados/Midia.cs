namespace VideoLocadora.Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Midia")]
    public partial class Midia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Midia()
        {
            Aluguel_Midia = new HashSet<Aluguel_Midia>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Titulo { get; set; }

        public int? Copias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluguel_Midia> Aluguel_Midia { get; set; }
    }
}
