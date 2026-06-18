namespace ProjectEuler.Problems;

public class Problem00002 : IProblem
{
    public long Limit => 4_000_000;

    public string Question => $"By considering the terms in the Fibonacci sequence whose values do not exceed {Limit}, find the sum of the even - valued terms.";

    public string Solve()
    {
        long sum = 0;

        int prev = 1;
        int current = 1;

        while (current < Limit)
        {
            int next = prev + current;

            if (next < Limit && next % 2 == 0)
            {
                sum += next;
            }

            prev = current;
            current = next;
        }

        return sum.ToString();
    }
}
