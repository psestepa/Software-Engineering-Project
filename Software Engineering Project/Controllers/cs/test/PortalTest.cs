using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace cs
{
  [TestFixture]
  public class PortalTest
  {
    private Portal Portal;
    private List<String> EmptyList = new List<String>() { };
    private Dictionary<Char, int> EmptyDict = new Dictionary<Char, int>() { };
    private List<String> OneNameList = new List<String>() { "Pio" };
    private Dictionary<Char, int> OneNameDict = new Dictionary<Char, int>() { { 'P', 1 } };
    private List<String> TwoNamesSame = new List<String>() { "Pio", "Poi" };
    private Dictionary<Char, int> TwoNamesSameDict = new Dictionary<Char, int>() { { 'P', 2 } };
    private List<String> TwoNamesDiff = new List<String>() { "Pio", "Lina" };
    private Dictionary<Char, int> TwoNamesDiffDict = new Dictionary<Char, int>() { { 'P', 1 }, { 'L', 1 } };
    private List<String> LargeList = new List<String>() { "Abdon", "Brandon", "Christopher", "Daniel", "Denys", "Diego", "Edrienne", "Eugene", "Ezequiel", "Gustavo", "Houtan", "Jeffry", "Lina", "Luis", "Martin", "Matthew", "Mike", "Naresh", "Nicolas", "Patricio", "Pio", "Rachel", "Ravali", "Samad", "Shaneej", "Shara", "Sikender", "Tommy", "Venkat", "Victor", "Zachary" };
    private Dictionary<Char, int> LargeDict = new Dictionary<Char, int>() { { 'A', 1 }, { 'B', 1 }, { 'C', 1 }, { 'D', 3 }, { 'E', 3 }, { 'G', 1 }, { 'H', 1 }, { 'J', 1 }, { 'L', 2 }, { 'M', 3 }, { 'N', 2 }, { 'P', 2 }, { 'R', 2 }, { 'S', 4 }, { 'T', 1 }, { 'V', 2 }, { 'Z', 1 } };

    [Test]
    public void CanaryTest()
    {
      Assert.IsTrue(true);
    }

    [SetUp]
    public void Init()
    {
      Portal = new Portal();
    }

    [Test]
    public void AverageNumberOfLettersImperativeForEmptyList()
    {
      Assert.AreEqual(0, Portal.AverageNumberOfLettersImperative(EmptyList));
    }

    [Test]
    public void AverageNumberOfLettersImperativeForOneNameList()
    {
      Assert.AreEqual(OneNameList[0].Length, Portal.AverageNumberOfLettersImperative(OneNameList));
    }

    [Test]
    public void AverageNumberOfLettersImperativeForTwoNamesSame()
    {
      Assert.AreEqual(OneNameList[0].Length, Portal.AverageNumberOfLettersImperative(TwoNamesSame));
    }

    [Test]
    public void AverageNumberOfLettersImperativeForTwoNamesDiff()
    {
      Assert.AreEqual(3.5, Portal.AverageNumberOfLettersImperative(TwoNamesDiff));
    }

    [Test]
    public void AverageNumberOfLettersImperativeForLargeLists()
    {
      Assert.AreEqual(6.129032258064516, Portal.AverageNumberOfLettersImperative(LargeList));
    }

    [Test]
    public void AverageNumberOfLettersFunctionalForEmptyList()
    {
      Assert.AreEqual(0, Portal.AverageNumberOfLettersFunctional(EmptyList));
    }

    [Test]
    public void AverageNumberOfLettersFunctionalForOneNameList()
    {
      Assert.AreEqual(OneNameList[0].Length, Portal.AverageNumberOfLettersFunctional(OneNameList));
    }

    [Test]
    public void AverageNumberOfLettersFunctionalForTwoNamesSame()
    {
      Assert.AreEqual(OneNameList[0].Length, Portal.AverageNumberOfLettersFunctional(TwoNamesSame));
    }

    [Test]
    public void AverageNumberOfLettersFunctionalForTwoNamesDiff()
    {
      Assert.AreEqual(3.5, Portal.AverageNumberOfLettersFunctional(TwoNamesDiff));
    }

    [Test]
    public void AverageNumberOfLettersFunctionalForLargeLists()
    {
      Assert.AreEqual(6.129032258064516, Portal.AverageNumberOfLettersFunctional(LargeList));
    }

    [Test]
    public void CountLetterOccurrencesImperativeForEmptyList()
    {
      Assert.AreEqual(EmptyDict, Portal.CountLetterOccurrencesImperative(EmptyList));
    }

    [Test]
    public void CountLetterOccurrencesImperativeForOneNameList()
    {
      Assert.AreEqual(OneNameDict, Portal.CountLetterOccurrencesImperative(OneNameList));
    }

    [Test]
    public void CountLetterOccurrencesImperativeForTwoNamesSame()
    {
      Assert.AreEqual(TwoNamesSameDict, Portal.CountLetterOccurrencesImperative(TwoNamesSame));
    }

    [Test]
    public void CountLetterOccurrencesImperativeForTwoNamesDiff()
    {
      Assert.AreEqual(TwoNamesDiffDict, Portal.CountLetterOccurrencesImperative(TwoNamesDiff));
    }

    [Test]
    public void CountLetterOccurrencesImperativeForLargeList()
    {
      Assert.AreEqual(LargeDict, Portal.CountLetterOccurrencesImperative(LargeList));
    }

    [Test]
    public void CountLetterOccurrencesFunctionalForEmptyList()
    {
      Assert.AreEqual(EmptyDict, Portal.CountLetterOccurrencesFunctional(EmptyList));
    }

    [Test]
    public void CountLetterOccurrencesFunctionalForOneNameList()
    {
      Assert.AreEqual(OneNameDict, Portal.CountLetterOccurrencesFunctional(OneNameList));
    }

    [Test]
    public void CountLetterOccurrencesFunctionalForTwoNamesSame()
    {
      Assert.AreEqual(TwoNamesSameDict, Portal.CountLetterOccurrencesFunctional(TwoNamesSame));
    }

    [Test]
    public void CountLetterOccurrencesFunctionalForTwoNamesDiff()
    {
      Assert.AreEqual(TwoNamesDiffDict, Portal.CountLetterOccurrencesFunctional(TwoNamesDiff));
    }

    [Test]
    public void CountLetterOccurrencesFunctionalForLargeList()
    {
      Assert.AreEqual(LargeDict, Portal.CountLetterOccurrencesFunctional(LargeList));
    }
  }
}