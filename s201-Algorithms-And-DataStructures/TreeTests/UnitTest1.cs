using TurboCollections;

namespace TreeTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TreeTest()
    {
        TurboTree<int> tree = new TurboTree<int>();
        TurboTree<int>.Node rootNode = tree.GetRoot();
        rootNode.setValue(1);
        rootNode.GetRightChild().setValue(2);
        rootNode.GetRightChild().GetRightChild().setValue(6);
        rootNode.GetLeftChild().setValue(1);
        rootNode.GetLeftChild().GetLeftChild().setValue(3);
        rootNode.GetLeftChild().GetRightChild().setValue(4);

        TurboList<int> testList = new TurboList<int>();
        testList.Add(tree.GetValue(0));
        
        
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(1);
        controlList.Add(2);
        controlList.Add(3);
        
        controlList.Add(4);
        controlList.Add(0);
        controlList.Add(0);
        controlList.Add(6);
        Assert.That(testList, Is.EqualTo(controlList));
    }

    [Test]
    public void HelloWorld()
    {
        TurboTree<int> tree = new TurboTree<int>();
        int rootNode = 0;
        int leftChild = tree.GetLeftChild(rootNode);
        int rightChildOfLeftChild = tree.GetRightChild(leftChild);
        
        
    }
}