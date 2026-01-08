

public class Trap : GameObject, IInteractable
{
    public PlayerCharacter Owner { get; set; }
    
    public Trap() => Init();
    
    private void Init()
    {
        Symbol = '▩';
    }
    
    public void Interact(PlayerCharacter player)
    {
        
    }
}