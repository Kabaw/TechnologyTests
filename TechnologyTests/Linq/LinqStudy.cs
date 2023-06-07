using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyTests.Linq;

public class LinqStudy
{
    private IEnumerable<string> names = new List<string>() { "Kai", "Eliana", "Eliana", "Jayden", "Ezra", "Ezra", "Ezra", "Luca", "Luca", "Rowan", "Nova", "Amara" };

    public LinqStudy()
    {
        ExecuteTests();
    }

    private void ExecuteTests()
    {
        //All names that contains the leter "R"
        var result = names.Where(x => x.Contains("R", StringComparison.OrdinalIgnoreCase)).ToList();
        Print(result);

        //All names that contains the leter "R" and "A"
        result = names.Where(x => 
            x.Contains("R", StringComparison.OrdinalIgnoreCase) &&
            x.Contains("j", StringComparison.OrdinalIgnoreCase)).ToList();
        Print(result);

        //All names that repeats
        result = names
            .GroupBy(x => x)
            .Where(x => x.Count() > 1)
            .Select(x => x.First())
            .ToList();
        Print(result);

        //All names that repeats
        result =
            (from n in names
            group n by n into g
            where g.Count() > 1
            select g.First())
            .ToList();

        Print(result);
    }

    private void Print(IEnumerable<string> data)
    {
        var result = data.Count() > 0
            ? data
            : new List<string>() { "Empty" };

        Console.WriteLine(string.Join(" ", result));
    }
}