
public class BattleList
{
    public PlayerSkill _skillMenu { get; }
    private List<Monster> _monsters = new List<Monster>();
    public bool IsActive { get; set; }
    public MenuList _monsterList = new MenuList();
    private PlayerCharacter _owner;
    public PlayerSkill playerSkill { get; }
    
    public BattleList(PlayerCharacter owner)
    {
        _owner = owner;
    }
    
    private void PlayerSkillToggle()
    {
        playerSkill.IsActive = !playerSkill.IsActive;
    }

    public void Add(Monster monster)
    {
        _monsters.Add(monster);
        _monsterList.Add(monster.Name, PlayerSkillToggle);
        monster.BattleList = this;
        monster.Player = _owner;
        
        Debug.Log($"전투목록 : {monster} 추가");
    }

    public void Remove(Monster monster)
    {
        _monsters.Remove(monster);
        _monsterList.Remove();
        Debug.Log($"전투목록 : {monster} 삭제");
    }

    public void Render()
    {
        if (!IsActive) return;
        
        _monsterList.Render(15, 5);
    }

    public void Select()
    {
        if(!IsActive || _skillMenu.IsActive) return;
        _monsterList.Select();
    }

    public void SelectUp()
    {
        if(!IsActive || _skillMenu.IsActive) return;
        _monsterList.SelectUp();
    }

    public void SelectDown()
    {
        if(!IsActive || _skillMenu.IsActive) return;
        _monsterList.SelectDown();
    }
}