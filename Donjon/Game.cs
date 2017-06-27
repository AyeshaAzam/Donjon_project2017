using System;

namespace Donjon
{
    internal class Game
    {
        private int height;
        private int width;
        private bool quit = false;

        private Map map;
        private Hero hero; // ska ha koll på hero
        private string updateMessage = "";

        //Konstruktor som tar en width and height och har lagrat information i Instansen(obj)
        public Game(int Width, int height)
        {
            this.width = Width;

            this.height = height;
            Console.CursorVisible = false; // kommer vi inte ha fling effect
            Console.WindowWidth = width *2 + 5;
        }

        // internal works as long as i have in the same assembly, but if it was in different assembly then need to have 'public' instead internal.
        internal void Run()
        {
            //Initialisera 
            //hero = new Hero(health : 100);
            //hero.Damage = 10;

            //or we can do int thisway: // instruction
            //skapa hjälte som håller kol på obj/game
            hero = new Hero(health: 100)
            {
                Damage = 10
            };

            //skapat tom karta:
            map = new Map(width, height); // har samma bread och höjd som min instance av Game

            //placerat monster
            map.Populate();

            //gör en första utskrift/ på karta
            //map.Print(hero);
            Draw();
            
            

            //därefefter ska vi köra vår loop

            // (villkor) vi kör gamet så länge de...
            //bool quit = false;

            //så länge vi har inte upfyllt ....
            ////while not quit
            while (!quit)
            {
                UserInput();

                //uptadera spelobjekt
                update();

                //rita spelplan och övrig information
                // Console.Clear(); // otherwise it dot will fill up
                Draw();

                //avsluta slingan/loopen  // it will just draw dot in the map and nextline, for now
                //quit = true;
            }
        }

        private void update()
        {
            //den cell vi befinner i, ska kolla vad et finns i
            Cell cell = map.Cell(hero.X, hero.Y);
            GameObject obj = (GameObject)cell.Monster ?? cell.Item; // om object är null då blir det Monster eller ett item
            if(obj != null) // och om det är inte null då kör vi updateMesg
            {
               updateMessage = hero.Action(obj);
                // obj ska agera på Hero om det är en monster
                //updateMessage = obj.Action(hero);
                if (obj is Monster && (obj as Monster).Health > 0) updateMessage += obj.Action(hero);
                if (obj.RemoveFromCell) obj.RemoveFrom(cell);


               // Console.Write(message);
            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(0, 0); // x position and y position
            map.Print(hero); //samma kod och samma anrop som vi har ovan
            Console.WriteLine("Hero's health :" + hero.Health);
            Console.WriteLine("Hero's damage :" + hero.Damage);
            Cell currentCell = map.Cell(hero.X, hero.Y);

            // ska var monster eller item (gameobject är Monstret)
            GameObject content = (GameObject)currentCell.Monster ?? currentCell.Item;
            string message = " ";
            // om content inte lika med null då låter vår message  ska vara content name
            if(content != null)
            {
                message = $"You see a {content.Name}";
                // vi undersoker content , om det är sant eller false , is creature då lägger message 
                if(content is Creature)
                {
                    message += $"({(content as Creature).Health} hp)";
                }
            }
            // message is vara tomma sträng eller you see a content name ... eller you see creature and its health 
            Console.WriteLine(message.PadRight(Console.WindowWidth));
            Console.WriteLine(updateMessage.PadRight(Console.WindowWidth));
            updateMessage = "";

           


            /////////////////// this below gamla koden is ersätt med ovan kod:

            //var m = currentCell.Monster; // monster själva null
            //var i = currentCell.Item; //item själva null
            //if (m != null)                        // var/where i cellen Heros befinner sig
            //{
            //    Console.WriteLine($"You see a {m.Name } ({m.Health} hp)");
            //}
            //else if (i != null)
            //{
            //    Console.WriteLine($"You see a {i.Name }");
            //}
            //else
            //{
            //    Console.WriteLine(new string(' ', Console.WindowWidth));
            //}
            //////////////////////////////////////
        }

        private void UserInput() // ska hantera bara input från user och se innehåll förteckningar
        {
            //uppdate ( vi ska hantera indatafrån spelaren) läser in data från spelaren
            //hantera händelser/indata ( hämtar indata från spelaren)
            ConsoleKey key = Console.ReadKey(intercept: true).Key;   // läser in tangent key,knapp tryning på tangent. Console.ReadKey have inbuild parameter call intercept which is bool/Consolen ignoreran knapp tryckeningen (intercept:true)
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (hero.Y > 0) hero.Y--;  // which is Y-1   //if(hero.Y > 0 ) inte får gå till less then zero position
                    break;
                case ConsoleKey.DownArrow:
                    if (hero.Y < height - 1) hero.Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (hero.X > 0) hero.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (hero.X < width - 1) hero.X++;
                    break;
                case ConsoleKey.Q:  // det är representer av 'quit', come out of the game
                    quit = true;
                    break;
                case ConsoleKey.I:
                   updateMessage += hero.Inventory(); // hero.Inventory() ska retunera innehåll förteckningar som jag har
                    break;



                    //default:
            }
        }
    }
}



