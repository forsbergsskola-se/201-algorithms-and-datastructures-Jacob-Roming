using System.Collections;

namespace TurboCollections;


public class TurboLinkedStack<T> : IEnumerable<T>
{
    class Node {
        public T Value;
        public Node Previous;
    }
    Node LastNode;

    public void Push(T item) {
        // Create a new Node, so we can store the new number
        Node newNode = new Node();
        // Store the new number to the Node
        newNode.Value = item;
        // Have the Node remember the currently last node as its previous
        newNode.Previous = LastNode;
        // The new node is now the new last node
        LastNode = newNode;
    }

    public T Peek() {
        // Return the Value of Last Node here.
        return LastNode.Value;
    }

    public T Pop() {
        // 1. Save the Last Node locally so we can return the value later.
        // 2. Now, assign the Last Node's Previous Node to be the Last Node.
        // -- This effectively removes the previously Last Node of the Stack
        // -- Imagine LastNode is customer 436
        // -- -- who remembered that customer 435 was before him.
        // -- We assign that before customer 435 to LastNode.
        // -- -- 435 knows that 434 was before him.
        // -- -- But he has no memory of customer 436.

        Node whatWasLastNode = LastNode;
        LastNode = LastNode.Previous;
        return whatWasLastNode.Value;

        // Now, return the Value of the Node that you cached in Step 1.
    }

    public void Clear() {
        // This one is incredibly easy. Just assign null to Field LastNode
        // -- This is like pretending you never new that there is any last customer.
        // -- by forgetting the latest customer, you forget them all.
        LastNode = null;
    }

    public int Count {
        get{
            // Here, you need to do a while loop over all nodes
            // Similar to the previous PrintAllNodes Function
            // But instead of Printing Nodes, you just count how many Nodes you have visited
            // Similar to this:
            Node currentNode = LastNode;
            int count = 0;
            while(currentNode.Previous != null){
                count++;
                currentNode = currentNode.Previous;
            }
            return count;
        }
    }

     public IEnumerator<T> GetEnumerator() {
        // This one is a bonus and a bit more difficult.
        // You need to create a new class named Enumerator.
        // You find the details below.
        var enumerator = new Enumerator(){
            CurrentNode = null,
            // This might look confusing. But remember? Last In. First Out.
            FirstNode = LastNode
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
                CurrentNode = CurrentNode.Previous;
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
