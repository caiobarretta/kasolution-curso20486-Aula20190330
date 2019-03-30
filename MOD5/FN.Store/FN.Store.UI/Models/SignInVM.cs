using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{
    public class SignInVM
    {
        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Limite Excedido")]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(10, ErrorMessage = "Limite Excedido")]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}
