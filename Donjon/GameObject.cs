using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
  
    
        internal abstract class GameObject : IDrawable
    {
          public string Symbol { get; protected set; } // symbol is private and private is set
          public ConsoleColor Color { get; set; }
          public string  Name { get; set; } //alla symbol som skapas har ett name, vi ville
          public bool RemoveFromCell = false; // plocka bort monster eller item


        //ska ge name ,symbol och färg
        public GameObject(string name, string symbol, ConsoleColor color)
        {
            Name = name;
            Symbol = symbol;
            Color = color;
        }

        // kan ha flera alternativ:
        //objekt vi kommer att intregera med kallas action
        //Vi skapar en action method i vår creature klass

        //'Action' kommer att retunera är att meddellande vad som hände och andra typ av förändringar ( typ true or false)
        //object.Action() ,example:  Hero.Action.Sock
        //alla Gameobjekt ska kunna utföra interaktion med varandra
        public abstract string Action(GameObject obj);

        public abstract void RemoveFrom(Cell cell); // om this is item då tar vi bort från cell

    }

}
