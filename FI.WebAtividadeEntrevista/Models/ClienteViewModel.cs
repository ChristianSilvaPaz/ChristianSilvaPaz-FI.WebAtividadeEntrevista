using FI.AtividadeEntrevista.DML;
using System.Collections.Generic;

namespace WebAtividadeEntrevista.Models
{
    public class ClienteViewModel : ClienteModel
    {
        public List<Beneficiario> beneficiarios { get; set; }
    }
}