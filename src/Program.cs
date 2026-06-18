using ProjectEuler.Problems;
using System.Diagnostics;

// Discover every problem in this assembly, keyed by the number in its ProblemNNNNN class name.
var problems = typeof(IProblem).Assembly
    .GetTypes()
    .Where(t => t is { IsClass: true, IsAbstract: false } && typeof(IProblem).IsAssignableFrom(t))
    .Select(t => (Type: t, Number: ParseNumber(t.Name)))
    .Where(x => x.Number is not null)
    .ToDictionary(x => x.Number!.Value, x => x.Type);

if (problems.Count == 0)
{
    Console.WriteLine("No problems found.");
    return 1;
}

int number;
if (args.Length == 0)
{
    number = problems.Keys.Max();
    Console.WriteLine($"No problem specified; running the latest (#{number}). Pass a number to pick one, e.g. dotnet run -- 1");
    Console.WriteLine();
}
else if (!int.TryParse(args[0], out number))
{
    Console.WriteLine($"'{args[0]}' is not a valid problem number.");
    PrintAvailable(problems);
    return 1;
}

if (!problems.TryGetValue(number, out Type? problemType))
{
    Console.WriteLine($"No problem found with number {number}.");
    PrintAvailable(problems);
    return 1;
}

var problem = (IProblem)Activator.CreateInstance(problemType)!;

Console.WriteLine($"Running {problem.GetType().Name}...");
Console.WriteLine();

Stopwatch sw = Stopwatch.StartNew();
string answer = problem.Solve();
sw.Stop();

Console.WriteLine($"Question: {problem.Question}");
Console.WriteLine($"Answer: {answer}");
Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
return 0;

static int? ParseNumber(string typeName) =>
    typeName.StartsWith("Problem") && int.TryParse(typeName.AsSpan("Problem".Length), out int n)
        ? n
        : null;

static void PrintAvailable(IReadOnlyDictionary<int, Type> problems)
{
    Console.WriteLine("Available problems:");
    foreach (int n in problems.Keys.OrderBy(x => x))
    {
        Console.WriteLine($"  {n}");
    }
}
