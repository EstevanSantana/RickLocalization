using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickLocalization.Domain
{
    public class Viagem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ViagemId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(50)]
        public string TempoViagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(15)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public string Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Dimensao Dimensao { get; set; }
        
        public Rick Rick { get; set; }

        [ForeignKey("RickId")]
        public int RickId { get; set; }
    }
}
