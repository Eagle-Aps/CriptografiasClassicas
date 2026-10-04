using CriptografiasClassicas.Models;

namespace CriptografiasClassicas.Services
{
    public class CriptografiaService
    {
        private readonly CifraCesarService _cesar;
        private readonly CifraVigenereService _vigenere;
        private readonly CifraSubstituicaoService _substituicao;
        private readonly CifraRailFenceService _railFence;

        public CriptografiaService(
            CifraCesarService cesar,
            CifraVigenereService vigenere,
            CifraSubstituicaoService substituicao,
            CifraRailFenceService railFence)
        {
            _cesar = cesar;
            _vigenere = vigenere;
            _substituicao = substituicao;
            _railFence = railFence;
        }

        public string Executar(
            string texto,
            string chave,
            TipoCifra cifra,
            TipoOperacao operacao)
        {
            switch (cifra)
            {
                case TipoCifra.Cesar:
                    return ExecutarCesar(
                        texto,
                        chave,
                        operacao);

                case TipoCifra.Vigenere:
                    return ExecutarVigenere(
                        texto,
                        chave,
                        operacao);

                case TipoCifra.SubstituicaoMonoalfabetica:
                    return ExecutarSubstituicao(
                        texto,
                        chave,
                        operacao);

                case TipoCifra.RailFence:
                    return ExecutarRailFence(
                        texto,
                        chave,
                        operacao);

                default:
                    throw new ArgumentException("Cifra inválida.");
            }
        }

        private string ExecutarCesar(
            string texto,
            string chave,
            TipoOperacao operacao)
        {
            if (!int.TryParse(chave, out int deslocamento))
                throw new ArgumentException(
                    "A chave da Cifra de César deve ser um número.");

            if (operacao == TipoOperacao.Criptografar)
                return _cesar.Criptografar(texto, deslocamento);

            return _cesar.Descriptografar(texto, deslocamento);
        }

        private string ExecutarVigenere(
            string texto,
            string chave,
            TipoOperacao operacao)
        {
            if (string.IsNullOrWhiteSpace(chave))
                throw new ArgumentException(
                    "A chave não pode ser vazia.");

            if (operacao == TipoOperacao.Criptografar)
                return _vigenere.Criptografar(texto, chave);

            return _vigenere.Descriptografar(texto, chave);
        }

        private string ExecutarSubstituicao(
            string texto,
            string chave,
            TipoOperacao operacao)
        {
            if (chave.Length != 26)
                throw new ArgumentException(
                    "A chave deve possuir exatamente 26 letras.");

            if (operacao == TipoOperacao.Criptografar)
                return _substituicao.Criptografar(texto, chave);

            return _substituicao.Descriptografar(texto, chave);
        }

        private string ExecutarRailFence(
            string texto,
            string chave,
            TipoOperacao operacao)
        {
            if (!int.TryParse(chave, out int trilhos))
                throw new ArgumentException(
                    "A chave do Rail Fence deve ser um número.");

            if (trilhos < 2)
                throw new ArgumentException(
                    "A quantidade de trilhos deve ser pelo menos 2.");

            if (operacao == TipoOperacao.Criptografar)
                return _railFence.Criptografar(texto, trilhos);

            return _railFence.Descriptografar(texto, trilhos);
        }
    }
}