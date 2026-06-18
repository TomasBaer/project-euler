namespace ProjectEuler.Problems;

public interface IProblem
{
    int Limit { get; }

    string Question { get; }

    string Solve();
}
