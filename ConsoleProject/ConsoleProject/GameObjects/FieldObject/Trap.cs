

public class Trap : GameObject, IInteractable
{
    public PlayerCharacter Owner { get; set; }
    private int TrapDamage;
    
    public Trap(int damage) => Init(damage);
    
    private void Init(int damage)
    {
        Symbol = '▩';
        TrapDamage = damage;
    }
    
    public void Interact(PlayerCharacter player)
    {
        Owner.TakeDamage(TrapDamage);
    }
}