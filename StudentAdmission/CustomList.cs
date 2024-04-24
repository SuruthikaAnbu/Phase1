using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class CustomList<Type>:IEnumerable,IEnumerator
    {
        private  int _count;
        private  int _capacity;
        private  Type[] _array;
        public int Count { get{return _count;} }
        public int Capacity { get{return _capacity;} }
        public Type this[int index]
        { get{return _array[index];} 
        
         set{_array[index] =value;}
         }
         //constructor
         public CustomList()
         {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
         }
          public CustomList(int size)
         {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
         }
         //add
         public void Add(Type element)
         {
            if(_capacity==_count)
            {
                GrowSize();
            }
            _array[_count]=element;
            _count++;
            
         }
         void GrowSize()
         {
            _capacity*=2;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
         }
         public void AddRange(CustomList<Type> elements)
         {
            _capacity=_count+elements.Count+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int j=0;
            for(int i=_count;i<_count+elements.Count;i++)
            {
                temp[i]=elements[j];
                j++;
            }
            _array=temp;
            _count=_count+elements.Count;
         }
         //for each------------------
         int position;
         public IEnumerator GetEnumerator()
         {
            position=-1;
            return (IEnumerator)this;
         }
         public bool MoveNext()
         {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
         }
         public void Reset()
         {
            position=-1;
         }
         public object Current{get {return _array[position];}}
    }
}