using System;
using System.Collections.Generic;
using System.IO;

namespace ExamenPractico1.Utilities.Turing
{
    public static class Parser
    {
        public static Dictionary<String, Action> parse(StreamReader file)
        {
            Dictionary<String, Action> transition = new Dictionary<String, Action>();
            String line = file.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = line.Replace(" ", "");
                int i = line.IndexOf("->");
                String keyState = line.Substring(0, i);
                keyState = keyState.Replace(",", "");
                line = line.Substring(i + 2);
                String[] array = line.Split(",");
                Action action = new Action(array[0], array[1], array[2]);
                transition.Add(keyState, action);
                line = file.ReadLine();
            }
            return transition;
        }
    }
}
