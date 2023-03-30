using System.ComponentModel.DataAnnotations;
using WebAtividadeEntrevista.Validations;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        public long ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [CpfValidation(ErrorMessage = "Digite um CPF válido")]
        public string Cpf { get; set; }
    }
}