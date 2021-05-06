using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RickLocalization.Domain
{
    public class Dimensao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdDimencao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(50)]
        public string NomeDimensao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(50)]
        public string Planeta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(50)]
        public string Ano { get; set; }

        public int? RickId { get; set; }
        public Rick Rick { get; set; }

        public int? ViagemId { get; set; }
        public Viagem Viagem { get; set; }

    }
}
