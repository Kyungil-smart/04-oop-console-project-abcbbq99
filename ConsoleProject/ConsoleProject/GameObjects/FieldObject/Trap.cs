

public class Trap : GameObject, IInteractable
{
    public Trap() => Init();
    
    private void Init()
    {
        Symbol = '▩';
    }
    
    public void Interact(PlayerCharacter player)
    {
        player.ChangeHealth(-10);
    }
}