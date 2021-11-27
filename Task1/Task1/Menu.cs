using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task1
{
    class Menu
    {
        public void Run()
        {
            Clear();
            WriteLine("Enter the index of choosen option,then press Enter.");
            WriteLine("1.Build train\n2.View train\n3.Exit");

            string option = ReadLine();
        }

        public void BuildMenu()
        {
            Clear();
            WriteLine("1. 1A class (Passangers: 23; Luggage: 115 kg.)\n2. 1B class (Passangers: 52; Luggage: 364 kg.)\n3. 2A class (Passangers: 66; Luggage: 462 kg.)");
            string option = ReadLine();
        }
    }
}
