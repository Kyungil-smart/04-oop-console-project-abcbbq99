

public abstract class Skill : GameObject
{
    public PlayerCharacter Player { get; set; }
    public Monster Monster { get; set; }
    public PlayerSkill PlayerSkill { get; set; }
    
    public int Power { get; set; }
    
    public abstract void Effect();
}