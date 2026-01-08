

public class Wall : GameObject, IBlockable
{
    public Wall() => Init();
    
    private void Init()
    {
        Symbol = '■';
    }
}