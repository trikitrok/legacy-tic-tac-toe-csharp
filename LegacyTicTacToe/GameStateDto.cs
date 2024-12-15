namespace LegacyTicTacToe;

using System.Collections.Generic;

public enum Result
{
    XWins,
    OWins,
    Draw
}

public class Over
{
    public Result Result { get; }

    private Over(Result result)
    {
        Result = result;
    }

    public static Over XWins()
    {
        return new Over(Result.XWins);
    }

    public static Over OWins()
    {
        return new Over(Result.OWins);
    }

    public static Over Draw()
    {
        return new Over(Result.Draw);
    }
}

public class OnGoing
{
   
}

public class GameStateDto
{
    public IReadOnlyList<Field> PlayerX { get; }
    public IReadOnlyList<Field> PlayerO { get; }
    public object Status { get; } // Puede ser `Over` o `OnGoing`

    private GameStateDto(IReadOnlyList<Field> playerX, IReadOnlyList<Field> playerO, object status)
    {
        PlayerX = playerX;
        PlayerO = playerO;
        Status = status;
    }

    public static GameStateDto WinningX(IReadOnlyList<Field> playerX, IReadOnlyList<Field> playerO)
    {
        return new GameStateDto(playerX, playerO, Over.XWins());
    }

    public static GameStateDto WinningO(IReadOnlyList<Field> playerX, IReadOnlyList<Field> playerO)
    {
        return new GameStateDto(playerX, playerO, Over.OWins());
    }

    public static GameStateDto NoWinner(IReadOnlyList<Field> playerX, IReadOnlyList<Field> playerO)
    {
        return new GameStateDto(playerX, playerO, Over.Draw());
    }

    public static GameStateDto OnGoingGame(IReadOnlyList<Field> playerX, IReadOnlyList<Field> playerO)
    {
        return new GameStateDto(playerX, playerO, new OnGoing());
    }
}