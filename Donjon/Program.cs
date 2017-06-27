using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class Program
    {
        static void Main(string[] args)
        {
            // skapar an instance of game and taller att spelet ska vara så mycket hojd och bred
            Game game = new Game(Width: 30, height: 15); // parameter namet width and height
            game.Run(); // method anrop
        }
    }
}
