using System;
using System.Collections.Generic;
using System.IO;
using TuringMachine.Logic;
using TuringMachine.Logic.Utilities;
//using TuringMachine.Logic.Utilities.Action;

namespace TuringMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maquina de Turing! \n");
            StreamReader file = new StreamReader("../../../files/au01.txt");
            StreamReader file2 = new StreamReader("../../../files/data.txt");
            String entrada = file2.ReadLine();
            file2.Close();
            var transition = Parser.parse(file);
            file.Close();
            new Machine(entrada, transition).run();
        }
    }
}
