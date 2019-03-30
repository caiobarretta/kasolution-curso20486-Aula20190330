using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{
    [Table(nameof(Produto))]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Tipo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
