//Detects keyboard inputs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{


    internal class KeyManager
    {
        public KeyManager() { }
        ConsoleKeyInfo k = new();

        internal bool KeyPressed(ConsoleKey key, bool debug = false)
        {
            if (Console.KeyAvailable)
            {
                
                k = Console.ReadKey(!debug);
                if (k.Key == key)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
