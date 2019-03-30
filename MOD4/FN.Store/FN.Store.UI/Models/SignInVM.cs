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
        [Required]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}
