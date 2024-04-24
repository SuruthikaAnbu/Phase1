using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public partial class CustomList<Type>
    {
        //count and capacity - create field and property
        private int _count;
        private int _capacity;
        private Type[] _array;
        //property
        public int Count { get{return _count;}}
        public int Capcity { get{return _capacity;}}
        
         
        public Type this[int index] 
        { get{return _array[index];}
         set{_array[index]=value;} }

        //Constructor
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
        //method1:add element
        public void Add(Type element)
        {
            if(_count==_capacity)
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

        //method 2:ADD range
        public void AddRange(CustomList<Type> elements)
        {
            _capacity=_capacity+elements.Count+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int i=_count;i<_count+elements._count;i++)
            {
                temp[i]=elements[k];
                k++;
            }
            _array=temp;
            _count=_count+elements.Count;
        }
        //method 3.contains
        public bool Contains(Type element)
        {
            bool temp=false;
            foreach(Type data in _array)
            {
                if(data.Equals(element))
                {
                    temp=true;
                    break;
                }
            }
            return temp;
        }
        //Index of
        public int IndexOf(Type element)
        {
            int index=-1;
            for(int i=0;i<_count;i++)
            {
                if(element.Equals(_array[i]))
                {
                    index=i;
                    break;
                }
            }
            return index;
        }
        //Inser()
        public void Insert(int position,Type element)
        {
            _capacity=_capacity+1+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count+1;i++)
            {
                if(i<position)
                {
                    temp[i]=_array[i];
                }
                else if(i==position)
                {
                    temp[i]=element;
                }
                else
                {
                    temp[i]=_array[i-1];
                }
            }
            _count++;
            _array=temp;
        }
        //Remove at
        // 0 1 2 3 4 5 6 7
        //4
        //0 1 2 3 5 6 7
        public void RemoveAt(int position)
        {
            for(int i=0;i<_count-1;i++)
            {
                if(i>=position)
                {
                    _array[i]=_array[i+1];
                }
            }
            _count--;
        }
        //6.Remove()
        public bool Remove(Type element)
        {
            int position=IndexOf(element);
            if(position>=0)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }
        //7.Reverse()
        public void Reverse()
        {
            Type[] temp=new Type[_capacity];
            int j=0;
            for(int i=_count-1;i>=0;i--)
            {
                temp[j]=_array[i];
                j++;
            }
            _array=temp;
        }
        //8.Insert range
        public void InsertRange(int position,CustomList<Type> elements)
        {
            _capacity=_count+elements.Count+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<position;i++)
            {
                temp[i]=_array[i];
            }
            int j=0;
            for(int i=position;i<position+elements.Count;i++)
            {
                temp[i]=elements[j];
                j++;
            }
            int k=0;
            for(int i=position+elements.Count;i<_count+elements.Count;i++)
            {
                temp[i]=_array[k];
                k++;
            }
            _array=temp;
            _count=_count+elements.Count;

        }
        //sorting
        public void Sort()
        {
            for(int i=0;i<_count-1;i++)
            {
                for(int j=0;j<_count-1;j++)
                {
                    if(IsGreater(_array[j],_array[j+1]))
                    {
                        Type temp=_array[j+1];
                        _array[j+1]=_array[j];
                        _array[j]=temp;
                    }
                }
            }
        }
        public bool IsGreater(Type value,Type value1)
        {
            int result=Comparer<Type>.Default.Compare(value,value1);
            if(result>0)
            {
                return true;
            }
            return false;
        }


    
        
    }
}