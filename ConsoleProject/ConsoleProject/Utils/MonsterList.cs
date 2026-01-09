

public class MonsterList
{
    private List<(Monster monster, Action action)> _monsters;
    private int _currentIndex;
    public int CurrentIndex { get => _currentIndex; }
    private Ractangle _outline;
    private int _maxLength;

    public MonsterList(params (Monster, Action)[] menuTexts)
    {
        if (menuTexts.Length == 0)
        {
            _monsters = new List<(Monster, Action)>();
        }
        else
        {
            _monsters = menuTexts.ToList();
        }

        for (int i = 0; i < _monsters.Count; i++)
        {
            int textWidth = _monsters[i].monster.Name.GetTextWidth();
            
            if (_maxLength < textWidth)
            {
                _maxLength = textWidth;
            }
        }

        _outline = new Ractangle(width: _maxLength + 4, height: _monsters.Count + 2);
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void Select()
    {
        if (_monsters.Count == 0) return;
        
        _monsters[_currentIndex].action?.Invoke();
        
        if(_monsters.Count == 0) _currentIndex = 0;
        else if (_currentIndex >= _monsters.Count) _currentIndex = _monsters.Count - 1;
    }

    public void Add(Monster monster, Action action)
    {
        _monsters.Add((monster, action));
        
        int textWidth = monster.Name.GetTextWidth();
        if (_maxLength < textWidth)
        {
            _maxLength = textWidth;
        }

        _outline.Width = _maxLength + 6;
        _outline.Height++;
    }

    public void Remove()
    {
        _monsters.RemoveAt(_currentIndex);

        int max = 0;
        
        foreach ((Monster monster, Action action) in _monsters)
        {
            int textWidth = monster.Name.GetTextWidth();

            if (max < textWidth) max = textWidth;
        }
        
        if(_maxLength != max) _maxLength = max;
        
        _outline.Width = _maxLength + 6;
        _outline.Height--;
    }

    public void SelectUp()
    {
        _currentIndex--;

        if (_currentIndex < 0) 
            _currentIndex = 0;
    }

    public void SelectDown()
    {
        _currentIndex++;
        
        if(_currentIndex >= _monsters.Count) 
            _currentIndex = _monsters.Count - 1;
    }

    public void Render(int x, int y)
    {
        _outline.X = x;
        _outline.Y = y;
        _outline.Draw();
        
        for(int i = 0; i < _monsters.Count; i++)
        {
            y++;
            Console.SetCursorPosition(x + 1, y);
            
            if (i == _currentIndex)
            {
                "->".Print(ConsoleColor.Green);
                _monsters[i].monster.Name.Print(ConsoleColor.Green);
                continue;
            }
            else
            {
                Console.Write("  ");
                _monsters[i].monster.Name.Print();
            }
        }
    }
}