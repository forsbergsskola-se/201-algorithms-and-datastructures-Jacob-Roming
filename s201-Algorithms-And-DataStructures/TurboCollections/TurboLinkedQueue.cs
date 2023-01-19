using System.Collections;

namespace TurboCollections;

public class TurboLinkedQueue<T> : ITurboQueue<T> {
    // This class is VERY similar to the TurboLinkedStack
    class Node {
        public T Value;
        // But we store the Next Node for each Node instead.
        public Node Next;
    }
    // Also, we store the first instead of the last Node. First Come, First Serve.
    Node FirstNode;
    Node LastNode;

    public int Count { get; set; }

    public void Enqueue(T value){
        // This is a bit more complicated. You need to let the last Node in the Queue know who's next after him.
        // No other choice but looping through your Nodes until you reach the end.
        // You know that you've reached the end, if the current Node's Next Node is null.
        // Then, you assign a new Node containing the value to the current node's Next field.
        if (FirstNode != null)
        {
            Node newNode = new Node();
            newNode.Value = value;
            LastNode.Next = newNode;
            LastNode = newNode;
        }
        else
        {
            FirstNode = new Node();
            FirstNode.Value = value;
            LastNode = FirstNode;
        }

        Count += 1;
        // Analogy: In our store, we always remember who's the first that arrived. When a new customer arrives, we tell the last customer, that the new customer will be after them.
        // However, we only know, who's the first customer. And each customer knows, who comes after them. So we continue asking each customer, who comes after them, until one says: "No one! I'm last in the Queue" and we can tell them: "Not anymore! This new customer is now last in the queue"
    }

    public T Peek()
    {
        return FirstNode.Value;
    }

    public T Dequeue()
    {
        T toReturn = FirstNode.Value;
        FirstNode = FirstNode.Next;
        Count -= 1;
        return toReturn;
    }

    public void Clear()
    {
        FirstNode = null;
        LastNode = null; //I dont think this is needed but it calms the nerves
        Count = 0;
    }

    // Everything else is super similar to the TurboLinkedStack!
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(){
            CurrentNode = null,
            InitialNode = FirstNode
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
        public Node CurrentNode;
        public Node InitialNode;

        public bool MoveNext(){
            // if we don't have a current node, we start with the first node
            if(CurrentNode == null){
                CurrentNode = InitialNode;
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
            CurrentNode = InitialNode;
        }

        

        public void Dispose()
        {
            
        }
    }
}
public interface ITurboQueue<T> : IEnumerable<T> {
    // returns the current amount of items contained in the stack.
    int Count { get; set; }
    // adds one item to the back of the queue.
    void Enqueue(T item);
    // returns the item in the front of the queue without removing it.
    T Peek();
    // returns the item in the front of the queue and removes it at the same time.
    T Dequeue();
    // removes all items from the queue.
    void Clear();
}