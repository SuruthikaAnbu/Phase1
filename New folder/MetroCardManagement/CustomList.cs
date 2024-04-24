using System;
using System.Collections;
using System.Linq;

using System.Threading.Tasks;

namespace MetroCardManagement
{
    public  class CustomList<Type>:IEnumerable,IEnumerator
    {
        //field
        private  int _count;
        private  int _capacity;
        private  Type[] _array;
        //
        public  int Count { get{return _count;} }
        public  int Capacity { get{return _capacity;}}
        public  Type this[int index] 
        { get{return _array[index];}
         set{_array[index]=value;} }

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
        public void Add(Type value)
        {
            if(_count==_capacity)
            {
                growSize();
            }
            _array[_count]=value;
            _count++;

        }
        void growSize()
        {
            _capacity*=2;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
            
        }
        public void AddRange(CustomList<Type> values)
        {
            _capacity=_count+values.Count+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];

            }
            int j=0;
            for(int i=_count;i<_count+values.Count;i++)
            {
                temp[i]=values[j];
                j++;
            }
            _array=temp;
            _count=_count+values.Count;
        }
        //contains
        public bool Contains(Type value)
        {
            for(int i=0;i<_count;i++)
            {
                if(_array.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }
        //for each
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
        public object Current { get{return _array[position];}  }
        
        
    }
}