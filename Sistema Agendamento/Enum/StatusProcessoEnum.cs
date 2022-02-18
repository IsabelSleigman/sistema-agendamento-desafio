using System.ComponentModel.DataAnnotations;

namespace Sistema_Agendamento.Enum
{
    public enum StatusProcessoEnum
    {
        [Display(Name = "Inativo")]
        Inativo = 0,
        [Display(Name = "Ativo")]
        Ativo = 1,
    }
}
