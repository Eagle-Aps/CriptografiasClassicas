using System.ComponentModel.DataAnnotations;

namespace CriptografiasClassicas.Models
{
    public enum TipoCifra
    {
        [Display(Name = "Cifra de César")]
        Cesar,

        [Display(Name = "Cifra de Vigenère")]
        Vigenere,

        [Display(Name = "Substituição Monoalfabética")]
        SubstituicaoMonoalfabetica,

        [Display(Name = "Rail Fence")]
        RailFence
    }
}