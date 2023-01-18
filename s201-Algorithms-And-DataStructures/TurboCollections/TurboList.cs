
using System.Collections;

namespace TurboCollections;

public class TurboList<T> : ITurboList<T> {
    // This class is VERY similar to the TurboLinkedStack
    private T[] values;
    // Also, we store the first instead of the last Node. First Come, First Serve.


    public int Count { get; set; }

    public void Add(T value){
        // Check out Enqueue in 5.2 TurboLinkedQueue
        if (values == null)
        {
            values = new T[1];
            values[0] = value;
            Count++;
        }
        else if (values.Length >= Count - 2)
        {
            T[] old = values;
            values = new T[values.Length * 2];
            for (int i = 0; i < old.Length; i++)
            {
                values[i] = old[i];
            }
            values[Count] = value;
            Count++;
        }
        else
        {
            values[Count] = value;
            Count++;
        }

    }

    T ITurboList<T>.Get(int index)
    {
        return Get(index);
    }

    public void Set(int index, T value)
    {
        values[index] = value;
    }

    public void Clear()
    {
        values = null;
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < Count - 1; i++)
        {
            values[i] = values[i + 1];
        }

        Count--;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (values[i] != null)
            {
                if (values[i].Equals(item))
                {
                    return true;
                }
                    
            }
            
        }

        return false;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (values[i].Equals(item))
            {
                return i;
            }

        }

        throw new Exception("That item does not exist");
    }

    public void Remove(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (values[i].Equals(item))
            {
                for (int j = i; j < Count - 1; j++)
                {
                    values[j] = values[j + 1];
                }
                Count--;
                return;
            }
        }

        throw new Exception("That item does not exist");
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (var variable in items)
        {
            Add(variable);
        }
    }

    T Get(int index)
    {
        if (index < Count)
        {
            return values[index];
        }

        throw new Exception("Index out of bounds");
    }


    // ...

    // Everything else is super similar to the TurboLinkedStack!
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(){
            CurrentNode = 0,
            // This might look confusing. But remember? Last In. First Out.
            valuesArray = values,
            MaxValue = Count
        };
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    class Enumerator : IEnumerator<T> {
        public int CurrentNode;
        public int MaxValue;
        public T[] valuesArray;

        public bool MoveNext(){
            // if we don't have a current node, we start with the first node
            if(CurrentNode == null){
                CurrentNode = 0;
            } else
            {
                CurrentNode++;
                // Assign the Current Node's Previous Node to be the Current Node.
            }

            return CurrentNode != MaxValue - 1;
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
        }

        public T Current {
            get{
                // Return the Current Node's Value.
                return valuesArray[CurrentNode];
            }
        }

        // This Boiler Plate is necessary to correctly implement `IEnumerable` interface.
        object IEnumerator.Current => Current;

        public void Reset() {
            // Look at Move. How can you make sure that this Enumerator starts over again?
            CurrentNode = 0;
        }

        

        public void Dispose()
        {
            
        }
    }
}