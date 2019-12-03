using System;
using System.Numerics;
using FourierFT.Practica5.Utilities;


namespace FourierFT
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex[] input = { 1.0, 1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 0.0 };
            Complex[] input2 = { 1.0, 1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 0.0 };
            LogicFFT_Iterative.FFT(input);

            input2 = LogicFFT_Recursive.fft(input2);

            Console.WriteLine("Iterativo:");
            foreach (Complex c in input)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\nRecursivo:");

            foreach (Complex c in input2)
            {
                Console.WriteLine(c);
            }
        }
    }
}
