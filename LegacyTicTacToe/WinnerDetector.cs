namespace LegacyTicTacToe;

public class WinnerDetector
{
    private static readonly Field[][] WinningCombinations = {
        new[] { Field.One, Field.Two, Field.Three },
        new[] { Field.Four, Field.Five, Field.Six },
        new[] { Field.Seven, Field.Eight, Field.Nine },
        new[] { Field.One, Field.Four, Field.Seven },
        new[] { Field.Two, Field.Five, Field.Eight },
        new[] { Field.Three, Field.Six, Field.Nine },
        new[] { Field.One, Field.Five, Field.Nine },
        new[] { Field.Three, Field.Five, Field.Seven },
    };

    public static bool HasWon(List<Field> fields)
    {
        return WinningCombinations.Any(combination =>
            combination.All(fields.Contains));
    }
}