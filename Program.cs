using System;

class CifraCezar
{

    public static void EncripCDC(ref string entrada, int saltos)
    {
        for (int i = 0; i < entrada.Length; i++)
        {
            if ((entrada[i] + saltos) > 240)
            {
                entrada = entrada.Remove(i, 1).Insert(i, ((char)(entrada[i] - 192)).ToString());
            }

            if ((entrada[i] + saltos) < 48)
            {
                entrada = entrada.Remove(i, 1).Insert(i, ((char)(entrada[i] + 192)).ToString());
            }

            entrada = entrada.Remove(i, 1).Insert(i, ((char)(entrada[i] + saltos)).ToString());
        }
    }

    // Verifica se o texto decifrado contém palíndromos
    public static bool ContemPalindromos(string entrada)
    {
        string[] palavras = entrada.Split(' ');

        foreach (string palavraAtual in palavras)
        {
            if (ePalindromo(palavraAtual))
            {
                return true;
            }
        }

        return false;
    }

    // Verifica se uma palavra é um palíndromo
    private static bool ePalindromo(string palavra)
    {
        return palavra == new string(palavra.Reverse().ToArray());
    }

    //Luiz Henrique Pereira Dos Santos

    // Decripta a entrada revertendo o processo de encriptação
    public static void DecriptCDC(ref string entrada, int saltos)
    {
        if(entrada.Length % 5 == 0) 
        {
            saltos = 8;
        }
        else
        {
            saltos = 16;
        }
        for (int i = 0; i < entrada.Length; i++)
        {
            if ((entrada[i] + saltos) > 240)
            {
                entrada = entrada.Remove(i, 1).Insert(i, ((char)(entrada[i] + 192)).ToString());
            }

            if ((entrada[i] + saltos) < 48)
            {
                entrada = entrada.Remove(i, 1).Insert(i, ((char)(entrada[i] - 192)).ToString());
            }

            entrada = entrada.Remove(i, 1).Insert(i, ((char)(entrada[i] - saltos)).ToString());
        }
        entrada = entrada.Replace('@', '\n');
    }

    static void Main()
    {
        string textoOriginal = "Lu0s z q0tm0uƒ€q~x ƒ40t ‚uy~t (~ 0†w|q~„mPe}q(†ytq(q‚q‚i0…}0uy~…„w0y‚‚m|u†qv„uPeu0q„qy…u0tm0 † (u}0†é‚yqƒ(s ‚u{0u0„i}q~xwƒPTqvt 0ri|qƒ0m0sywi‚‚ ƒ(u0sqz ~qƒ(q0uƒ|‚q~xwƒPSqz‚ ƒ0wƒƒ 0lyŠu~l 0ƒyuP_0ƒq~q|0o‚y„qvt 0~ë PTu~u0ƒuz0yƒƒw0 …u(sxq}i}0tu(‚uƒƒ}‚uy÷ë PPSi€y„qt0Y~ykyq|PZuƒƒ…z‚uy÷ë ";
        int saltos = 0;
        string[] palavras = textoOriginal.Split(' ');

        // Encripta o texto
        EncripCDC(ref textoOriginal, saltos);
        Console.WriteLine("Texto Encriptado: " + textoOriginal);

        // Decripta o texto
        DecriptCDC(ref textoOriginal, saltos);
        Console.WriteLine("\nTexto Decriptado: " + textoOriginal);

        // Verifica se o texto decifrado contém palíndromos
        bool contemPalindromos = ContemPalindromos(textoOriginal);

        if (contemPalindromos)
        {
            Console.WriteLine("\nO texto decifrado contém palíndromos.");
        }
        else
        {
            Console.WriteLine("\nO texto decifrado não contém palíndromos.");
        }


        Console.WriteLine("\nNúmero de Caracteres do Texto Decifrado: " + textoOriginal.Length);

        Console.WriteLine("Número de Palavras no Texto Decifrado: " + palavras.Length);

        Console.WriteLine("\nTexto Decifrado em Maiúsculas: " + textoOriginal.ToUpper());

    }
}