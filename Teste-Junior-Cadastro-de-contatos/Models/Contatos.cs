using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Junior_Cadastro_de_contatos.Models
{
    public class Contatos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(4, ErrorMessage = "name must contain at least {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [MinLength(8, ErrorMessage = "Phone Number should have {1} numbers ")]
        //NNNNNNNN, ENNNNNNNN, DDNNNN-NNNN, DDENNNN-NNNN
        [RegularExpression(@"^([1-9]{2})??(?:|9[1-9])([0-9]{3})\-?([0-9]{4}$)|(?:|9[1-9])([0-9]{3})?([0-9]{4}$)|([1-9]{2})(?:|[1-9])([0-9]{3})\-?([0-9]{4}$)|([1-9])([0-9]{3})([0-9]{4}$)", 
            ErrorMessage = "Phone number should follow patterns examples: 119xxxx-xxxx, 11xxxx-xxxx, 9xxxxxxxx or xxxxxxxx")]        
        public string Phone { get; set; }
    }
}
