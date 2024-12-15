namespace LegacyTicTacToe;

public class GameStateRepresentation
{
    private readonly string[][] _board;
    private readonly GameStateDto _gameStateDto;

    public GameStateRepresentation(GameStateDto gameStateDto)
    {
        _board = new[]
        {
            new[] { "1", "2", "3" },
            new[] { "4", "5", "6" },
            new[] { "7", "8", "9" }
        };
        _gameStateDto = gameStateDto;
    }

    public string Create()
    {
        return RepresentBoard() + ComposeFinalMessage();
    }

    private string RepresentBoard()
    {
        return string.Join("---------\n", FillBoard().Select(RepresentRow));

        static string RepresentRow(string[] row)
        {
            return string.Join(" | ", row) + "\n";
        }
    }

    private string[][] FillBoard()
    {
        return _board.Select(row => row.Select(RepresentField).ToArray()).ToArray();
    }

    private string RepresentField(string fieldString)
    {
        var field = FieldsRepresentations.Get(fieldString);

        if (_gameStateDto.PlayerX.Contains(field))
        {
            return "X";
        }

        if (_gameStateDto.PlayerO.Contains(field))
        {
            return "O";
        }

        return fieldString;
    }

    private string ComposeFinalMessage()
    {
        var gameStatus = _gameStateDto.Status;
        if (gameStatus is OnGoing)
        {
            return "";
        }
        return ComposeGameOverMessage((Over)gameStatus);

        static string ComposeGameOverMessage(Over gameStatus)
        {
            if (gameStatus.Result == Result.OWins)
            {
                return "O wins!\n";
            }
            else if (gameStatus.Result == Result.XWins)
            {
                return "X wins!\n";
            }
            return "Draw!\n";
        }
    }
}