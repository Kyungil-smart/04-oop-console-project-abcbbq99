public class TestScene : Scene
{
    private Tile[,] _field = new Tile[10, 20];
    private PlayerCharacter _player;

    public TestScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = player;

        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _field[y, x] = new Tile(pos);
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

            _field[3, 5].OnTileObject = new Potion();
            _field[2, 15].OnTileObject = new Trap();
            _field[7, 3].OnTileObject = new Wall();
            _field[9, 19].OnTileObject = new Potion();
            Debug.LogWarning("테스트 씬 초기화 완료");
        }
        else
        {
            Debug.LogWarning("테스트 씬 초기화 안됨");
        }
        
        Debug.Log("-----테스트 씬 진입-----");
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
        Debug.Log("-----테스트 씬 퇴장-----");
    }

    private void PrintField()
    {
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