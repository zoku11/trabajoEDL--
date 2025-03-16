using System;

class Puente
{
    public string Estructura { get; }

    public Puente(string estructura)
    {
        Estructura = estructura;
    }

    public bool EsValido()
    {
        if (string.IsNullOrEmpty(Estructura)) return false;

       
        if (Estructura[0] != '*' || Estructura[Estructura.Length - 1] != '*') return false;

        
        if (!EsSimetrico()) return false;

      
        return CumpleReglas();
    }

    private bool EsSimetrico()
    {
        string izquierda = Estructura.Substring(0, Estructura.Length / 2);
        string derecha = Estructura.Substring((Estructura.Length + 1) / 2);
        char[] derechaInvertida = derecha.ToCharArray();
        Array.Reverse(derechaInvertida);
        return izquierda == new string(derechaInvertida);
    }

    private bool CumpleReglas()
    {
        for (int i = 1; i < Estructura.Length - 1; i++)
        {
            if (Estructura[i] == '=')
            {
               
                if (i > 0 && i < Estructura.Length - 2 && Estructura[i - 1] == '=' && Estructura[i + 1] == '=')
                {
                    if (i > 1 && Estructura[i - 2] == '=' || i < Estructura.Length - 3 && Estructura[i + 2] == '=')
                    {
                        return false;
                    }
                }
            }
            else if (Estructura[i] == '+')
            {
               
                if (i == 0 || i == Estructura.Length - 1 || Estructura[i - 1] != '=' || Estructura[i + 1] != '=')
                {
                    return false;
                }
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el puente: ");
        string entrada = Console.ReadLine();
        Puente puente = new Puente(entrada);

        if (puente.EsValido())
            Console.WriteLine("VALIDO");
        else
            Console.WriteLine("INVALIDO");
    }
}
