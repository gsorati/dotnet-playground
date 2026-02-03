// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
////Test.CountWords();
Test.PerfImprovement();
public static class Test
{
    public static void CountWords()
    {
        string text = "Hello world! hello C# world, welcome to the world of C#.";
        Dictionary<string, int> wordsDict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        string[] words = text.Split(' ');
        foreach (var word in words)
        {
            var lowerWord = word.ToLower().Trim(new char[] { '.', ',', '!', '?' });
            if (wordsDict.ContainsKey(lowerWord))
                wordsDict[lowerWord]++;
            else
                wordsDict[lowerWord] = 1;
        }

        foreach (var word in wordsDict)
        {
            Console.WriteLine($"Word name {word.Key} with count : {word.Value}");
        }
    }

    public static void PerfImprovement()
    {
        List<Employee> deptA = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice" },
            new Employee { Id = 2, Name = "Bob" },
            new Employee { Id = 3, Name = "Charlie" }
        };

        List<Employee> deptB = new List<Employee>
        {
            new Employee { Id = 3, Name = "Charlie" }, // duplicate
            new Employee { Id = 4, Name = "Diana" },
            new Employee { Id = 5, Name = "Ethan" }
        };

        var merged = deptB.Concat(deptA).GroupBy(e => e.Id).Select(item => item.First()).OrderBy(x => x.Id).ToList();

        // Print result
        foreach (var emp in merged)
        {
            Console.WriteLine($"{emp.Id} - {emp.Name}");
        }
    }
}


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}

////class Program
////{
////    static void Main()
////    {
////        List<Employee> deptA = new List<Employee>
////        {
////            new Employee { Id = 1, Name = "Alice" },
////            new Employee { Id = 2, Name = "Bob" },
////            new Employee { Id = 3, Name = "Charlie" }
////        };

////        List<Employee> deptB = new List<Employee>
////        {
////            new Employee { Id = 3, Name = "Charlie" }, // duplicate
////            new Employee { Id = 4, Name = "Diana" },
////            new Employee { Id = 5, Name = "Ethan" }
////        };

////        var merged = deptB.Concat(deptA).GroupBy(e => e.Id).Select(item => item.First()).ToList();
////        ////List<Employee> merged = new List<Employee>();

////        ////// Inefficient merge
////        ////foreach (var emp in deptA)
////        ////{
////        ////    merged.Add(emp);
////        ////}

////        ////foreach (var emp in deptB)
////        ////{

////        ////}

////        // Print result
////        foreach (var emp in merged)
////        {
////            Console.WriteLine($"{emp.Id} - {emp.Name}");
////        }
////    }
////}