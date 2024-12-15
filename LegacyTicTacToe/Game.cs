namespace LegacyTicTacToe;

public class Game
{
    private readonly Input _inputX;
    private readonly Output _outputX;
    private readonly Input _inputO;
    private readonly Output _outputO;
    private readonly List<Field> _playerXFields;
    private readonly List<Field> _playerOFields;
    private Turn _turn;
    
    public Game(Input inputX, Output outputX, Input inputO, Output outputO)
    {
        _inputX = inputX;
        _outputX = outputX;
        _inputO = inputO;
        _outputO = outputO;
        _turn = Turn.X;
        _playerXFields = new List<Field>();
        _playerOFields = new List<Field>();
    }

    public void Start()
    {
        Display(ToDto(), _outputX);
        StartTurns();
    }

    private void StartTurns()
    {
        while (!WinnerDetector.HasWon(_playerXFields) && 
               (_playerXFields.Count + _playerOFields.Count) != 9 && 
               !WinnerDetector.HasWon(_playerOFields))
        {
            if (_turn == Turn.X)
            {
                _playerXFields.Add(YourTurn(_inputX, _outputX));
                Display(ToDto(), _outputX);
                Display(ToDto(), _outputO);
                _turn = Turn.O;
            }
            else
            {
                _playerOFields.Add(YourTurn(_inputO, _outputO));
                Display(ToDto(), _outputX);
                Display(ToDto(), _outputO);
                _turn = Turn.X;
            }
        }
    }

    private GameStateDto ToDto()
    {
        var playerX = new List<Field>(_playerXFields);
        var playerO = new List<Field>(_playerOFields);

        if (WinnerDetector.HasWon(_playerXFields))
        {
            return GameStateDto.WinningX(playerX, playerO);
        }
        if ((_playerXFields.Count + _playerOFields.Count) == 9)
        {
            return GameStateDto.NoWinner(playerX, playerO);
        }
        if (WinnerDetector.HasWon(_playerOFields))
        {
            return GameStateDto.WinningO(playerX, playerO);
        }
        return GameStateDto.OnGoingGame(playerX, playerO);
    }

    private Field YourTurn(Input input, Output output)
    {
        output.Display("your turn...");
        while (true)
        {
            var value = input.Read();
            if (FieldsRepresentations.Exists(value))
            {
                return FieldsRepresentations.Get(value);
            }
            output.Display("invalid input, please try again");
        }
    }

    private void Display(GameStateDto gameStateDto, Output output)
    {
        output.Display(RepresentGameState(gameStateDto));
    }
    
    private string RepresentGameState(GameStateDto gameStateDto)
    {
        return new GameStateRepresentation(gameStateDto).Create();
    }
}