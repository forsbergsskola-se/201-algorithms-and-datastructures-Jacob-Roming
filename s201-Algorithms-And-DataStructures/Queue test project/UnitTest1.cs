using TurboCollections;

namespace Queue_test_project;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void QueueTest()
    {
        TurboLinkedQueue<int> numbers = new TurboLinkedQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(10);    controlList.Add(10);
        numbers.Enqueue(50);    controlList.Add(50);
        numbers.Enqueue(30);    controlList.Add(30);

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void Dequeue()
    {
        TurboLinkedQueue<int> numbers = new TurboLinkedQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(1); //This stuff will be removed later by the dequeue function
        numbers.Enqueue(2);
        numbers.Enqueue(40);    controlList.Add(40); //this is the stuff that should remain
        numbers.Enqueue(60);    controlList.Add(60);
        numbers.Enqueue(80);    controlList.Add(80);
        numbers.Dequeue();
        numbers.Dequeue();

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void Clear()
    {
        TurboLinkedQueue<int> numbers = new TurboLinkedQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(1); //This stuff will be removed later by the dequeue function
        numbers.Enqueue(2);
        numbers.Enqueue(40);
        numbers.Enqueue(60);
        numbers.Enqueue(80);    
        numbers.Clear();

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }

        Assert.Multiple(() =>
        {
            Assert.That(outputList, Is.EqualTo(controlList));
            Assert.That(numbers.Count, Is.EqualTo(0));
            try
            {
                numbers.Dequeue();
            }
            catch
            {
                Console.WriteLine("We got an exception");
            }
        });
    }
    
    [Test]
    public void Count()
    {
        TurboLinkedQueue<int> numbers = new TurboLinkedQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(99);
        numbers.Clear(); //Check if Clear resets the Count
        numbers.Enqueue(1); 
        numbers.Enqueue(2);
        numbers.Enqueue(40);    controlList.Add(40);
        numbers.Enqueue(60);    controlList.Add(60);
        numbers.Enqueue(80);    controlList.Add(80);
        numbers.Dequeue();//We need to use dequeue to make sure count is reduced properly
        numbers.Dequeue();

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }
         
        Assert.Multiple(() =>
        {
            Assert.That(outputList, Is.EqualTo(controlList));
            Assert.That(numbers.Count, Is.EqualTo(3));
        });
    }
    
    [Test]
    public void ArrayQueueTest()
    {
        TurboQueue<int> numbers = new TurboQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(10);    controlList.Add(10);
        numbers.Enqueue(50);    controlList.Add(50);
        numbers.Enqueue(30);    controlList.Add(30);

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void ArrayDequeue()
    {
        TurboQueue<int> numbers = new TurboQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(1); //This stuff will be removed later by the dequeue function
        numbers.Enqueue(2);
        numbers.Enqueue(40);    controlList.Add(40); //this is the stuff that should remain
        numbers.Enqueue(60);    controlList.Add(60);
        numbers.Enqueue(80);    controlList.Add(80);
        numbers.Dequeue();
        numbers.Dequeue();

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }
        
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void ArrayClear()
    {
        TurboQueue<int> numbers = new TurboQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(1); //This stuff will be removed later by the dequeue function
        numbers.Enqueue(2);
        numbers.Enqueue(40);  
        numbers.Enqueue(60);
        numbers.Enqueue(80);    
        numbers.Clear();

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }

        Assert.Multiple(() =>
        {
            Assert.That(outputList, Is.EqualTo(controlList));
            Assert.That(numbers.Count, Is.EqualTo(0));
            try
            {
                numbers.Dequeue();
            }
            catch
            {
                Console.WriteLine("We got an exception");
            }
        });
    }

    [Test]
    public void ArrayCount()
    {
        TurboQueue<int> numbers = new TurboQueue<int>();
        List<int> controlList = new List<int>();
        numbers.Enqueue(99);
        numbers.Clear(); //Check if Clear resets the Count
        numbers.Enqueue(1); 
        numbers.Enqueue(2);
        numbers.Enqueue(40);    controlList.Add(40);
        numbers.Enqueue(60);    controlList.Add(60);
        numbers.Enqueue(80);    controlList.Add(80);
        numbers.Dequeue();//We need to use dequeue to make sure count is reduced properly
        numbers.Dequeue();

        List<int> outputList = new List<int>();
        foreach (var number in numbers)
        {
            outputList.Add(number);
        }
        
        Assert.Multiple(() =>
        {
            Assert.That(outputList, Is.EqualTo(controlList));
            Assert.That(numbers.Count, Is.EqualTo(3));
        });
    }
}