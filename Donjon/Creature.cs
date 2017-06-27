using System;

namespace Donjon
{


    internal abstract class Creature : GameObject
    {
        //prop, hero har koll på sin position x&y, var den befinner sig
        public int Health { get; set; } //some (kommer ha )har dold backing field
        public int Damage { get; set; }


        public Creature(string name, string symbol, ConsoleColor color, int health, int damage) : base(name, symbol, color)
        {
            Health = health;
            Damage = damage;
        }

        public override string Action(GameObject obj)
        {
            string message = "";
            Creature creature = obj as Creature; // we have 'Casted' here 
            if (obj is Creature)// om obj är creature 
            {
                //då tar vi det och anfaller det
                //(obj as Creature).Health -= Damage; // minska hälsa med damage
                creature.Health -= Damage;
                message = $"The {Name} attacks the {creature.Name} for {Damage} damage. ";

            }
            return message;
        }

    }




}