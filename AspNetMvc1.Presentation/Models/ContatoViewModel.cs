using System.ComponentModel.DataAnnotations;

namespace AspNetMvc1.Presentation.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string sobreNome { get; set; }

        [RegularExpression(@"^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$")]
        public string telefone { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string email { get; set; }

        public bool isSelected { get; set; }
    }
}