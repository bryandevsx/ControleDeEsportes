using System.ComponentModel.DataAnnotations;

namespace ControleDeEsportes.Models
{
    public class EspacoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome da Empresa")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Digite o nome do Endereço")]
        public string Endereco { get; set;}
        [Required(ErrorMessage = "Digite o número de telefone")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string Telefone { get; set;}  
    }
}
