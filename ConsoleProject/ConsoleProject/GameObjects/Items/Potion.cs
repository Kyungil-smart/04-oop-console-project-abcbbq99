

public class Potion : Item, IInteractable
{
    public Potion() => Init();
    
    private void Init()
    {
        Symbol = 'I';
        Name = "Potion";
    }

    public override void Use()
    {
        Owner.Heal(10);
        
        Inventory.Remove(this);
        Inventory = null;
        Owner = null;
        
        Debug.Log($"아이템 : {Name} 사용");
    }

    public void Interact(PlayerCharacter player)
    {
        player.AddItem(this);
    }
}