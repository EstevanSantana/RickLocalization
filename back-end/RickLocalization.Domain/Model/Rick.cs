using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RickLocalization.Domain
{
    public class Rick
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RickId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [MaxLength(10)]
        public string Status { get; set; }

        [MaxLength(10)]
        public string Morty { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Dimensao Origem { get; set; }

        public ICollection<Viagem> Viagens { get; set; }
    }
}
