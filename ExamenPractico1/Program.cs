using ExamenPractico1.Logic.Regla;
using ExamenPractico1.Logic.Turing;
using ExamenPractico1.Utilities.Turing;
using System;
using System.IO;

namespace ExamenPractico1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Automatas Celulares- Maquina");
            Console.WriteLine("Que regla desea ocupar: ");
            int regla = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("L: 1");
            Console.WriteLine("Automata Celular Regla " + regla);
            Console.Write("T: ");
            String entrada = Console.ReadLine();
            Console.Write("\n");
            ReglaNLogic automata;
            StreamReader file, file2;
            while (true)
            {

                automata = new ReglaNLogic(regla, entrada);
                automata.llenaTabla();
                automata.evaluaRegla(1);
                Console.WriteLine("\nREGLA");
                automata.muestraRegla();
                Console.WriteLine("\nMAQUINA");
                file = new StreamReader("../../../files/au01.txt");
                file2 = new StreamReader("../../../files/data.txt");
                entrada = file2.ReadLine();
                file2.Close();
                var transition = Parser.parse(file);
                file.Close();
                new Machine(entrada, transition).run();
                file2 = new StreamReader("../../../files/data.txt");
                entrada = file2.ReadLine();
                file2.ReadLine();
                file2.Close();
            }
        }
    }
}
