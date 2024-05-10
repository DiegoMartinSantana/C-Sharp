using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp
{ 
    
   public class Generics
    {

        public class myList<T>
        {
            private T[] _elements;
            private int _index=0;

            public myList(int size)
            {
                 _elements= new T[size];    
            }

            public void Add(T elementGeneric) {

                if (_index < _elements.Length)
                {
                    _elements[_index]=elementGeneric;
                   _index++;


                }

            }
            public T GetElement (int pos)
            {
                if(pos>=0 && pos < _elements.Length)
                {
                    return _elements[pos];
                }   
                return default(T); //retorna el valor por defecto del tipo de dato  
            }
            public string GetString()
            {

                int i = 0;

                string result = "";

                while(i<_index)
                {
                    result += _elements[i].ToString() +"|";
                    i++;
                }
                return result;
            }
        }
        

    }
}
