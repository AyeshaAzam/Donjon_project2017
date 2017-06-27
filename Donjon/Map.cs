using System;

namespace Donjon
{
    internal class Map
    {
        private int height;
        private int width;

        //behövs skapa Array[] of cell // two dimention array
        private Cell[,] cells;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            //instansiera 2d-cellvektorn
            // if we hade integer typ then we write: cells = new int[width, height]; but below is cells typ och cell värdet/tomt är null just nu
            cells = new Cell[width, height]; //skapar cells med two dimention  och kommer att ha w and h

            for (int x = 0; x < width; x++) // skapa gå till 0 till 9
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(); //tomma celler, new Cell()
                }
            }

        }

        //placerar ut monster
        internal void Populate()
        {
            //Polulate with different /olika typ of monster or placera olika typ av monster
            //var cell = cells[4, 7];
            cells[4, 7].Monster = new Orc();  // kommer att ha en monster reference och peka på 
            cells[7, 4].Monster = new Goblin();


            cells[5, 9].Item = new Coin(); // väljer cordinator
            cells[9, 5].Item = new Sock();
            cells[9, 9].Item = new Sword();
        }


        // som tar ut och ritar varje  kartan
        internal void Print(Hero hero) //skickar hero obj
        {
            //varje cell representerar av en punkt (.) avslutat med tecken....
            for (int y = 0; y < height; y++) // skapa gå till 0 till 9, have to change position to 'y'
            {
                //var row = " ";
                for (int x = 0; x < width; x++)
                {

                    IDrawable d;
                    //spacer /hantera mellanslag
                    //row += " ";


                    //finns det hjälte i denna cellen så print ut hjälte
                    if (x == hero.X  &&  y == hero.Y) //X and Y is public egenskaper 

                    {  // vi har en hjälte här som använder värdet H
                        //row += "  H";
                        d = hero;
                        //Console.Write(" " + hero.Symbol);
                    }
                    else
                    {
                        //bara en cell
                        // row += " .";  // annars skriver ut en punkt for now
                        // om vi har cell
                        d = cells[x, y];
                       // Console.Write(" " + cells[x, y].Symbol); // here cell haterar symbol hentering 
                    }

                     Console.ForegroundColor = d.Color;
                     Console.Write( " " + d.Symbol); // skriver ut tecknet
                     Console.ResetColor();
                }

                Console.WriteLine(); // printer vi ut raden
            }
        }

        internal Cell Cell(int x, int y) => cells[x, y];
          
        
    }

}