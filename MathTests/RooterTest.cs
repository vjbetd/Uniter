using MathUniter;

namespace MathTests;

[TestClass]
public class RooterTest
{
    private Rooter Rooter { get; set; } = null!;

    [TestInitialize]
    public void InitRooter()
    {
        // On initialise le service
        Rooter = new();
    }

    [TestMethod]
    public void BasicRooterTest()
    {
        // On définit le résultat attendu et sa valeur initiale
        double expectedResult = 2.0;
        double input = expectedResult * expectedResult;

        // On calcule le résultat
        double actualResult = Rooter.SquareRoot(input);

        // On vérifie le résultat
        Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100000);
    }

    private void RooterOneValue(double expectedResult)
    {
        double input = expectedResult * expectedResult;
        double actualResult = Rooter.SquareRoot(input);
        Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100000);
    }

    [TestMethod]
    public void RooterValueRange()
    {
        // On essaye toute une gamme de valeurs
        for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
        {
            RooterOneValue(expected);
        }
    }

    [TestMethod]
    public void RooterTestNegativeInput()
    {
        // On vérifie qu'un nombre négatif lance bien une exception
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Rooter.SquareRoot(-1));
    }
}
