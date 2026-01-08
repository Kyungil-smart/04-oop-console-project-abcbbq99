

public class Potion : Item, IInteractable
{
    private int HealingPoint;
    public Potion(int value) => Init(value);
    
    private void Init(int value)
    {
        Symbol = 'I';
        Name = "Potion";
        HealingPoint = value;
        Description = $"{HealingPoint} 만큼 치유";
        
    }

    public override void Use()
    {
        Owner.Heal(HealingPoint);
        
        Inventory.Remove(this);
        Inventory = null;
        Owner = null;
    }

    public void Interact(PlayerCharacter player)
    {
        player.AddItem(this);
    }
}