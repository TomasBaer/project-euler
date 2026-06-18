namespace ProjectEuler.Problems;

public interface IProblem
{
    long Limit { get; }

    string Question { get; }

    string Solve();
}
