using System.Collections;
using NuGet.Frameworks;
using TurboCollections;

namespace SearchTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindNumbers()
    {
        TurboList<IComparable?> testList = new TurboList<IComparable?>();
        for (int i = 0; i < 100; i++)
        {
            testList.Add(i);
        }

        Assert.Multiple(() =>
        {
            Assert.That(TurboSearch.BinarySearch(testList, 43), Is.EqualTo(43));
            Assert.That(TurboSearch.BinarySearch(testList, 55), Is.EqualTo(55));
            Assert.That(TurboSearch.BinarySearch(testList, 22), Is.EqualTo(22));
        });
    }
    
    [Test]
    public void FindExtremeties()
    {
        TurboList<IComparable?> testList = new TurboList<IComparable?>();
        for (int i = 0; i < 100; i++)
        {
            testList.Add(i);
        }

        Assert.Multiple(() =>
        {
            Assert.That(TurboSearch.BinarySearch(testList, 99), Is.EqualTo(99));
            Assert.That(TurboSearch.BinarySearch(testList, 0), Is.EqualTo(0));
            Assert.That(TurboSearch.BinarySearch(testList, -5), Is.EqualTo(null));
            Assert.That(TurboSearch.BinarySearch(testList, 100), Is.EqualTo(null));
        });
    }
}