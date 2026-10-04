namespace CriptografiasClassicas.Services
{
    public class CifraCesarService
    {
        public string Criptografar(string texto, int deslocamento)
        {
            string resultado = "";

            foreach (char caractere in texto)
            {
                if (char.IsLetter(caractere))
                {
                    char inicio = char.IsUpper(caractere) ? 'A' : 'a';

                    char novoCaractere = (char)(
                        (caractere - inicio + deslocamento) % 26 + inicio
                    );

                    resultado += novoCaractere;
                }
                else
                {
                    resultado += caractere;
                }
            }

            return resultado;
        }

        public string Descriptografar(string texto, int deslocamento)
        {
            return Criptografar(
                texto,
                26 - (deslocamento % 26)
            );
        }
    }
}