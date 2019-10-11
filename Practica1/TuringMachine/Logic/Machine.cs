using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using TuringMachine.Logic.Utilities;

namespace TuringMachine.Logic
{
    class Machine
    {
        private String estadoActual;
        private int cursor;
        private String entrada;
        private Dictionary<String, Utilities.Action> transicion;
        public List<String> cinta;
        private Boolean pasos = false;
        private static String ESPACIO_BLANCO = "B";
        private String ESTADO_FINAL = "qf";
        private char [] lenguaje = { '0', '1' };


        public Machine(String entrada, Dictionary<String, Utilities.Action> transicion)
        {
            this.entrada = entrada;
            this.transicion = transicion;
            cinta = new List<String>();
            init();
        }


        private void init()
        {
            for (int i = 0; i < entrada.Length; i++)
            {
                if (lenguaje[0].Equals( entrada[i] ) || lenguaje[1].Equals(entrada[i]) )
                {
                    cinta.Add(entrada[i].ToString());
                }
            }
            cinta.Add(ESPACIO_BLANCO);
            cursor = 0;
            estadoActual = "q1";
        }

        public void run()
        {
            while (true)
            {
                //display();
                /*if (cursor == 0)
                {
                    paso_derecha();
                    cursor = 1;
                }*/
                Utilities.Action action;
                String key = estadoActual + cinta[cursor];
                if ((action = transicion.GetValueOrDefault(key)) != null)
                {
                    execute(action);
                    if (estadoActual.Equals(ESTADO_FINAL))
                    {
                        stop();
                        break;
                    }
                }
                else
                {
                    stop();
                    break;
                }

            }
            muestraCinta();
        }

        private void paso_derecha()
        {          
            for (int i = cinta.Count - 1; i > 0; i--)
            {
                
                Swap(cinta, i, i - 1);
            }
        }


        private List<String> Swap(List<String> list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public void execute(Utilities.Action accion)
        {
            cinta[cursor] = accion.new_symbol;
            estadoActual = accion.next_state;
            cursor += accion.movement.Equals("R") ? 1 : -1;
        }

        public void stop()
        {
            if (estadoActual.Equals(ESTADO_FINAL))
            {
                Console.WriteLine("Ok- Estado Final");
            }
            else
            {
                Console.WriteLine("OK");
            }
        }
        /*
        public void display()
        {
            foreach(var item in cinta)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("| estado: " + estadoActual);
            for (int i = 0; i < cinta.Count; i++)
            {
                Console.Write(" ");
                if (i == cursor)
                {
                    Console.Write("^");
                    break;
                }
                Console.Write("");
            }
            Console.Write("\n");

            
            // paso_derecha();
            //Console.WriteLine(cinta);
        }*/

        public void muestraCinta()
        {
            Console.WriteLine(entrada);
            var aux = "";

            foreach (String item in cinta)
            {
                Console.Write(item);
                if(item == "0" || item == "1")
                {
                    aux+= item;
                }
            }
            System.IO.File.WriteAllText(@"../../../files/data.txt", aux);
        }

    }
}
