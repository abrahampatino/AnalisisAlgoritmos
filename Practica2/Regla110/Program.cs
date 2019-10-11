using System;

namespace Regla110
{
    class Program
    {
        static void Main(string[] args)
        {
            String inicial = /*"001011110110111011111011111100";*/"110100001001000100000100000011";
            Console.WriteLine("Automata Celular Regla 110");
            Console.Write("L: ");
            int tope = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Automata Celular Regla 110");
            Console.Write("T: ");
            inicial = Console.ReadLine();
            Console.Write("\n");
            Regla110 regla = new Regla110(inicial);
            regla.EvaluaRegla(tope);
            regla.muestraRegla();
        }
    }
}
