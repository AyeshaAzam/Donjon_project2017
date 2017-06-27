using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class LimitedList<T> : IEnumerable<T>
    {
        // ett bakom liggande lista som kommer presentera internal list
        private List<T> items;


        
        public int Capacity { get; }

        public int Count => items.Count; // är samma sak om jag skriver : get return items Count


        public LimitedList(int capacity) 
        {
            Capacity = capacity;
            items = new List<T>(); 
        }

        
        public bool Add(T item) // ska ta vädet av T item
        {
            if (items.Count < Capacity) // om interna items count är mindre Capacitet 
            {
                items.Add(item); // då läggs item, (items som är vårt interna lista)
                return true; // talar den att det gick bra att lägga item
            }

            return false; 
        }


        //IEnumerable behöver inte kunna lägga ett obj
        // GetEnumerator() är reference för ett ....
        // 'IEnumerator<T> 'and 'IEnumerator' är två olika saker
       public IEnumerator<T> GetEnumerator() // retunerar IEnumerator<T> typen som är Generics
        {
            foreach (var item in items)
            {
                yield return item; 
            }
        }
 
        // om vi använder den nedan då behöver vi in <T>
        // vi skriver inte Public på denna explicit method/implementation och behöver båda metoder
        IEnumerator IEnumerable.GetEnumerator() // GetEnumerator() retunerar icke generics som är IEnumerator
        {
            return GetEnumerator(); // kommer att retunera the above foreach loop
        }
    }
}
