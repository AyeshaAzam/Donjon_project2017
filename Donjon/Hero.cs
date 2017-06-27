using System;
using System.Collections.Generic;

namespace Donjon
{

    internal class Hero : Creature
    {
        public int X { get;  set; }
        public int Y { get;  set; }
        public LimitedList<Item> Backpack { get; private set; } = new LimitedList<Item>(2); // we can create new list here too ( this is possible with new version of Visual studio)


        //ctor
        public Hero(int health) : base("Hero", "H", ConsoleColor.White,health,100)  // hälsa bör vara obligatorist och inte noll
        {
            //    this.Health = health;
            //    this.Symbol = "H " ; // nu vet vi att hero har cell hantering
            //
        }

        public override string Action(GameObject obj)
        {
            string message = "";
            
            if (obj is Creature)// om obj är creature 
            {
                Creature creature = obj as Creature; // we have 'Casted' here 
                //då tar vi det och anfaller det
                //(obj as Creature).Health -= Damage; // minska hälsa med damage
                 creature.Health -= Damage;
                message = $" You attack the {creature.Name} for {Damage} damage. ";
                if(creature.Health <= 0)
                {
                    creature.RemoveFromCell = true;
                    message += $" and you killed it!";
                }

            }
            else if ( obj is Item)
            {
                Item item = obj as Item;
                 if(Backpack.Add(item))
                {
                    //tabort från cellen
                    item.RemoveFromCell = true; // this line will take out the symbol from map
                    message = $"You pick upp the {item.Name}.";
                }
                 else
                {
                    message = $"The backpack is full, so you couldn't pick up the {item.Name}.";
                }
                
            }
            
            return message;
        }

        public override void RemoveFrom(Cell cell)
        {
            throw new NotImplementedException();
        }

        internal string Inventory()
        {
            string message = $"Your backpack contains {Backpack.Count} items\n";
            //looping our backpack
            foreach (var item in Backpack)
            {
                message += " " + item.Name + "\n";
            }
            return message;
        }
    }

   
}