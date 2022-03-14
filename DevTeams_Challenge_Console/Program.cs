using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
    }
}
