using RandomUserApp.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomUserApp.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O primeiro nome do usuário é obrigatório")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O sobrenome do usuário é obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O CEP do usuário é obrigatório")]
        public int PostCode { get; set; }

        [Required(ErrorMessage = "Endereço é um campo obrigatório")]
        [StringLength(200, ErrorMessage = "Endereço não pode ter mais de 200 caracteres")]
        public string Address { get; set; }
        public Gender Gender { get; set; }

        public string Image { get; set; }
    }
}
