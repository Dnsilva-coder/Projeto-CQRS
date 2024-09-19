using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Eventos.IO.Application.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            Id = Guid.NewGuid();
            Endereco = new EnderecoViewModel();
            Categoria = new CategoriaViewModel();
        }

        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {0}")]
        [MaxLength(150, ErrorMessage = "O tamanho maximo do Nome é {0}")]
        [Display(Name = "Nome do Evento")]
        public string Nome { get; set; }
        [Display(Name = "Descricao curta do evento")]
        public string DescricaoCurta { get; set; }
        [Display(Name = "Descricao longa do evento")]
        public string DescricaoLonga { get; set; }
        [Display(Name = "Início do Evento")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Fim do Evento")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Será gratuito?")]
        public bool Gratuito { get; set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Valor { get; set; }
        [Display(Name = "Será online?")]
        public bool Online { get; set; }
        [Display(Name = "Empresa / Grupo Organizador")]
        public string NomeEmpresa { get; set; }
        public EnderecoViewModel? Endereco { get; set; }
        public CategoriaViewModel? Categoria { get; set; }

        public Guid CategoriaId { get; set; }
        public Guid OrganizadorId { get; set; }
    }
}
