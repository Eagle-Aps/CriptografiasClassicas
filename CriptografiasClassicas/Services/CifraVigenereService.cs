namespace CriptografiasClassicas.Services
{
    public class CifraVigenereService
    {
        public string Criptografar(string texto, string chave)
        {
            string resultado = "";
            int indiceChave = 0;

            chave = chave.ToUpper();

            foreach (char caractere in texto)
            {
                if (char.IsLetter(caractere))
                {
                    char inicio = char.IsUpper(caractere) ? 'A' : 'a';

                    int valorTexto = char.ToUpper(caractere) - 'A';
                    int valorChave = chave[indiceChave % chave.Length] - 'A';

                    int novoValor = (valorTexto + valorChave) % 26;

                    char novoCaractere = (char)(novoValor + inicio);

                    resultado += novoCaractere;

                    indiceChave++;
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
            int indiceChave = 0;

            chave = chave.ToUpper();

            foreach (char caractere in texto)
            {
                if (char.IsLetter(caractere))
                {
                    char inicio = char.IsUpper(caractere) ? 'A' : 'a';

                    int valorTexto = char.ToUpper(caractere) - 'A';
                    int valorChave = chave[indiceChave % chave.Length] - 'A';

                    int novoValor = (valorTexto - valorChave + 26) % 26;

                    char novoCaractere = (char)(novoValor + inicio);

                    resultado += novoCaractere;

                    indiceChave++;
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