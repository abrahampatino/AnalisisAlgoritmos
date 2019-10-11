using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenPractico1.Logic.Regla
{
    public class ReglaNLogic
    {
        private int regla;
        private int limite;
        List<String> items;
        char[] valores;
        public ReglaNLogic(int regla, String inicial)
        {
            items = new List<String>();
            this.regla = regla;
            items.Add(inicial);
            limite = inicial.Length - 3;
            valores = new char[8];
        }

        public void llenaTabla()
        {
            int i = 0;
            while (regla > 0)
            {
                if (regla % 2 == 0)
                {

                    valores[i] = '0';
                }
                else
                {

                    valores[i] = '1';
                }
                regla = (int)(regla / 2);
                i++;
            }
            while (i <= 7)
            {
                valores[i] = '0';
                i++;
            }
            /*tabla_verdad.Add(new EstructuraAutomata('0', '0', '0', valores[7]));
            tabla_verdad.Add(new EstructuraAutomata('0', '0', '1', valores[6]));
            tabla_verdad.Add(new EstructuraAutomata('0', '1', '0', valores[5]));
            tabla_verdad.Add(new EstructuraAutomata('0', '1', '1', valores[4]));
            tabla_verdad.Add(new EstructuraAutomata('1', '0', '0', valores[3]));
            tabla_verdad.Add(new EstructuraAutomata('1', '0', '1', valores[2]));
            tabla_verdad.Add(new EstructuraAutomata('1', '1', '0', valores[1]));
            tabla_verdad.Add(new EstructuraAutomata('1', '1', '1', valores[0]));
            Console.WriteLine(tabla_verdad[0].toString());*/
        }

        public void evaluaRegla(int tope)
        {
            int j = 0;
            while (j < tope)
            {
                var element = items.Last();
                var aux = new String("0");
                for (int i = 0; i <= limite; i++)
                {


                    switch (element.Substring(i, 3))
                    {
                        case "000": aux += valores[7]; break;//0
                        case "001": aux += valores[6]; break;//1
                        case "010": aux += valores[5]; break;//2
                        case "011": aux += valores[4]; break;//3
                        case "100": aux += valores[3]; break;//4
                        case "101": aux += valores[2]; break;//5
                        case "110": aux += valores[1]; break;//6
                        case "111": aux += valores[0]; break;//7
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
                Console.WriteLine(element);
            }
            grabaArchivo();
        }

        public void grabaArchivo()
        {
            System.IO.File.WriteAllText(@"../../../files/data.txt", items[1]);
        }
    }
}
