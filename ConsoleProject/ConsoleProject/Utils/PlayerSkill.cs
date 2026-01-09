
public class PlayerSkill
{
    private List<Skill> _skills = new List<Skill>();
    public bool IsActive { get; set; }
    public MenuList _skillMenu = new MenuList();
    private PlayerCharacter _owner;
    private int Gold { get; set; }
    
    public PlayerSkill(PlayerCharacter owner)
    {
        _owner = owner;
    }

    public void Add(Skill skill)
    {
        if (_skills.Count >= 5) return;
        
        _skills.Add(skill);
        _skillMenu.Add(skill.Name, skill.Effect);
        skill.PlayerSkill = this;
        skill.Player = _owner;
        
        Debug.Log($"스킬창 : {skill} 추가");
    }

    public void Remove(Skill skill)
    {
        _skills.Remove(skill);
        _skillMenu.Remove();
        Debug.Log($"스킬창 : {skill} 삭제");
    }

    public void Render()
    {
        if (!IsActive) return;
        
        _skillMenu.Render(5, 5);
    }

    public void Select()
    {
        if(!IsActive) return;
        _skillMenu.Select();
    }

    public void SelectUp()
    {
        if(!IsActive) return;
        _skillMenu.SelectUp();
    }

    public void SelectDown()
    {
        if(!IsActive) return;
        _skillMenu.SelectDown();
    }
}