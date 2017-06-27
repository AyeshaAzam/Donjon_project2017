using System;

namespace Donjon
{
    internal class Cell :IDrawable
    {
        public Monster Monster { get; set; }
        public Item  Item { get; set; }

       // internal Coin Item;

        public ConsoleColor Color
        {
            get
            {
                // this whole thing(Monster ? .Color?? ConsoleColor.DarkGray;) will check if Monster is null or not, 
                // if Monster is NULL then return "ConsoleColor.DarkGray" otherwise return  .Color
                return Monster ? .Color ?? Item?.Color ?? ConsoleColor.DarkGray; //monster kan vara null och då det gåt inte ha färg. behöver kolla Null
            }
            set { }
        }


       
        //klassen ska retunera en symbol
        public string Symbol => Monster?.Symbol ?? Item?.Symbol ?? ".";
        //{
        //    get
        //    {     // getten ska retunera en punkt/ en tom Cell annrs retunerar.....
        //        // om Moster inte är null, då tar hela annars retunera null // det är Null ckeck
        //       return  Monster?.Symbol ?? Item?.Symbol ?? ".";
        //        //if (Monster == null) return "."; 
        //        //return Monster.Symbol; // or return symbol
        //    }
        // }
    }
}