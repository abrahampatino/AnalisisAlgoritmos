using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPractico1.Utilities.Turing
{
    public class Action
    {
        public String next_state;
        public String new_symbol;
        public String movement;

        public Action(String next_state, String new_symbol, String movement)
        {
            this.next_state = next_state;
            this.new_symbol = new_symbol;
            this.movement = movement;
        }
    }
}
