using System.Collections;

namespace TurboCollections;

public class TurboLinkedList<T> : ITurboList<T> {
    // This class is VERY similar to the TurboLinkedStack
    class Node {
        public T Value;
        // But we store the Next Node for each Node instead.
        public Node Next;
    }
    // Also, we store the first instead of the last Node. First Come, First Serve.
    Node FirstNode;

    public int Count { get; set; }

    public void Add(T value){
        // Check out Enqueue in 5.2 TurboLinkedQueue
        if (FirstNode == null)
        {
            FirstNode = new Node();
            FirstNode.Value = value;
        }
        else if (Count == 1)
        {
            Node newNode = new Node();
            newNode.Value = value;
            FirstNode.Next = newNode;
        }
        else
        {
            Node newNode = new Node();
            newNode.Value = value;

            Node currentNode = FirstNode;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

            }

            currentNode.Next = newNode;

        }

        Count++;
    }

    T ITurboList<T>.Get(int index)
    {
        return Get(index);
    }

    public void Set(int index, T value)
    {
        Node targetNode = FirstNode;
        for (int i = 0; i < index; i++)
        {
            if (targetNode.Next != null)
            {
                targetNode = targetNode.Next;
            }
            else
            {
                return;
            }
        }
        //When we get here target node should be the indexed node
        targetNode.Value = value;
    }

    public void Clear()
    {
        FirstNode = null;
        Count = 0;
    }

    public void RemoveAt(int index)
    {
        Node targetNode = FirstNode;
        Node nodeBefore = FirstNode;
        if (index == 0)
        {
            FirstNode = FirstNode.Next;
            return;
        }
        for (int i = 0; i < index; i++)
        {
            if (targetNode.Next != null)
            {
                nodeBefore = targetNode;
                targetNode = targetNode.Next;
            }
            else
            {
                return;
            }
        }

        nodeBefore.Next = targetNode.Next;
    }

    public bool Contains(T item)
    {
        Node targetNode = FirstNode;
        for (int i = 0; i < Count; i++)
        {
            if (targetNode != null)
            {
                if (targetNode.Value != null)
                {
                    if (targetNode.Value.Equals(item))
                    {
                        return true;
                    }

                }

                if (targetNode.Next != null)
                {
                    targetNode = targetNode.Next;
                }
            }
        }

        return false;
    }

    public int IndexOf(T item)
    {
        Node targetNode = FirstNode;
        FirstNode.Next.ToString();
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine("First node is" + FirstNode);
            if (targetNode.Value != null && targetNode != null)
            {
                Console.WriteLine("We are checking");
                if (targetNode.Value.Equals(item))
                {
                    return i;
                }
                    
            }
            
            if (targetNode.Next != null)
            {
                targetNode = targetNode.Next;
            }

        }

        return -1;
    }

    public void Remove(T item)
    {
        Node targetNode = FirstNode;
        Node lastNode = FirstNode;
        for (int i = 0; i < Count; i++)
        {
            
            if (targetNode.Value != null)
            {
                if (targetNode.Value.Equals(item))
                {
                    if (i == 0)
                    {
                        FirstNode = FirstNode.Next;
                    }
                    else
                    {
                        lastNode.Next = targetNode.Next;
                    }
                }
                    
            }
            
            if (targetNode.Next != null)
            {
                lastNode = targetNode;
                targetNode = targetNode.Next;
            }
        }
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
        if (index <= Count)
        {
            Node currentNode = FirstNode;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        return default;
    }


    // ...

    // Everything else is super similar to the TurboLinkedStack!
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(){
            CurrentNode = null,
            // This might look confusing. But remember? Last In. First Out.
            FirstNode = FirstNode
        };
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    class Enumerator : IEnumerator<T> {
        public Node CurrentNode;
        public Node FirstNode;

        public bool MoveNext(){
            // if we don't have a current node, we start with the first node
            if(CurrentNode == null){
                CurrentNode = FirstNode;
            } else
            {
                CurrentNode = CurrentNode.Next;
                // Assign the Current Node's Previous Node to be the Current Node.
            }

            return CurrentNode != null;
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
        }

        public T Current {
            get{
                // Return the Current Node's Value.
                return CurrentNode.Value;
            }
        }

        // This Boiler Plate is necessary to correctly implement `IEnumerable` interface.
        object IEnumerator.Current => Current;

        public void Reset() {
            // Look at Move. How can you make sure that this Enumerator starts over again?
            CurrentNode = FirstNode;
        }

        

        public void Dispose()
        {
            
        }
    }
}

public interface ITurboList<T> : IEnumerable<T> {
    // returns the current amount of items contained in the list.
    int Count { get; set; }
    // adds one item to the end of the list.
    void Add(T item);
    // gets the item at the specified index. If the index is outside the correct range, an exception is thrown.
    T Get(int index);
    // replaces the item at the specified index. If the index is outside the correct range, an exception is thrown.
    void Set(int index, T value);
    // removes all items from the list.
    void Clear();
    // removes one item from the list. If the 4th item is removed, then the 5th item becomes the 4th, the 6th becomes the 5th and so on.
    void RemoveAt(int index);
    // --------------- optional ---------------
    // returns true, if the given item can be found in the list, else false.
    bool Contains(T item);
    // returns the index of the given item if it is in the list, else -1.
    int IndexOf(T item);
    // removes the first instance of the specified item from the list, if it can be found. Works similar to RemoveAt.
    void Remove(T item);
    // adds multiple items ad the end of this list at once. Works similar to Add.
    void AddRange(IEnumerable<T> items);
}