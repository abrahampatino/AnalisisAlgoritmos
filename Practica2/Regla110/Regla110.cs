using System;
using System.Linq;
using System.Collections.Generic;

namespace Regla110
{
    public class Regla110
    {
        List<String> items;
        int limite;
        public Regla110(String inicial)
        {
            items = new List<String>();
            Console.WriteLine(inicial.Length);
            limite = inicial.Length-3;
            items.Add(inicial);
        }

        public void EvaluaRegla(int tope)
        {
            int j = 0;
            while (j < tope)
            {
                var element = items.Last();
                var aux = new String("0");
                for (int i = 0; i <= limite; i++)
                //for (int i = 0; i < 27; i++)
                {
                    //Console.WriteLine(element.Substring(i, 3));
                    switch (element.Substring(i, 3))
                    {
                        case "000": aux += "0"; break;//0
                        case "001": aux += "1"; break;//1
                        case "010": aux += "1"; break;//2
                        case "011": aux += "1"; break;//3
                        case "100": aux += "0"; break;//4
                        case "101": aux += "1"; break;//5
                        case "110": aux += "1"; break;//6
                        case "111": aux += "0"; break;//7
                    }
                }
                aux += "0";
                items.Add(aux);
                j++;
            }
        }

        public void muestraRegla()
        {
            foreach (String element in items)
            {
                /*for (int i = 0; i < 30; i++)
                {
                    //Console.Write(element[i] == 0 ? (char)219 : (char)32);
                    Console.Write(element[i]);
                }*/
                Console.WriteLine(element);
            }
        }
    }
}
