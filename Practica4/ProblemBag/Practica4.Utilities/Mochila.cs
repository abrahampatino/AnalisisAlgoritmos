using System;

namespace ProblemBag.Practica4.Utilities
{
    public class Mochila
    {
        int[] pesos;
        int[] value;
        int[,] matriz = new int[200,200];
        int peso;
        int sum = 0;

        public Mochila()
        {
            Console.WriteLine("Ingrese Peso Maximo: ");
            peso = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese # de elementos a iterar: ");
            var cant_elem = int.Parse(Console.ReadLine())+1;
            pesos = new int[cant_elem];
            value = new int[cant_elem];
            for (int i = 1; i < pesos.Length; i++)
            {
                Console.WriteLine("Ingrese Peso: ");
                pesos[i] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Valor: ");
                value[i] = Int32.Parse(Console.ReadLine());
            }
        }

        public void objetos()
        {
            var n = pesos.Length - 1;
            Console.WriteLine("\nMis Objetos");
            prueba(n, peso);
            Console.WriteLine("\nValor Total " + sum);
        }


        private void prueba(int j, int c)
        {
            if (j > 0)
            {
                if (c < pesos[j])
                {
                    prueba(j - 1, c);
                }
                else
                {
                    if ((matriz[j - 1,c - pesos[j]] + value[j]) > matriz[j - 1,c])
                    {
                        prueba(j - 1, c - pesos[j]);
                        Console.WriteLine("Se tiene objeto: " + pesos[j] + " Valor: " + value[j]);
                        
                        sum = value[j] + sum;
                    }
                    else
                    {
                        prueba(j - 1, c);
                    }
                }
            }
        }


        public void mochila()
        {
            int n = pesos.Length - 1;
            int c,  j;
            for (c = 0; c <= peso; c++)
            {
                matriz[0,c] = 0;
            }
            for (j = 1; j <= n; j++)
            {
                matriz[j,0] = 0;
            }
            for (j = 1; j <= n; j++)
            {
                for (c = 1; c <= peso; c++)
                {
                    if (c < pesos[j])
                    {
                        matriz[j,c] = matriz[j - 1,c];
                    }
                    else
                    {
                        if (matriz[j - 1, c] >= (matriz[j - 1 ,c - pesos[j]] + value[j]))
                        {
                            matriz[j,c] = matriz[j - 1,c];
                        }
                        else
                        {
                            matriz[j,c] = matriz[j - 1, c - pesos[j]] + value[j];
                        }
                    }
                }
            }
        }
    }
}
