namespace CriptografiasClassicas.Services
{
    public class CifraSubstituicaoService
    {
        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Criptografar(string texto, string chave)
        {
            string resultado = "";

            for (int i = 0; i < texto.Length; i++)
            {
                char caractere = texto[i];

                if (char.IsLetter(caractere))
                {
                    bool maiuscula = char.IsUpper(caractere);

                    char caractereMaiusculo = char.ToUpper(caractere);

                    int posicao = Alfabeto.IndexOf(caractereMaiusculo);

                    char novoCaractere = chave[posicao];

                    resultado += maiuscula
                        ? novoCaractere
                        : char.ToLower(novoCaractere);
                }
                else
                {
                    resultado += caractere;
                }
            }

            return resultado;
        }

        public string Descriptografar(string texto, string chave)
        {
            string resultado = "";

            for (int i = 0; i < texto.Length; i++)
            {
                char caractere = texto[i];

                if (char.IsLetter(caractere))
                {
                    bool maiuscula = char.IsUpper(caractere);

                    char caractereMaiusculo = char.ToUpper(caractere);

                    int posicao = chave.IndexOf(caractereMaiusculo);

                    char novoCaractere = Alfabeto[posicao];

                    resultado += maiuscula
                        ? novoCaractere
                        : char.ToLower(novoCaractere);
                }
                else
                {
                    resultado += caractere;
                }
            }

            return resultado;
        }
    }
}