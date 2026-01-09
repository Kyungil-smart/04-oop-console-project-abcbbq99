

public class BattleLog
{
    public PlayerCharacter _player { get; }
    public Monster _monster { get; }
    
    
    public enum LogType
    {
        Default,
        Heal,
        Damage,
        Death
    }
    
    private List<(LogType type, string text)> _battlelogList = new List<(LogType type, string text)>();

    public void Log(string text)
    {
        _battlelogList.Add((LogType.Default, text));
    }

    public void Heal(string text)
    {
        _battlelogList.Add((LogType.Heal, text));
    }
    
    public void Damage(string text)
    {
        _battlelogList.Add((LogType.Damage, text));
    }
    
    public void Death(string text)
    {
        _battlelogList.Add((LogType.Death, text));
    }

    public void Render()
    {
        foreach ((LogType type, string text) in _battlelogList)
        {
            if (type == LogType.Default) text.Print();
            else if (type == LogType.Heal) text.Print(ConsoleColor.Green);
            else if (type == LogType.Damage) text.Print(ConsoleColor.Red);
            else if (type == LogType.Death) text.Print(ConsoleColor.DarkCyan);
            Console.WriteLine();
        }
    }
}