
public class PlayerSkillInventory
{
    private List<Skill> _skills = new List<Skill>();
    public bool IsActive { get; set; }
    public PlayerSkillList _skillList = new PlayerSkillList();
    private PlayerCharacter _owner;
    private int Gold { get; set; }
    
    public PlayerSkillInventory(PlayerCharacter owner)
    {
        _owner = owner;
    }

    public void Add(Skill skill)
    {
        
        Debug.Log($"인벤토리 : {skill} 추가");
    }

    public void Remove(Skill skill)
    {
        _skills.Remove(skill);
        _skillList.Remove();
        Debug.Log($"인벤토리 : {skill} 삭제");
    }

    public void Render()
    {
        if (!IsActive) return;
        
        _skillList.Render(5, 5);
    }

    public void Select()
    {
        if(!IsActive) return;
        _skillList.Select();
    }

    public void SelectUp()
    {
        if(!IsActive) return;
        _skillList.SelectUp();
    }

    public void SelectDown()
    {
        if(!IsActive) return;
        _skillList.SelectDown();
    }
}