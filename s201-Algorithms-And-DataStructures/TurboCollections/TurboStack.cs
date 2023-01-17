using System.Collections;

namespace TurboCollections;

public class TurboStack<T> : IEnumerable<T>
{
    private static T[] data;
    private static int dataLength = 0;
    public void Push(T value){
        if (data == null)
        {
            data = new T[1];
            data[0] = value;
            dataLength = 1;
        }
        else
        {
            T[] oldData = data;
            if (data.Length == dataLength)
            {
                data = new T[data.Length * 2];
                for (int i = 0; i < dataLength; i++)
                {
                    data[i] = oldData[i];
                }
            }

            

            data[dataLength] = value;
            dataLength++;
        }
    }

    public T Pop()
    {
        T toReturn;
        
        toReturn = data[dataLength-1];
        dataLength--;
        

        return toReturn;
    }

    public T Peek()
    {
        return data[dataLength - 1];
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(){
            CurrentNode = dataLength,
            // This might look confusing. But remember? Last In. First Out.
           // FirstNode = LastNode
        };
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    class Enumerator : IEnumerator<T> {
        public int CurrentNode;

        public bool MoveNext(){
            // if we don't have a current node, we start with the first node
            if(CurrentNode == null){
                CurrentNode = dataLength;
            } else
            {
                CurrentNode--;
            }

            return CurrentNode != -1;
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
        }

        public T Current {
            get{
                // Return the Current Node's Value.
                return data[CurrentNode ];
            }
        }

        // This Boiler Plate is necessary to correctly implement `IEnumerable` interface.
        object IEnumerator.Current => Current;

        public void Reset() {
            // Look at Move. How can you make sure that this Enumerator starts over again?
            CurrentNode = dataLength - 1;
        }

        

        public void Dispose()
        {
            
        }
    }
}