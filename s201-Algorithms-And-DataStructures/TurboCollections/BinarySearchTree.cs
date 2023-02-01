using System.Collections;

namespace TurboCollections;

public class BinarySearchTree<T> : IEnumerable<T> where T: IComparable 
{
    public T[] nodes;
    public bool[] isActive;
    public BinarySearchTree()
    {
        nodes = new T[1_000_000];
        isActive = new bool[1_000_000];
    }

    public int GetLeftChild(int index)
    {
        return index*2+1;
    }
    public int GetRightChild(int index)
    {
        return index*2+2;
    }
    
    public bool DeleteValue(T value)
    {
        int index = FindValue(value);
        if (index == -1)
        {
            return false;
        }

        /*var leave = GetRightChild(index);
        while (isActive(GetLeftChild(leave)) != -1)
        {
            leave = GetLeftChild(leave);
        }*/
        
        // now, you found the left leave and can use that node to reconnect everything

        isActive[index] = false;
        TurboList<T> toBeReadded = new TurboList<T>();
        for (int i = 0; i < nodes.Length; i++)
        {
            if (isActive[i] == true)
            {
                toBeReadded.Add(nodes[i]);
                isActive[i] = false;
            }
        }

        foreach (var variable in toBeReadded)
        {
            AddValue(variable);
        }

        return true;
    }

    public int FindValue(T value)
    {
        Node currentValue = GetRoot();
        if (currentValue.GetValue().CompareTo(value) == 0)
        {
            return currentValue.GetIndex();
        }

        int toReturn = -1;
        while (true)
        {
            Console.WriteLine("This is the value we are looking at: " + currentValue.GetValue());
            if (currentValue.GetActive() == false)
            {
                break;
            }
            if (currentValue.GetValue().CompareTo(value) == 0)
            {
                toReturn = currentValue.GetIndex();
                break;
            }
            else if (currentValue.GetValue().CompareTo(value) > 0)
            {
                currentValue = currentValue.GetLeftChild();
            }
            else
            {
                currentValue = currentValue.GetRightChild();
            }
        }
        return toReturn;
    }
    
    public T GetValue(int index)
    {
        return nodes[index];
    }

    private IEnumerable<T> CloneIterrator(Node n)
    {
        yield return n.GetValue();
        if(n.GetLeftChild().GetActive())
            CloneIterrator(n.GetLeftChild());
        if(n.GetRightChild().GetActive())
            CloneIterrator(n.GetRightChild());
    }

    public BinarySearchTree<T> Clone()
    {
        BinarySearchTree<T> newTree = new BinarySearchTree<T>();
        foreach (var VARIABLE in CloneIterrator(GetRoot()))
        {
            newTree.AddValue(VARIABLE);
        }

        return newTree;
    }

    public void AddValue(T value)
    {
        Node currentValue = GetRoot();
        if (currentValue.GetActive() == false)
        {
            currentValue.SetValue(value);
            return;
        }
        while (currentValue.GetActive())
        {
            if (currentValue.GetValue().CompareTo(value) > 0)
            {
                currentValue = currentValue.GetLeftChild();
            }
            else
            {
                currentValue = currentValue.GetRightChild();
            }
        }
        currentValue.SetValue(value);
    }

    public void SetRightChild(int index, T value)
    {
        nodes[index*2+2] = value;
    }
    
    public void SetLeftChild(int index, T value)
    {
        nodes[index*2+1] = value;
    }

    public Node GetRoot()
    {
        return new Node(0, this);
    }
    public struct Node
    {
        private int index;
        private BinarySearchTree<T> tree;
        public Node(int index, BinarySearchTree<T> tree)
        {
            this.tree = tree;
            this.index = index;
        }

        public Node GetLeftChild()
        {

            return new Node(tree.GetLeftChild(index), tree);
        }
        
        public Node GetRightChild()
        {

            return new Node(tree.GetRightChild(index), tree);
        }

        public void SetValue(T value)
        {
            tree.nodes[index] = value;
            tree.isActive[index] = true;
        }

        

        public T GetValue()
        {
            return tree.nodes[index];
        }

        public bool GetActive()
        {
            return tree.isActive[index];
        }

        public void SetActive(bool value)
        {
            tree.isActive[index] = value;
        }

        public int GetIndex()
        {
            return index;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(nodes, isActive, 0);
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator GetInOrder()
    {
        return GetEnumerator();
    }
    
    class Enumerator : IEnumerator<T>{
        public T[] Values;
        public bool[] Active;
        public int Arrayindex;
        private TurboList<IComparable> OrderedListOfElements = new TurboList<IComparable>();

        public Enumerator(T[] values, bool[] active, int arrayindex)
        {
            Values = values;
            Active = active;
            Arrayindex = arrayindex;
            for (int i = 0; i < Active.Length - 1; i++)
            {
                if (Active[i])
                {
                    OrderedListOfElements.Add(Values[i]);
                }
            }
            TurboSort.QuickSort(OrderedListOfElements,0,OrderedListOfElements.Count - 1);
        }

        public bool MoveNext()
        {
            if (Arrayindex < OrderedListOfElements.Count)
            {
                return true;
            }

            return false;
        }
        

        public T Current {
            get{
                // Return the Current Node's Value.
                return (T)OrderedListOfElements[Arrayindex++];
            }
        }

        object IEnumerator.Current => Current;

        public void Reset() {
            Arrayindex = 0;
        }

        public void Dispose()
        {
            
        }
    }
}