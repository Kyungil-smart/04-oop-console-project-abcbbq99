
public class SampleFieldScene : Scene
{
    private Tile[,] _field = new Tile[10, 20];
    private PlayerCharacter _player;
    
    public SampleFieldScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = player;
        
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _field[y, x] = new Tile(pos);
                _field[0, x].OnTileObject = new Wall();
                _field[y, 0].OnTileObject = new Wall();
            }
        }
    }

    public override void Enter()
    {
        if (SceneManager.isSceneReset)
        {
            _player.Field = _field;
            _player.Position = new Vector(4, 2);
            _field[_player.Position.Y, _player.Position.X].OnTileObject = _player;

            for (int y = 0; y < _field.GetLength(0); y++)
            {
                for (int x = 0; x < _field.GetLength(1); x++)
                {
                    _field[0, x].OnTileObject = new Wall();
                    _field[_field.GetLength(0) - 1, x].OnTileObject = new Wall();
                    _field[y, 0].OnTileObject = new Wall();
                    _field[y, _field.GetLength(1) - 1].OnTileObject = new Wall();
                }
            }
            
            Debug.LogWarning("XX 씬 초기화 완료");
        }
        else
        {
            Debug.LogWarning("XX 씬 초기화 안됨");
        }
        
        Debug.Log("-----XX 씬 진입-----");
        SceneManager.isSceneReset = true;
        Debug.LogWarning("씬 초기화 작동");
    }

    public override void Update()
    {
        _player.Update();
    }

    public override void Render()
    {
        PrintField();
        _player.Render();
    }

    public override void Exit()
    {
        if (SceneManager.isSceneReset)
        {
            _field[_player.Position.Y, _player.Position.X].OnTileObject = null;
            _player.Field = null;
            Debug.LogWarning("플레이어 위치 참조 삭제");
        }
        else
        {
            Debug.LogWarning("플레이어 위치 참조 유지");
        }
        Debug.Log("-----XX 씬 퇴장-----");
    }

    private void PrintField()
    {
        Console.SetCursorPosition(0,2);
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                _field[y, x].Print();
            }
            Console.WriteLine();
        }
    }
}