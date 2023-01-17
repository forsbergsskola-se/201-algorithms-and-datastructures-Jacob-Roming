namespace TurboCollections.Test;



public class MathsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SayHelloExists()
    {
        TurboMaths.SayHello();
        Assert.Pass();
    }

    [Test]
    public void GetOddNumbersListTest()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        Assert.That(list, Is.EqualTo(TurboMaths.GetOddNumbersList(6)));
    }
    
    [Test]
    public void GetOddNumbersTest()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        List<int> secondList = new List<int>();
        foreach (var number in TurboMaths.GetOddNumbers(6))
        {
            secondList.Add(number);
        }
        Assert.That(list, Is.EqualTo(secondList));

        
    }
}