using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required]
        public string Local { get; set; }
        
        [DataType(DataType.DateTime)]
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "Necessário preencher o {0}.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} deve conter entre 5 e 50 caracteres.")]
        public string Tema { get; set; }
        
        [Display(Name = "Quantidade de pessoas")]
        [Required(ErrorMessage = "Necessário informar a {0}")]
        [Range(1,100000, ErrorMessage = "Valor possível entre 1 a 100.000 para {0}")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Insira uma imagem válida. (gif|jpg|jpeg|bmp|png) ")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "Necessário preencher o {0}.")]
        [Phone]
        public string Telefone { get; set; }
        
        [EmailAddress(ErrorMessage = "Insira um {0} válido.")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedeSociais { get; set; }
        public IEnumerable<PalestranteDto> PalestrantesEventos { get; set; }
    }
}