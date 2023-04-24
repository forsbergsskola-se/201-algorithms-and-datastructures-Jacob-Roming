using System.Collections;

namespace TurboCollections;

public class TurboQueue<T> : ITurboQueue<T>
{
    // This class is VERY similar to the TurboLinkedStack
    private T[] values;

    public int Count { get; set; }

    public void Enqueue(T value){
        // This is a bit more complicated. You need to let the last Node in the Queue know who's next after him.
        // No other choice but looping through your Nodes until you reach the end.
        // You know that you've reached the end, if the current Node's Next Node is null.
        // Then, you assign a new Node containing the value to the current node's Next field.
        if (values != null)
        {
            if (values.Length >= Count - 1)
            {
                T[] old = values;
                values = new T[values.Length * 2];
                for (int i = 0; i < old.Length; i++)
                {
                    values[i] = old[i];
                }

                values[Count] = value;
            }
            else
            {
                values[Count] = value;
            }
        }
        else
        {
            values = new T[1];
            values[0] = value;
            
        }

        Count += 1;
        // Analogy: In our store, we always remember who's the first that arrived. When a new customer arrives, we tell the last customer, that the new customer will be after them.
        // However, we only know, who's the first customer. And each customer knows, who comes after them. So we continue asking each customer, who comes after them, until one says: "No one! I'm last in the Queue" and we can tell them: "Not anymore! This new customer is now last in the queue"
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new Exception("There is no value to peek at");
        }
        return values[0];
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new Exception("There are no values to dequeue");
        }
        T toReturn = values[0];
        for (int i = 0; i < Count - 1; i++)
        {
            values[i] = values[i + 1];
        }
        Count -= 1;
        return toReturn;
    }

    public void Clear()
    {
        values = null;
        Count = 0;
    }
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(){
            CurrentNode = 0,
            NumberOfElements = Count,
            valuesArray = values
            // This might look confusing. But remember? Last In. First Out.
            //FirstNode = 
        };
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    class Enumerator : IEnumerator<T> {
        public int CurrentNode;
        public int NumberOfElements;
        public T[] valuesArray;

        public bool MoveNext(){
            // if we don't have a current node, we start with the first node
            if (CurrentNode != NumberOfElements)
            {
                CurrentNode++;
                return true;
            }
            else
            {
                return false;
            }
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
        }

        public T Current {
            get{
                // Return the Current Node's Value.
                Console.WriteLine("Trying to access value " + (CurrentNode - 1));
                return valuesArray[CurrentNode - 1];
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

