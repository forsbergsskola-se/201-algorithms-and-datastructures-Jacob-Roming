namespace TurboCollections;

public class TurboTree<T> where T: IComparable
{
    private T[] nodes;

    public TurboTree()
    {
        nodes = new T[1_000_000];
    }

    public int GetLeftChild(int index)
    {
        return index*2+1;
    }
    public int GetRightChild(int index)
    {
        return index*2+2;
    }

    public T GetValue(int index)
    {
        return nodes[index];
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
        private TurboTree<T> tree;
        public Node(int index, TurboTree<T> tree)
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

        public void setValue(T value)
        {
            tree.nodes[index] = value;
        }
    }
}