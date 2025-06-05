namespace MathUniter;

public class Rooter
{
    public double SquareRoot(double input)
    {
        // On lève une exception si l'entrée est négative
        ArgumentOutOfRangeException.ThrowIfLessThan(input, 0);

        double result = input;
        double previousResult = -input;
        // On valide une approximation au 100000ième
        while (Math.Abs(previousResult - result) > result / 100000)
        {
            previousResult = result;
            result = (result + input / result) / 2;
        }

        return result;
    }
}
