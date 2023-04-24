using TurboCollections;

namespace TreeTests;

public class BinarySearchTreeTest
{
    [Test]
    public void TreeTest()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
       // BinarySearchTree<int>.Node rootNode = tree.GetRoot();
        tree.Insert(1);
        tree.Insert(50);
        tree.Insert(100);
        tree.Insert(49);

        TurboList<int> testList = new TurboList<int>();
        testList.Add(tree.GetValue(tree.Search(49)));
        
        
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(49);
        
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void TreeDeletingTest()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        // BinarySearchTree<int>.Node rootNode = tree.GetRoot();
        tree.Insert(1);
        tree.Insert(50);
        tree.Insert(100);
        tree.Insert(49);
        tree.Insert(20);
        tree.Insert(9999);
        tree.Insert(-1);

        tree.DeleteValue(100);
        tree.DeleteValue(-1);

        TurboList<int> testList = new TurboList<int>();
        testList.Add(tree.GetValue(tree.Search(49)));
        tree.DeleteValue(20);
        testList.Add(tree.GetValue(tree.Search(49)));
        testList.Add(tree.GetValue(tree.Search(9999)));
        
        
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(49);
        controlList.Add(49);
        controlList.Add(9999);
        Assert.Multiple(() =>
        {
            Assert.That(testList, Is.EqualTo(controlList));
            Assert.That(tree.Search(100), Is.EqualTo(-1));
        });
    }
    
    
    [Test]
    public void TreeEnumerationInOrderTest()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        // BinarySearchTree<int>.Node rootNode = tree.GetRoot();
        tree.Insert(1);
        tree.Insert(50);
        tree.Insert(100);
        tree.Insert(49);
        tree.Insert(20);
        tree.Insert(9999);
        tree.Insert(-1);


        TurboList<int> testList = new TurboList<int>();
        foreach (var VARIABLE in tree)
        {
            testList.Add(VARIABLE);
        }
        
        
        TurboList<IComparable> controlList = new TurboList<IComparable>();
        controlList.Add(1);
        controlList.Add(50);
        controlList.Add(100);
        controlList.Add(49);
        controlList.Add(20);
        controlList.Add(9999);
        controlList.Add(-1);
        TurboSort.QuickSort(controlList,0, controlList.Count - 1);
        Assert.Multiple(() =>
        {
            Assert.That(testList, Is.EqualTo(controlList));
        });
    }
    
    [Test]
    public void CloneTest()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        // BinarySearchTree<int>.Node rootNode = tree.GetRoot();
        tree.Insert(1);
        tree.Insert(50);
        tree.Insert(100);
        tree.Insert(49);
        tree.Insert(20);
        tree.Insert(9999);
        tree.Insert(-1);


        BinarySearchTree<int> clonedTree = tree.Clone();


        TurboList<IComparable> testList = new TurboList<IComparable>();
        foreach (var VARIABLE in clonedTree)
        {
            testList.Add(VARIABLE);
        }


        TurboList<IComparable> controlList = new TurboList<IComparable>();
        controlList.Add(1);
        controlList.Add(50);
        controlList.Add(100);
        controlList.Add(49);
        controlList.Add(20);
        controlList.Add(9999);
        controlList.Add(-1);
        TurboSort.QuickSort(controlList,0, controlList.Count - 1);
        Assert.Multiple(() =>
        {
            Assert.That(testList, Is.EqualTo(controlList));
        });
    }
    
    [Test]
    public void GetReverseOrderTest()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        // BinarySearchTree<int>.Node rootNode = tree.GetRoot();
        tree.Insert(1);
        tree.Insert(50);
        tree.Insert(100);
        tree.Insert(49);
        tree.Insert(20);
        tree.Insert(9999);
        tree.Insert(-1);

        


        TurboList<IComparable> testList = new TurboList<IComparable>();
        foreach (var VARIABLE in tree.GetInReverseOrder())
        {
            testList.Add(VARIABLE);
        }


        TurboList<IComparable> controlList = new TurboList<IComparable>();
        controlList.Add(9999);
        controlList.Add(100);
        controlList.Add(50);
        controlList.Add(49);
        controlList.Add(20);
        controlList.Add(1);
        controlList.Add(-1);
        //TurboSort.QuickSort(controlList,0, controlList.Count - 1);
        
        Assert.Multiple(() =>
        {
            Assert.That(testList, Is.EqualTo(controlList));
        });
    }
}