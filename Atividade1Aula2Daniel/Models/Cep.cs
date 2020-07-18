
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Atividade1Aula2Daniel.Models
{

    [Table("CodigoPostal")]
    public class Cep
    {
        [Key]
        public int CepId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

    }
}
