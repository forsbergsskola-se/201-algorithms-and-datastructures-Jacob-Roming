using TurboCollections;

namespace ListTestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IndexofTest()
    {
        TurboLinkedList<int> testList = new TurboLinkedList<int>();
        List<int> controlList = new List<int>();
        testList.Add(50);   controlList.Add(0);
        testList.Add(30);   controlList.Add(1);
        testList.Add(10);   controlList.Add(2);

        List<int> outputList = new List<int>();
        outputList.Add(testList.IndexOf(50));
        outputList.Add(testList.IndexOf(30));
        outputList.Add(testList.IndexOf(10));
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void ContainsTest()
    {
        TurboLinkedList<int> testList = new TurboLinkedList<int>();
        List<bool> controlList = new List<bool>();
        testList.Add(50);   controlList.Add(true);
        testList.Add(30);   controlList.Add(true);
        testList.Add(10);   controlList.Add(true);
        controlList.Add(false);

        List<bool> outputList = new List<bool>();
        outputList.Add(testList.Contains(50));
        outputList.Add(testList.Contains(30));
        outputList.Add(testList.Contains(10));
        outputList.Add(testList.Contains(2));
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void RemoveAtTest()
    {
        
        TurboLinkedList<int> testList = new TurboLinkedList<int>();
        List<int> controlList = new List<int>();
        testList.Add(2);
        testList.RemoveAt(0);
        testList.Add(50);   controlList.Add(0);
        testList.Add(30);   controlList.Add(1);
        testList.Add(500);  testList.RemoveAt(2);
        testList.Add(10);   controlList.Add(2);

        List<int> outputList = new List<int>();
        outputList.Add(testList.IndexOf(50));
        outputList.Add(testList.IndexOf(30));
        outputList.Add(testList.IndexOf(10));
        foreach (var variable in testList)
        {
            testList.Remove(variable);
        }

        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void RemoveTest()
    {
        TurboLinkedList<int> testList = new TurboLinkedList<int>();
        List<bool> controlList = new List<bool>();
        testList.Add(1);
        testList.Remove(1);
        testList.Add(50);   controlList.Add(true);
        testList.Add(30);   controlList.Add(true);
        testList.Add(999);
        testList.Add(10);   controlList.Add(true);
        testList.Add(2);    testList.Remove(2);
        controlList.Add(false);
        testList.Remove(999);
        controlList.Add(false);
        controlList.Add(false);

        List<bool> outputList = new List<bool>();
        outputList.Add(testList.Contains(50));
        outputList.Add(testList.Contains(30));
        outputList.Add(testList.Contains(10));
        outputList.Add(testList.Contains(2));
        outputList.Add(testList.Contains(1));
        outputList.Add(testList.Contains(999));
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void EnumerationTest()
    {
        TurboLinkedList<int> testList = new TurboLinkedList<int>();
        List<int> controlList = new List<int>();
        List<int> outputList = new List<int>();
        testList.Add(30); controlList.Add(30);
        testList.Add(40); controlList.Add(40);
        testList.Add(50); controlList.Add(50);

        foreach (var variable in testList)
        {
            outputList.Add(variable);
        }
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
     [Test]
    public void UnlinkedIndexofTest()
    {
        TurboList<int> testList = new TurboList<int>();
        List<int> controlList = new List<int>();
        testList.Add(50);   controlList.Add(0);
        testList.Add(30);   controlList.Add(1);
        testList.Add(10);   controlList.Add(2);

        List<int> outputList = new List<int>();
        outputList.Add(testList.IndexOf(50));
        outputList.Add(testList.IndexOf(30));
        outputList.Add(testList.IndexOf(10));
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void UnlinkedContainsTest()
    {
        TurboList<int> testList = new TurboList<int>();
        List<bool> controlList = new List<bool>();
        testList.Add(50);   controlList.Add(true);
        testList.Add(30);   controlList.Add(true);
        testList.Add(10);   controlList.Add(true);
        controlList.Add(false);

        List<bool> outputList = new List<bool>();
        outputList.Add(testList.Contains(50));
        outputList.Add(testList.Contains(30));
        outputList.Add(testList.Contains(10));
        outputList.Add(testList.Contains(2));
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void UnlinkedRemoveAtTest()
    {
        
        TurboList<int> testList = new TurboList<int>();
        List<int> controlList = new List<int>();
        testList.Add(2);
        testList.RemoveAt(0);
        testList.Add(50);   controlList.Add(0);
        testList.Add(30);   controlList.Add(1);
        testList.Add(500);  testList.RemoveAt(2);
        testList.Add(10);   controlList.Add(2);

        List<int> outputList = new List<int>();
        outputList.Add(testList.IndexOf(50));
        outputList.Add(testList.IndexOf(30));
        outputList.Add(testList.IndexOf(10));
        foreach (var variable in testList)
        {
            testList.Remove(variable);
        }

        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void UnlinkedRemoveTest()
    {
        TurboList<int> testList = new TurboList<int>();
        List<bool> controlList = new List<bool>();
        testList.Add(1);
        testList.Remove(1);
        testList.Add(50);   controlList.Add(true);
        testList.Add(30);   controlList.Add(true);
        testList.Add(999);
        testList.Add(10);   controlList.Add(true);
        testList.Add(2);    testList.Remove(2);
        controlList.Add(false);
        testList.Remove(999);
        controlList.Add(false);
        controlList.Add(false);

        List<bool> outputList = new List<bool>();
        outputList.Add(testList.Contains(50));
        outputList.Add(testList.Contains(30));
        outputList.Add(testList.Contains(10));
        outputList.Add(testList.Contains(2));
        outputList.Add(testList.Contains(1));
        outputList.Add(testList.Contains(999));
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }

    [Test]
    public void UnlinkedEnumerationTest()
    {
        TurboList<int> testList = new TurboList<int>();
        List<int> controlList = new List<int>();
        List<int> outputList = new List<int>();
        testList.Add(30); controlList.Add(30);
        testList.Add(40); controlList.Add(40);
        testList.Add(50); controlList.Add(50);

        foreach (var variable in testList)
        {
            outputList.Add(variable);
        }
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    
}