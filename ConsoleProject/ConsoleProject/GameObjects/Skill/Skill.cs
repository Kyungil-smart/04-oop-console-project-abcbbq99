

public abstract class Skill : GameObject
{
    public PlayerCharacter player { get; set; }
    public Monster monster { get; set; }
    
    public float Power { get; set; }

    public abstract void Effect();
}