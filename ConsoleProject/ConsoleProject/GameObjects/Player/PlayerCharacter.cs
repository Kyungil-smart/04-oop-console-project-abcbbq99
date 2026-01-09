

using System.Runtime.InteropServices.Marshalling;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> Health = new ObservableProperty<int>(_maxHealthValue);
    public const int _maxHealthValue = 100;
    public int AttackValue { get; set; }
    public int DefenceValue { get; set; }
    public int CritValue { get; set; }
    public int CritDefValue { get; set; }
    
    private string _healthGauge;
    
    public Tile[,] Field { get; set; }
    public BattleLog _battleLog { get; set; }
    
    private Inventory _inventory;
    private PlayerSkill _skill;
    private BattleList _battleList;
    
    public bool IsActiveControl { get; set; }

    public PlayerCharacter() => Init();

    public void Init()
    {
        Symbol = 'P';
        IsActiveControl = true;
        Health.AddListener(SetHealthGauge);
        _healthGauge = "■■■■■";
        _inventory = new Inventory(this);
        _skill = new PlayerSkill(this);
        _battleList = new BattleList(this);
        
        AttackValue = 10;
        DefenceValue = 0;
        CritValue = 10;
        CritDefValue = 0;
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.I))
        {
            HandleControl();
        }
        
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Move(Vector.Up);
            _inventory.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Vector.Down);
            _inventory.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Move(Vector.Right);
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _inventory.Select();
        }

        if (InputManager.GetKey(ConsoleKey.T))
        {
            ChangeHealth(-10);
        }
    }

    public void HandleControl()
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
        Debug.Log("-----인벤토리 개방-----");
    }

    private void Move(Vector direction)
    {
        if (Field == null || !IsActiveControl) return;
        
        Vector current = Position;
        Vector nextPos = Position + direction;
        
        // 1. 맵 바깥은 아닌지?
        bool isOutOfField = nextPos.X < 0 || nextPos.X >= Field.GetLength(1) ||
                            nextPos.Y < 0 || nextPos.Y >= Field.GetLength(0);
        
        if(isOutOfField) return;
        
        // 2. 벽인지?
        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;
        
        if (nextTileObject != null && nextTileObject is IBlockable) return;
        
        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable).Interact(this);
            }
        }

        Field[Position.Y, Position.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
        Position = nextPos;
    }

    public void Render()
    {
        DrawHealthGauge();
        _inventory.Render();
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }
    
    public void AddSkill(Skill skill)
    {
        _skill.Add(skill);
    }
    
    public void AddBattleList(Monster monster)
    {
        _battleList.Add(monster);
    }

    public void DrawHealthGauge()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write("체력 : ");
        _healthGauge.Print(ConsoleColor.Red);
    }

    public void SetHealthGauge(int health)
    {
        
        switch (health/(float)_maxHealthValue * 10f)
        {
            case 10f:
            case 9f:
                _healthGauge = "■■■■■";
                break;
            case 8f:
            case 7f:
                _healthGauge = "■■■■□";
                break;
            case 6f:
            case 5f:
                _healthGauge = "■■■□□";
                break;
            case 4f:
            case 3f:
                _healthGauge = "■■□□□";
                break;
            case 2f:
            case 1f:
                _healthGauge = "■□□□□";
                break;
            default:
                _healthGauge = "□□□□□";
                break;
        }
    }
    
    public void ChangeHealth(int value)
    {
        Health.Value += value;
        if (value > 0)
        {
            if (Health.Value > _maxHealthValue)
            {
                Health.Value = _maxHealthValue;
                Debug.LogWarning("플레이어 회복량 초과 : 체력 조정");
                _battleLog.Heal($"플레이어 : {value} 회복");
            }
            else
            {
                Debug.Log($"플레이어 : {value} 회복");
                _battleLog.Heal($"플레이어 : {value} 회복");
            }
        }
        else if(value < 0)
        {
            Debug.Log($"플레이어 : {(-1) * value} 피해");
            _battleLog.Damage($"플레이어 : {(-1) * value} 피해");
        
            if (Health.Value <= 0)
            {
                Console.Clear();
                "당신은 죽었습니다".Print(ConsoleColor.Red);
                GameManager.IsGameOver = true;
            }
        }
    }
    
}