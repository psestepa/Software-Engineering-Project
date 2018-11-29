using System;
using System.Collections.Generic;
using System.Linq;

namespace cs
{
  class StringUtil
  {
    public double AverageNumberOfLettersImperative(List<String> names)
    {
      if (names.Count == 0) return 0;

      double total = 0;

      foreach (String name in names)
      {
        total += name.Length;
      }

      return total / names.Count;
    }

    public double AverageNumberOfLettersFunctional(List<String> names)
    {
      if (names.Count == 0) return 0;

      return (double)names.Select(e => e.Length).Sum() / names.Count;
    }

    public IDictionary<Char, int> CountLetterOccurrencesImperative(List<String> names)
    {
      var occurrences = new Dictionary<Char, int>();

      foreach (String name in names)
      {
        occurrences[name[0]] = (occurrences.ContainsKey(name[0]) ? occurrences[name[0]] : 0) + 1;
      }

      return occurrences;
    }

    public IDictionary<Char, int> CountLetterOccurrencesFunctional(List<String> names)
    {
      return names
      .GroupBy(e => e[0])
      .Select(e => new { k = e.First()[0], v = e.Count() })
      .ToDictionary(e => e.k, e => e.v);
    }
  }
}