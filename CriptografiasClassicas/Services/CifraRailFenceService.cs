namespace CriptografiasClassicas.Services
{
    public class CifraRailFenceService
    {
        public string Criptografar(string texto, int trilhos)
        {
            if (trilhos <= 1)
                return texto;

            string[] linhas = new string[trilhos];

            int linha = 0;
            int direcao = 1;

            foreach (char caractere in texto)
            {
                linhas[linha] += caractere;

                if (linha == 0)
                    direcao = 1;
                else if (linha == trilhos - 1)
                    direcao = -1;

                linha += direcao;
            }

            return string.Concat(linhas);
        }

        public string Descriptografar(string texto, int trilhos)
        {
            if (trilhos <= 1)
                return texto;

            int[] padrao = new int[texto.Length];

            int linha = 0;
            int direcao = 1;

            for (int i = 0; i < texto.Length; i++)
            {
                padrao[i] = linha;

                if (linha == 0)
                    direcao = 1;
                else if (linha == trilhos - 1)
                    direcao = -1;

                linha += direcao;
            }

            int[] quantidade = new int[trilhos];

            foreach (int posicao in padrao)
            {
                quantidade[posicao]++;
            }

            string[] linhas = new string[trilhos];

            int indice = 0;

            for (int i = 0; i < trilhos; i++)
            {
                linhas[i] = texto.Substring(
                    indice,
                    quantidade[i]
                );

                indice += quantidade[i];
            }

            int[] indices = new int[trilhos];

            string resultado = "";

            foreach (int posicao in padrao)
            {
                resultado += linhas[posicao][indices[posicao]];

                indices[posicao]++;
            }

            return resultado;
        }
    }
}