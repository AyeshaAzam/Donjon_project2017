using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    //calss is abstract means we cannot create instance of it
    abstract class Item : GameObject
    {
        public Item(string name, string symbol, ConsoleColor color) : base(name, symbol, color)
        {
        }

       public  override string Action(GameObject obj)
        {
            throw new NotFiniteNumberException();
        }

        public override void RemoveFrom (Cell cell)
        {
            cell.Monster = null;
        }
    }

    //Coin kommer inte ha några parameter i sin Ctor
    //
    class Coin : Item
    {
        public Coin() : base("Coin ", "c", ConsoleColor.Yellow)
        {
        }
    }

    class Sock : Item
    {
        public Sock() : base("Old sock ", "s", ConsoleColor.Gray)
        {
        }
    }

    class Sword : Item
    {
        public Sword() : base("Sword ", "!", ConsoleColor.Blue)
        {
    }
}
}
