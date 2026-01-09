
public class MonsterInventory
{
    private List<Monster> _monsters = new List<Monster>();
    public bool IsActive { get; set; }
    public MonsterList _monsterList = new MonsterList();
    private PlayerCharacter _owner;
    private int Gold { get; set; }
    
    public MonsterInventory(PlayerCharacter owner)
    {
        _owner = owner;
    }

    public void Add(Monster monster)
    {
        
        Debug.Log($"인벤토리 : {monster} 추가");
    }

    public void Remove(Monster monster)
    {
        _monsters.Remove(monster);
        _monsterList.Remove();
        Debug.Log($"인벤토리 : {monster} 삭제");
    }

    public void Render()
    {
        if (!IsActive) return;
        
        _monsterList.Render(15, 5);
    }

    public void Select()
    {
        if(!IsActive) return;
        _monsterList.Select();
    }

    public void SelectUp()
    {
        if(!IsActive) return;
        _monsterList.SelectUp();
    }

    public void SelectDown()
    {
        if(!IsActive) return;
        _monsterList.SelectDown();
    }
}