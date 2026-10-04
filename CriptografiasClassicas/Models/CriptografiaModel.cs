using CriptografiasClassicas.Models;

namespace CriptografiasClassicas.Models
{
    public class CriptografiaModel
    {
        public string Texto { get; set; } = "";

        public string Chave { get; set; } = "";

        public TipoCifra Cifra { get; set; } = TipoCifra.Cesar;

        public TipoOperacao Operacao { get; set; } = TipoOperacao.Criptografar;

        public string Resultado { get; set; } = "";
    }
}